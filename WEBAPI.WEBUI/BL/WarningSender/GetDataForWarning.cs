using AutoMapper;
using Microsoft.Extensions.Logging;
using WEBAPI.BL.Entities;
using WEBAPI.DAL.Repository;
using System.Collections.Generic;
using System.Linq;

namespace WEBAPI.BL.Reports
{
    public class GetDataForWarning
    {
        IEducationRepository _educationRepository;
        private ILogger _logger;
        private readonly IMapper _mapper;
        public GetDataForWarning(IEducationRepository educationRepository, ILogger<GetDataForWarning> logger, IMapper mapper)
        {
            _educationRepository = educationRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public ICollection<StudentBL> AverageMarkLimit(int mark)
        {
            var studentRepository = _educationRepository.GetStudentRepository();
            HashSet<StudentBL> studentsBL = new HashSet<StudentBL>();

            var students = studentRepository.GetStudentsIncludeAttendingLecturesAndHomeWork();

            foreach (var student in students)
            {
                int sumOfMarks = 0;
                int count = 0;
                foreach (var attendingLecture in student.AttendingLectures)
                {
                    count++;
                    if (attendingLecture.Atended == false || attendingLecture.HomeWork == null)
                    {
                        continue;
                    }
                    sumOfMarks += attendingLecture.HomeWork.CourseGrade;
                }
                if ((double)sumOfMarks / (double)count < mark)
                {
                    studentsBL.Add(_mapper.Map<StudentBL>(student));
                }
            }

            return studentsBL;
        }

        public ICollection<StudentBL> GetStudentsPasses(int passes)
        {
            var studentRepository = _educationRepository.GetStudentRepository();
            HashSet<StudentBL> studentsBL = new HashSet<StudentBL>();

            studentRepository.GetStudentsIncludeAttendingLecturesAndHomeWork().Where(s => s.AttendingLectures.Sum(a => a.Atended ? 0 : 1) >= passes).ToList().ForEach(a => studentsBL.Add(_mapper.Map<StudentBL>(a)));
            return studentsBL;
        }
    }
}

using AutoMapper;
using Microsoft.Extensions.Logging;
using WEBAPI.BL.Entities;
using WEBAPI.DAL.Repository;
using WEBAPI.DAL.Entities;
using WEBAPI.WEBUI.BL.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace WEBAPI.WEBUI.BL.Service
{
    public class StudentsService : IStudentsService
    {

        private readonly IStudentRepository _studentRepository;
        private readonly ILogger<StudentsService> _logger;
        private readonly IMapper _mapper;
        public StudentsService(IEducationRepository educationRepository, ILogger<StudentsService> logger, IMapper mapper)
        {
            _studentRepository = educationRepository.GetStudentRepository();
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<StudentBL> GetStudents()
        {

            var lisStudent = new List<StudentBL>();
            _studentRepository.GetStudents().ToList().ForEach(a => lisStudent.Add(_mapper.Map<StudentBL>(a)));
            return lisStudent;

        }

        public StudentBL GetStudentByID(int studentID)
        {
            if (!Utilities.CheckIdForNegativ(studentID))
            {
                var ex = new NegativeIDException($"ID = {studentID}");
                _logger.LogWarning(ex, $"ID = {studentID}");
                throw ex;
            }

            return _mapper.Map<StudentBL>(_studentRepository.GetStudentByID(studentID));
        }

        public void InsertStudent(StudentBL student)
        {
            if (!Utilities.CheckIdForNegativ(student.ID))
            {
                var ex = new NegativeIDException($"ID = {student.ID}");
                _logger.LogWarning(ex, $"ID = {student.ID}");
                throw ex;
            }
            if (!Utilities.CheckEmailAddress(student.EMail))
            {
                var ex = new WrongEmailException($"Email = {student.EMail}");
                _logger.LogWarning(ex, $"Email = {student.EMail}");
                throw ex;
            }
            _studentRepository.InsertStudent(_mapper.Map<Student>(student));
            _studentRepository.Save();
        }

        public void DeleteStudent(int studentID)
        {
            if (!Utilities.CheckIdForNegativ(studentID))
            {
                var ex = new NegativeIDException($"ID = {studentID}");
                _logger.LogWarning(ex, $"ID = {studentID}");
                throw ex;
            }

            _studentRepository.DeleteStudent(studentID);
            _studentRepository.Save();
        }

        public void UpdateStudent(StudentBL student)
        {

            if (!Utilities.CheckIdForNegativ(student.ID))
            {
                var ex = new NegativeIDException($"ID = {student.ID}");
                _logger.LogWarning(ex, $"ID = {student.ID}");
                throw ex;
            }
            if (!Utilities.CheckEmailAddress(student.EMail))
            {
                var ex = new WrongEmailException($"Email = {student.EMail}");
                _logger.LogWarning(ex, $"Email = {student.EMail}");
                throw ex;
            }

            _studentRepository.UpdateStudent(_mapper.Map<Student>(student));
            _studentRepository.Save();
        }

    }
}

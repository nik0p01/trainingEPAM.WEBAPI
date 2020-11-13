using Microsoft.Extensions.Logging;
using WEBAPI.DAL.Repository;
using WEBAPI.DAL.Entities;
using WEBAPI.WEBUI.BL.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace WEBAPI.WEBUI.BL.Reports
{
    public class GetDataForReport
    {
        IEducationRepository _educationRepository;
        private ILogger _logger;

        public GetDataForReport(IEducationRepository educationRepository, ILogger logger)
        {
            _educationRepository = educationRepository;
            _logger = logger;
        }



        public ICollection<LineOfReport> GetData(string typeReport, string name)
        {
            if (typeReport == "student")
            {
                return DataByStudent(name);
            }
            else if (typeReport == "lecture")
            {
                return DataByLecture(name);
            }
            else
            {
                throw new WrongReportTypeException(typeReport);
            }
        }



        public ICollection<LineOfReport> DataByStudent(string studentName)
        {
            var studentRepository = _educationRepository.GetStudentRepository();
            //TODO:  Exaption
            Student students = studentRepository.GetStudentsIncludeAttendingLecturesAndLecture().Where(s => s.FullName == studentName).FirstOrDefault();
            List<LineOfReport> lineOfReports = new List<LineOfReport>();
            if (students == null)
            {
                return lineOfReports;
            }
            foreach (var attendingLecture in students.AttendingLectures)
            {
                lineOfReports.Add(new LineOfReport() { AttendingLecture = attendingLecture.Atended, Lecture = attendingLecture.Lecture.Title, StudentName = students.FullName });
            }
            return lineOfReports;
        }

        public ICollection<LineOfReport> DataByLecture(string lectureName)
        {
            var lectureRepository = _educationRepository.GetLectureRepository();
            var lecture = lectureRepository.GetLecturesIncludeAttendingLecturesAndStudent().Where(l => l.Title == lectureName).FirstOrDefault();
            List<LineOfReport> lineOfReports = new List<LineOfReport>();
            if (lecture == null)
            {
                return lineOfReports;
            }
            foreach (var attendingLecture in lecture.AttendingLectures)
            {
                lineOfReports.Add(new LineOfReport() { AttendingLecture = attendingLecture.Atended, Lecture = lecture.Title, StudentName = attendingLecture.Student.FullName });
            }
            return lineOfReports;
        }
    }
}

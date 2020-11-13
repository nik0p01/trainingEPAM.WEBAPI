using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WEBAPI.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace WEBAPI.DAL.Repository
{
    public class StudentRepository : Repository, IStudentRepository
    {
        public StudentRepository(WEBAPIContext context, ILogger<EducationRepository> logger) : base(context, logger)
        {

        }

        public IEnumerable<Student> GetStudents()
        {
            return _context.Students;
        }
        public IEnumerable<Student> GetStudentsIncludeAttendingLecturesAndHomeWork()
        {
            return _context.Students.Include(s => s.AttendingLectures).ThenInclude(a => a.HomeWork);
        }
        public IEnumerable<Student> GetStudentsIncludeAttendingLecturesAndLecture()
        {
            return _context.Students.Include(s => s.AttendingLectures).ThenInclude(a => a.Lecture);
        }
        public Student GetStudentByID(int studentID)
        {
            return _context.Students.Where(s => s.ID == studentID).FirstOrDefault();
        }

        public void InsertStudent(Student student)
        {
            _context.Students.Add(student);
        }

        public void DeleteStudent(int studentID)
        {
            Student student = _context.Students.Include(s => s.AttendingLectures).FirstOrDefault(s => s.ID == studentID);
            if (student != null)
            {
                _context.Students.Remove(student);
            }
        }

        public void UpdateStudent(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
        }

    }
}

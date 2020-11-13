using WEBAPI.DAL.Entities;
using System.Collections.Generic;

namespace WEBAPI.DAL.Repository
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();
        Student GetStudentByID(int studentID);
        void InsertStudent(Student student);
        void DeleteStudent(int studentID);
        void UpdateStudent(Student student);
        IEnumerable<Student> GetStudentsIncludeAttendingLecturesAndHomeWork();
        IEnumerable<Student> GetStudentsIncludeAttendingLecturesAndLecture();
        void Save();
    }
}

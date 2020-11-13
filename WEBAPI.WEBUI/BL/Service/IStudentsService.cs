using WEBAPI.BL.Entities;
using System.Collections.Generic;

namespace WEBAPI.WEBUI.BL.Service
{
    public interface IStudentsService
    {
        IEnumerable<StudentBL> GetStudents();
        StudentBL GetStudentByID(int studentID);
        void InsertStudent(StudentBL student);
        void DeleteStudent(int studentID);
        void UpdateStudent(StudentBL student);

    }
}

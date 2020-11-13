using WEBAPI.DAL.Entities;
using System.Collections.Generic;

namespace WEBAPI.DAL.Repository
{
    public interface ILecturerRepository
    {
        IEnumerable<Lecturer> GetLecturers();

        Lecturer GetLecturerByID(int lecturerID);
        void InsertLecturer(Lecturer lecturer);
        void DeleteLecturer(int lecturerID);
        void UpdateLecturer(Lecturer lecturer);
        void Save();
    }
}

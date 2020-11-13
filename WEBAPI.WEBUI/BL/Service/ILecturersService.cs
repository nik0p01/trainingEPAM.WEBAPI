using WEBAPI.BL.Entities;
using System.Collections.Generic;

namespace WEBAPI.WEBUI.BL.Service
{
    public interface ILecturersService
    {
        IEnumerable<LecturerBL> GetLecturers();
        LecturerBL GetLecturerByID(int lecturerID);
        void InsertLecturer(LecturerBL lecturer);
        void DeleteLecturer(int lecturerID);
        void UpdateLecturer(LecturerBL lecturer);

    }
}

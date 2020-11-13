using WEBAPI.BL.Entities;
using System.Collections.Generic;

namespace WEBAPI.WEBUI.BL.Service
{
    public interface ILecturesService
    {
        IEnumerable<LectureBL> GetLectures();
        LectureBL GetLectureByID(int lectureId);
        void InsertLecture(LectureBL lecture);
        void DeleteLecture(int lectureID);
        void UpdateLecture(LectureBL lecture);

    }
}

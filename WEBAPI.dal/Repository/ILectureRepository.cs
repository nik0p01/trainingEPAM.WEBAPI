using WEBAPI.DAL.Entities;
using System.Collections.Generic;

namespace WEBAPI.DAL.Repository
{
    public interface ILectureRepository
    {
        IEnumerable<Lecture> GetLectures();
        IEnumerable<Lecture> GetLecturesIncludeAttendingLecturesAndStudent();
        Lecture GetLectureByID(int lectureId);
        void InsertLecture(Lecture lecture);
        void DeleteLecture(int lectureID);
        void UpdateLecture(Lecture lecture);
        void Save();
    }
}

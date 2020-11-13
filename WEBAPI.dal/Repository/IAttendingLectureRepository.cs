//using WEBAPI.Contract;
using WEBAPI.DAL.Entities;
using System.Collections.Generic;

namespace WEBAPI.DAL.Repository
{
    public interface IAttendingLectureRepository
    {
        IEnumerable<AttendingLecture> GetAttendingLectures();
        IEnumerable<AttendingLecture> GetAttendingLecturesIncludeStudentsAndLecture();
        AttendingLecture GetAttendingLectureByID(int AttendingLecture);
        void InsertAttendingLecture(AttendingLecture attendingLecture);
        void DeleteAttendingLecture(int AttendingLecture);
        void UpdateAttendingLecture(AttendingLecture attendingLecture);
        void Save();
    }
}

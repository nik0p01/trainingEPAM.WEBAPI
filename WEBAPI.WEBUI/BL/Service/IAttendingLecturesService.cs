using WEBAPI.BL.Entities;
using System.Collections.Generic;

namespace WEBAPI.WEBUI.BL.Service
{
    public interface IAttendingLecturesService
    {
        IEnumerable<AttendingLectureBL> GetAttendingLectures();
        AttendingLectureBL GetAttendingLectureByID(int attendingLectureId);
        void InsertAttendingLecture(AttendingLectureBL attendingLecture);
        void DeleteAttendingLecture(int attendingLectureId);
        void UpdateAttendingLecture(AttendingLectureBL attendingLecture);

    }
}

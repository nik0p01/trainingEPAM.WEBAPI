using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WEBAPI.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace WEBAPI.DAL.Repository
{
    public class AttendingLectureRepository : Repository, IAttendingLectureRepository
    {

        public AttendingLectureRepository(WEBAPIContext context, ILogger<EducationRepository> logger) : base(context, logger)
        {

        }
        public void DeleteAttendingLecture(int attendingLectureID)
        {
            AttendingLecture attendingLecture = _context.AttendingLectures.Where(al => al.ID == attendingLectureID).FirstOrDefault();
            _context.AttendingLectures.Remove(attendingLecture);
        }



        public IEnumerable<AttendingLecture> GetAttendingLectures()
        {
            return _context.AttendingLectures.ToList();
        }

        public AttendingLecture GetAttendingLectureByID(int attendingLectureId)
        {
            return _context.AttendingLectures.Where(al => al.ID == attendingLectureId).FirstOrDefault();
        }

        public void InsertAttendingLecture(AttendingLecture attendingLecture)
        {
            _context.AttendingLectures.Add(attendingLecture);
        }

        public void UpdateAttendingLecture(AttendingLecture attendingLecture)
        {
            _context.Entry(attendingLecture).State = EntityState.Modified;
        }

        public IEnumerable<AttendingLecture> GetAttendingLecturesIncludeStudentsAndLecture()
        {
            return _context.AttendingLectures.Include(a => a.Student).Include(a => a.Lecture);
        }
    }
}

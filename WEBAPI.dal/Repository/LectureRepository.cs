
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WEBAPI.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace WEBAPI.DAL.Repository
{
    public class LectureRepository : Repository, ILectureRepository
    {
        public LectureRepository(WEBAPIContext context, ILogger<EducationRepository> logger) : base(context, logger)
        {

        }
        public void DeleteLecture(int lectureID)
        {
            Lecture lecture = _context.Lectures.Where(s => s.ID == lectureID).FirstOrDefault();
            _context.Lectures.Remove(lecture);
        }

        public Lecture GetLectureByID(int lectureID)
        {
            return _context.Lectures.Where(s => s.ID == lectureID).FirstOrDefault();
        }

        public IEnumerable<Lecture> GetLectures()
        {
            return _context.Lectures.ToList();
        }
        public IEnumerable<Lecture> GetLecturesIncludeAttendingLecturesAndStudent()
        {
            return _context.Lectures.Include(l => l.AttendingLectures).ThenInclude(a => a.Student);
        }

        public void InsertLecture(Lecture lecture)
        {
            _context.Lectures.Add(lecture);
        }

        public void UpdateLecture(Lecture lecture)
        {
            _context.Entry(lecture).State = EntityState.Modified;
        }
    }
}

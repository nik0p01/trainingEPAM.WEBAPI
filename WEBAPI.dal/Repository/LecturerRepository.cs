using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WEBAPI.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace WEBAPI.DAL.Repository
{
    public class LecturerRepository : Repository, ILecturerRepository
    {
        public LecturerRepository(WEBAPIContext context, ILogger<EducationRepository> logger) : base(context, logger)
        {

        }

        public IEnumerable<Lecturer> GetLecturers()
        {
            return _context.Lecturers.ToList();
        }

        public Lecturer GetLecturerByID(int lecturerID)
        {
            return _context.Lecturers.Where(s => s.ID == lecturerID).FirstOrDefault();
        }

        public void InsertLecturer(Lecturer lecturer)
        {
            _context.Lecturers.Add(lecturer);
        }

        public void DeleteLecturer(int lecturerID)
        {
            Lecturer lecturer = _context.Lecturers.Where(s => s.ID == lecturerID).FirstOrDefault();
            _context.Lecturers.Remove(lecturer);
        }

        public void UpdateLecturer(Lecturer lecturer)
        {
            _context.Entry(lecturer).State = EntityState.Modified;
        }

    }
}

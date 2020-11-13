using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace WEBAPI.DAL.Repository
{
    public class EducationRepository : IEducationRepository
    {
        WEBAPIContext _context;
        private WEBAPIContext context;
        private readonly ILogger<EducationRepository> _logger;

        public EducationRepository(WEBAPIContext context, ILogger<EducationRepository> logger)
        {
            _context = context;
            _logger = logger;
        }



        public void EnsureCreated()
        {
            try
            {
                _context.Database.EnsureCreated();
            }
            catch (SqlException e)
            {
                _logger.LogError(e, e.Message);
                throw;
            }

        }

        public void EnsureDeleted()
        {
            try
            {
                _context.Database.EnsureDeleted();
            }
            catch (SqlException e)
            {
                _logger.LogError(e, e.Message);
                throw;
            }
        }

        public IAttendingLectureRepository GetAttendingLectureRepository()
        {
            return new AttendingLectureRepository(_context, _logger);
        }

        public IHomeWorkRepository GetHomeWorkRepository()
        {
            return new HomeWorkRepository(_context, _logger);
        }

        public ILectureRepository GetLectureRepository()
        {
            return new LectureRepository(_context, _logger);
        }

        public ILecturerRepository GetLecturerRepository()
        {
            return new LecturerRepository(_context, _logger);
        }

        public IStudentRepository GetStudentRepository()
        {
            return new StudentRepository(_context, _logger);
        }


    }
}

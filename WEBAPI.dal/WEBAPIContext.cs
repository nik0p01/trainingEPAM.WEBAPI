using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WEBAPI.DAL.Entities;


namespace WEBAPI.DAL
{
    public class WEBAPIContext : DbContext
    {

        private readonly ILogger<WEBAPIContext> _logger;
        public WEBAPIContext(DbContextOptions<WEBAPIContext> options, ILogger<WEBAPIContext> logger) : base(options)
        {
            _logger = logger;
            try
            {
                Database.EnsureCreated();
            }
            catch (SqlException e)
            {
                _logger.LogError(e, e.Message);
                throw;
            }
        }


        public DbSet<Student> Students { get; set; }
        public DbSet<AttendingLecture> AttendingLectures { get; set; }
        public DbSet<HomeWork> HomeWorks { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }

    }

}

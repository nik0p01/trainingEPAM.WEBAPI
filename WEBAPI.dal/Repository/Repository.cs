using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;

namespace WEBAPI.DAL.Repository
{
    abstract public class Repository : IDisposable
    {
        protected WEBAPIContext _context;
        private readonly ILogger<EducationRepository> _logger;
        public Repository(WEBAPIContext context, ILogger<EducationRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public void Save()
        {



            try
            {
                _context.SaveChanges();
            }
            catch (SqlException e)
            {
                _logger.LogError(e, e.Message);
                throw;
            }

        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

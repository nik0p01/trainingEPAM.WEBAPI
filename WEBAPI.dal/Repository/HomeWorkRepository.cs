using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WEBAPI.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace WEBAPI.DAL.Repository
{
    public class HomeWorkRepository : Repository, IHomeWorkRepository
    {
        public HomeWorkRepository(WEBAPIContext context, ILogger<EducationRepository> logger) : base(context, logger)
        {

        }
        public void DeleteHomeWork(int homeWorkID)
        {
            HomeWork homeWork = _context.HomeWorks.Where(hw => hw.ID == homeWorkID).FirstOrDefault();
            _context.HomeWorks.Remove(homeWork);
        }

        public IEnumerable<HomeWork> GetHomeWorks()
        {
            return _context.HomeWorks.ToList();
        }

        public HomeWork GetHomeWorkByID(int homeWorkID)
        {
            return _context.HomeWorks.Where(s => s.ID == homeWorkID).FirstOrDefault();
        }

        public void InsertHomeWork(HomeWork homeWork)
        {
            _context.HomeWorks.Add(homeWork);
        }

        public void UpdateHomeWork(HomeWork homeWork)
        {
            _context.Entry(homeWork).State = EntityState.Modified;
        }
    }
}

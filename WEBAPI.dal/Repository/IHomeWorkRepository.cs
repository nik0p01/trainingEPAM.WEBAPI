using WEBAPI.DAL.Entities;
using System.Collections.Generic;

namespace WEBAPI.DAL.Repository
{
    public interface IHomeWorkRepository
    {
        IEnumerable<HomeWork> GetHomeWorks();
        HomeWork GetHomeWorkByID(int homeWorkID);
        void InsertHomeWork(HomeWork homeWork);
        void DeleteHomeWork(int homeWorkID);
        void UpdateHomeWork(HomeWork homeWork);
        void Save();
    }
}

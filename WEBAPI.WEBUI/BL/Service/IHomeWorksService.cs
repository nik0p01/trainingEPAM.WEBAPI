using WEBAPI.BL.Entities;
using System.Collections.Generic;

namespace WEBAPI.WEBUI.BL.Service
{
    public interface IHomeWorksService
    {
        IEnumerable<HomeWorkBL> GetHomeWorks();
        HomeWorkBL GetHomeWorkByID(int homeWorkID);
        void InsertHomeWork(HomeWorkBL homeWork);
        void DeleteHomeWork(int homeWorkID);
        void UpdateHomeWork(HomeWorkBL homeWork);

    }
}

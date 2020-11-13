using AutoMapper;
using Microsoft.Extensions.Logging;
using WEBAPI.BL.Entities;
using WEBAPI.DAL.Repository;
using WEBAPI.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace WEBAPI.WEBUI.BL.Service
{
    public class HomeWorksService : IHomeWorksService
    {

        private readonly IHomeWorkRepository _homeWorkRepository;
        private readonly ILogger<HomeWorksService> _logger;
        private readonly IMapper _mapper;

        public HomeWorksService(IEducationRepository educationRepository, ILogger<HomeWorksService> logger, IMapper mapper)
        {
            _homeWorkRepository = educationRepository.GetHomeWorkRepository();
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<HomeWorkBL> GetHomeWorks()
        {

            var lisHomeWork = new List<HomeWorkBL>();
            _homeWorkRepository.GetHomeWorks().ToList().ForEach(a => lisHomeWork.Add(_mapper.Map<HomeWorkBL>(a)));
            return lisHomeWork;

        }

        public HomeWorkBL GetHomeWorkByID(int homeWorkID)
        {
            return _mapper.Map<HomeWorkBL>(_homeWorkRepository.GetHomeWorks().Where(s => s.ID == homeWorkID).FirstOrDefault());
        }

        public void InsertHomeWork(HomeWorkBL homeWork)
        {

            _homeWorkRepository.InsertHomeWork(_mapper.Map<HomeWork>(homeWork));
            _homeWorkRepository.Save();
        }

        public void DeleteHomeWork(int homeWorkID)
        {
            _homeWorkRepository.DeleteHomeWork(homeWorkID);
            _homeWorkRepository.Save();
        }

        public void UpdateHomeWork(HomeWorkBL homeWork)
        {

            _homeWorkRepository.UpdateHomeWork(_mapper.Map<HomeWork>(homeWork));
            _homeWorkRepository.Save();
        }

    }
}

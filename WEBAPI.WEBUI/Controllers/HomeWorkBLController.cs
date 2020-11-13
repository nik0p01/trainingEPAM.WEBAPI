using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WEBAPI.BL.Entities;
using WEBAPI.WEBUI.BL.Service;
using System.Collections.Generic;

namespace WEBAPI.WEBUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeWorkBLController : ControllerBase
    {
        private readonly IHomeWorksService _homeWorkService;
        private readonly ILogger<HomeWorkBLController> _logger;

        public HomeWorkBLController(IHomeWorksService homeWorkService, ILogger<HomeWorkBLController> logger)//
        {
            _homeWorkService = homeWorkService;
            _logger = logger;
            _logger.LogInformation("Index page says hello");
        }

        // GET: api/HomeWorkBL
        [HttpGet]
        public IEnumerable<HomeWorkBL> Get()
        {
            return _homeWorkService.GetHomeWorks();
        }

        // GET: api/HomeWorkBL/5
        [HttpGet("{id}")]//, Name = "Get"
        public HomeWorkBL Get(int id)
        {
            return _homeWorkService.GetHomeWorkByID(id);
        }

        // POST: api/HomeWorkBL
        [HttpPost]
        public void Post(HomeWorkBL homeWorkBL)//[FromBody]
        {
            _homeWorkService.InsertHomeWork(homeWorkBL);
        }

        // PUT: api/HomeWorkBL/5
        [HttpPut("{id}")]
        public void Put(int id, HomeWorkBL homeWork)//[FromBody]
        {
            homeWork.ID = id;
            _homeWorkService.UpdateHomeWork(homeWork);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void DeleteHomeWork(int id)
        {
            _homeWorkService.DeleteHomeWork(id);
        }
    }
}

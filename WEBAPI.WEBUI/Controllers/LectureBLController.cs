using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WEBAPI.BL.Entities;
using WEBAPI.WEBUI.BL.Service;
using System.Collections.Generic;


namespace WEBAPI.WEBUI.Controllers
{
    namespace WEBAPI.WEBUI.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class LectureBLController : ControllerBase
        {


            private readonly ILecturesService _lectureService;
            private readonly ILogger<LectureBLController> _logger;

            public LectureBLController(ILecturesService lectureService, ILogger<LectureBLController> logger)//
            {
                _lectureService = lectureService;
                _logger = logger;
                _logger.LogInformation("Index page says hello");
            }

            // GET: api/LectureBL
            [HttpGet]
            public IEnumerable<LectureBL> Get()
            {
                return _lectureService.GetLectures();
            }

            // GET: api/LectureBL/5
            [HttpGet("{id}")]
            public LectureBL Get(int id)
            {
                return _lectureService.GetLectureByID(id);
            }

            // POST: api/LectureBL
            [HttpPost]
            public void Post(LectureBL lectureBL)
            {
                _lectureService.InsertLecture(lectureBL);
            }

            // PUT: api/LectureBL/5
            [HttpPut("{id}")]
            public void Put(int id, LectureBL lecture)
            {
                lecture.ID = id;
                _lectureService.UpdateLecture(lecture);
            }

            // DELETE: api/ApiWithActions/5
            [HttpDelete("{id}")]
            public void DeleteLecture(int id)
            {
                _lectureService.DeleteLecture(id);
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WEBAPI.BL.Entities;
using WEBAPI.WEBUI.BL.Service;
using System.Collections.Generic;

namespace WEBAPI.WEBUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendingLectureBLController : ControllerBase
    {
        private readonly IAttendingLecturesService _attendingLectureService;
        private readonly ILogger<AttendingLectureBLController> _logger;
        public AttendingLectureBLController(IAttendingLecturesService attendingLectureService, ILogger<AttendingLectureBLController> logger)//
        {
            _attendingLectureService = attendingLectureService;
            _logger = logger;

        }

        // GET: api/AttendingLectureBL
        [HttpGet]
        public IEnumerable<AttendingLectureBL> Get()
        {
            return _attendingLectureService.GetAttendingLectures();
        }

        // GET: api/AttendingLectureBL/5
        [HttpGet("{id}")]//, Name = "Get"
        public AttendingLectureBL Get(int id)
        {
            return _attendingLectureService.GetAttendingLectureByID(id);
        }

        // POST: api/AttendingLectureBL
        [HttpPost]
        public void Post(AttendingLectureBL attendingLectureBL)//[FromBody]
        {
            _attendingLectureService.InsertAttendingLecture(attendingLectureBL);
        }

        // PUT: api/AttendingLectureBL/5
        [HttpPut("{id}")]
        public void Put(int id, AttendingLectureBL attendingLecture)//[FromBody]
        {
            attendingLecture.ID = id;
            _attendingLectureService.UpdateAttendingLecture(attendingLecture);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void DeleteAttendingLecture(int id)
        {
            _attendingLectureService.DeleteAttendingLecture(id);
        }
    }
}

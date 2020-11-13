using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WEBAPI.BL.Entities;
using WEBAPI.WEBUI.BL.Service;
using System.Collections.Generic;

namespace WEBAPI.WEBUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LecturerBLController : ControllerBase
    {
        private readonly ILecturersService _lecturerService;
        private readonly ILogger<LecturerBLController> _logger;

        public LecturerBLController(ILecturersService lecturerService, ILogger<LecturerBLController> logger)//
        {
            _lecturerService = lecturerService;
            _logger = logger;
            _logger.LogInformation("Index page says hello");
        }

        // GET: api/LecturerBL
        [HttpGet]
        public IEnumerable<LecturerBL> Get()
        {
            return _lecturerService.GetLecturers();
        }

        // GET: api/LecturerBL/5
        [HttpGet("{id}")]
        public LecturerBL Get(int id)
        {
            return _lecturerService.GetLecturerByID(id);
        }

        // POST: api/LecturerBL
        [HttpPost]
        public void Post(LecturerBL lecturerBL)
        {
            _lecturerService.InsertLecturer(lecturerBL);
        }

        // PUT: api/LecturerBL/5
        [HttpPut("{id}")]
        public void Put(int id, LecturerBL lecturer)
        {
            lecturer.ID = id;
            _lecturerService.UpdateLecturer(lecturer);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void DeleteLecturer(int id)
        {
            _lecturerService.DeleteLecturer(id);
        }
    }
}

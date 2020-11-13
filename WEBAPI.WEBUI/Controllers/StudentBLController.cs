using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WEBAPI.BL.Entities;
using WEBAPI.WEBUI.BL.Service;
using System.Collections.Generic;

namespace WEBAPI.WEBUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentBLController : ControllerBase
    {


        private readonly IStudentsService _studentService;
        private readonly ILogger<StudentBLController> _logger;

        public StudentBLController(IStudentsService studentService, ILogger<StudentBLController> logger)
        {
            _studentService = studentService;
            _logger = logger;
            _logger.LogInformation("Run_StudentBLController");
        }

        // GET: api/StudentBL
        [HttpGet]
        public IEnumerable<StudentBL> Get()
        {
            return _studentService.GetStudents();
        }

        // GET: api/StudentBL/5
        [HttpGet("{id}")]
        public StudentBL Get(int id)
        {
            return _studentService.GetStudentByID(id);
        }

        // POST: api/StudentBL
        [HttpPost]
        public void Post(StudentBL studentBL)
        {
            _studentService.InsertStudent(studentBL);
        }

        // PUT: api/StudentBL/5
        [HttpPut("{id}")]
        public void Put(int id, StudentBL student)
        {
            student.ID = id;
            _studentService.UpdateStudent(student);
        }

        // DELETE: api/StudentBL/5
        [HttpDelete("{id}")]
        public void DeleteStudent(int id)
        {
            _studentService.DeleteStudent(id);
        }
    }
}

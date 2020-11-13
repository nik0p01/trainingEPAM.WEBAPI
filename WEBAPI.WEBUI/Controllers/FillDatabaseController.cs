using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WEBAPI.BL;
using WEBAPI.DAL.Repository;

namespace WEBAPI.WEBUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FillDatabaseController : ControllerBase
    {
        private readonly IEducationRepository _educationRepository;
        private readonly ILogger<FillDatabaseController> _logger;


        public FillDatabaseController(IEducationRepository educationRepository, ILogger<FillDatabaseController> logger)//
        {
            _educationRepository = educationRepository;
            _logger = logger;

        }
        [HttpGet]
        public void FillDatabase()
        {
            FillDatabase fillDatabase = new FillDatabase(_educationRepository);
            fillDatabase.FillDatabaseTestData();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WEBAPI.BL.Reports;
using WEBAPI.DAL.Repository;

namespace WEBAPI.WEBUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarningSenderController : ControllerBase
    {

        private readonly IEducationRepository _educationRepository;
        private readonly ILogger<WarningSenderController> _logger;
        private readonly GetDataForWarning _getDataForWarning;
        private readonly ISendWarning _sendWarning;
        public WarningSenderController(IEducationRepository educationRepository, ILogger<WarningSenderController> logger, GetDataForWarning getDataForWarning, ISendWarning sendWarning)//
        {
            _educationRepository = educationRepository;
            _logger = logger;
            _getDataForWarning = getDataForWarning;
            _sendWarning = sendWarning;
        }

        [HttpGet]
        public void SendAllWarnings()
        {
            _sendWarning.MakeReports += SendToEMailStu.SendWarning;
            _sendWarning.SendWarningToStudents(_getDataForWarning.AverageMarkLimit(4));
            _sendWarning.MakeReports -= SendToEMailStu.SendWarning;
            _sendWarning.MakeReports += SendToSMS.SendWarning;
            _sendWarning.SendWarningToStudents(_getDataForWarning.GetStudentsPasses(3));
            _sendWarning.MakeReports -= SendToSMS.SendWarning;
        }

    }
}
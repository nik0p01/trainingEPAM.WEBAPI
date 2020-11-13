using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WEBAPI.DAL.Repository;
using WEBAPI.WEBUI.BL.Exceptions;
using WEBAPI.WEBUI.BL.Reports;
using System.Collections.Generic;
using System.Linq;

namespace WEBAPI.WEBUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IEducationRepository _educationRepository;
        private readonly ILogger _logger;
        private readonly IEnumerable<IReportSaver> _reportSavers;

        public ReportController(IEducationRepository educationRepository, ILogger<ReportController> logger, IEnumerable<IReportSaver> reportSavers)//
        {
            _educationRepository = educationRepository;
            _logger = logger;
            _reportSavers = reportSavers.ToList();
        }


        [HttpGet]
        public void CreateReport(string name, string typeReport, string outType)
        {
            GetDataForReport getDataForReport = new GetDataForReport(_educationRepository, _logger);
            var dataForReport = getDataForReport.GetData(typeReport, name);
            MakeReportClass makeReportClass = new MakeReportClass();

            bool typeReportIsCorrect = false;
            foreach (var reportSaver in _reportSavers)
            {
                if (outType == reportSaver.Type)
                {
                    typeReportIsCorrect = true;
                    makeReportClass.makeReportDelegat += reportSaver.SendReport;
                }
            }


            if (!typeReportIsCorrect)
            {
                var exaption = new WrongReportOutputTypeException(outType);

                _logger.LogWarning("Not support report type", exaption);
                throw exaption;
            }

            makeReportClass.MakeReport(dataForReport);
        }
    }
}

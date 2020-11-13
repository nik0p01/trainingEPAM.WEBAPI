using Microsoft.Extensions.Logging;
using WEBAPI.BL.Entities;
using System.Collections.Generic;

namespace WEBAPI.BL.Reports
{
    public class SendWarning : ISendWarning
    {
        private ILogger _logger;

        public ISendWarning.MakeReportDelegat MakeReports { get; set; }

        public SendWarning(ILogger<ISendWarning> logger)
        {
            _logger = logger;
            _logger.LogInformation("Run " + this.GetType());
        }

        public void SendWarningToStudents(ICollection<StudentBL> students)
        {
            foreach (var student in students)
            {
                MakeReports?.Invoke(student, _logger);
            }

        }


    }
}
using Microsoft.Extensions.Logging;
using WEBAPI.BL.Entities;
using System.Collections.Generic;

namespace WEBAPI.BL.Reports
{
    public interface ISendWarning

    {
        public delegate void MakeReportDelegat(StudentBL student, ILogger logger);
        public MakeReportDelegat MakeReports { get; set; }
        public void SendWarningToStudents(ICollection<StudentBL> students);
    }
}
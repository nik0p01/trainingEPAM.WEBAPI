using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;


namespace WEBAPI.WEBUI.BL.Reports
{
    public class ReportToJsonFile : IReportSaver
    {
        public ReportToJsonFile()
        {
            Type = "json";
        }

        public string Type { get; private set; }

        public void SendReport(ICollection<LineOfReport> linesOfReport)
        {
            string json = JsonSerializer.Serialize<List<LineOfReport>>(linesOfReport.ToList());
            File.WriteAllText("report.json", json);
        }
    }
}

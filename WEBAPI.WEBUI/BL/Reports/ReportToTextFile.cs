
using System;
using System.Collections.Generic;
using System.IO;

namespace WEBAPI.WEBUI.BL.Reports
{
    public class ReportToTextFile : IReportSaver
    {
        public ReportToTextFile()
        {
            Type = "txt";
        }

        public string Type { get; private set; }

        public void SendReport(ICollection<LineOfReport> linesOfReport)
        {
            string report = $"# |Lecture|Student|Attending{Environment.NewLine}";
            int counter = 0;
            foreach (var line in linesOfReport)
            {
                counter += 1;
                report += $"{counter}|{line.Lecture}|{line.StudentName}|{line.AttendingLecture}{Environment.NewLine}";
            }
            File.WriteAllText("report.txt", report);
        }
    }
}

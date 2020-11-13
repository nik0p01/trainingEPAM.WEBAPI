using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace WEBAPI.WEBUI.BL.Reports
{
    public class ReportToXmlFile : IReportSaver
    {
        public ReportToXmlFile()
        {
            Type = "xml";
        }

        public string Type { get; private set; }

        public void SendReport(ICollection<LineOfReport> linesOfReport)
        {

            XmlSerializer formatter = new XmlSerializer(typeof(List<LineOfReport>));
            using (FileStream fs = new FileStream("report.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, linesOfReport.ToList());
            }
        }
    }
}

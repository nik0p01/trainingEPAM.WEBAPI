using System.Collections.Generic;

namespace WEBAPI.WEBUI.BL.Reports
{
    public interface IReportSaver
    {
        string Type { get; }
        void SendReport(ICollection<LineOfReport> linesOfReport);
    }
}

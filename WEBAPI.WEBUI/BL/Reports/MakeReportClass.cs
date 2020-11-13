using System.Collections.Generic;

namespace WEBAPI.WEBUI.BL.Reports
{
    public class MakeReportClass
    {
        public delegate void MakeReportDelegat(ICollection<LineOfReport> linesOfReport);
        public MakeReportDelegat makeReportDelegat;
        public void MakeReport(ICollection<LineOfReport> linesOfReport)
        {
            makeReportDelegat?.Invoke(linesOfReport);
        }



    }
}
using System;

namespace WEBAPI.WEBUI.BL.Reports
{
    [Serializable]
    public class LineOfReport
    {
        public string Lecture { get; set; }
        public string StudentName { get; set; }
        public bool AttendingLecture { get; set; }
    }
}
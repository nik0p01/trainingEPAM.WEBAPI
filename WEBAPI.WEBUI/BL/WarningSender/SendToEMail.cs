
using Microsoft.Extensions.Logging;
using WEBAPI.BL.Entities;

namespace WEBAPI.BL.Reports
{
    public class SendToEMailStu
    {
        public static void SendWarning(StudentBL student, ILogger logger)
        {
            string sendStr = student.EMail + student.FullName + "message";
            logger.LogInformation(sendStr);
        }
    }
}

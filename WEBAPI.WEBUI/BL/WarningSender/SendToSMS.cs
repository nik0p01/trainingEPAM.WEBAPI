using Microsoft.Extensions.Logging;
using WEBAPI.BL.Entities;

namespace WEBAPI.BL.Reports
{
    public class SendToSMS
    {
        public static void SendWarning(StudentBL student, ILogger logger)
        {
            string sendStr = student.Phone + student.FullName + "message";
            logger.LogInformation(sendStr);
        }
    }
}

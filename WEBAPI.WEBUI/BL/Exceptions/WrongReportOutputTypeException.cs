using System;

namespace WEBAPI.WEBUI.BL.Exceptions
{
    [Serializable]
    public class WrongReportOutputTypeException : ApplicationException
    {
        public WrongReportOutputTypeException() : base()
        {
        }

        public WrongReportOutputTypeException(string message) : base(message)
        {
        }

        public WrongReportOutputTypeException(string message, Exception inner) : base(message, inner)
        {
        }

    }
}

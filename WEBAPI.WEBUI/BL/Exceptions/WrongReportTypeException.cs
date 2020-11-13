using System;

namespace WEBAPI.WEBUI.BL.Exceptions
{
    [Serializable]
    class WrongReportTypeException : Exception
    {
        public WrongReportTypeException() : base()
        {
        }

        public WrongReportTypeException(string message) : base(message)
        {
        }

        public WrongReportTypeException(string message, Exception inner) : base(message, inner)
        {
        }
    }

}

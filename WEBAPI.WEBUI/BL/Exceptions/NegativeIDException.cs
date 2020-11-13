using System;

namespace WEBAPI.WEBUI.BL.Exceptions
{
    [Serializable]
    public class NegativeIDException : ApplicationException
    {
        public NegativeIDException() : base()
        {
        }

        public NegativeIDException(string message) : base(message)
        {
        }

        public NegativeIDException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}

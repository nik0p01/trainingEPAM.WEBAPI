using System;

namespace WEBAPI.WEBUI.BL.Exceptions
{
    [Serializable]
    public class WrongEmailException : ApplicationException
    {
        public WrongEmailException() : base()
        {
        }

        public WrongEmailException(string message) : base(message)
        {
        }

        public WrongEmailException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}

using System;

namespace PhoneShop.Exceptions
{
    public class PhoneNotAvailableException : Exception
    {
        public PhoneNotAvailableException()
        {
        }

        public PhoneNotAvailableException(string message) : base(message)
        {
        }

        public PhoneNotAvailableException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
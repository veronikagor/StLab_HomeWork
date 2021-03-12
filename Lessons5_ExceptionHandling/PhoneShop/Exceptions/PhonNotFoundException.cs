#nullable enable
using System;

namespace PhoneShop.Exceptions
{
    public class PhoneNotFoundException : Exception
    {
        public PhoneNotFoundException()
        {
        }

        public PhoneNotFoundException(string? message) : base(message)
        {
        }

        public PhoneNotFoundException(string? message, Exception? inner) : base(message, inner)
        {
        }
        
    }
}
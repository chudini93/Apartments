using System;

namespace Stretto.ConsoleApp.Exceptions
{
    public class InvalidStateException : Exception
    {
        public InvalidStateException(string message) : base(message)
        {

        }
    }
}

using System;

namespace Stretto.ConsoleApp.Exceptions
{
    public class CsvNameAttributeNotFoundException : Exception
    {
        public CsvNameAttributeNotFoundException(string message) : base(message)
        {

        }
    }
}
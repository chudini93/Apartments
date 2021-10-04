using System;

namespace Stretto.ConsoleApp.Attributes
{
    public class CsvName : Attribute
    {
        public CsvName(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
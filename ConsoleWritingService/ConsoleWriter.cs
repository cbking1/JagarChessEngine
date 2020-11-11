using System;
using Contracts;

namespace ConsoleWritingService
{
    public class ConsoleWriter : IOutputWriter
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}

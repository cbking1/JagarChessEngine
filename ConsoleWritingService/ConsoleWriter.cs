using JagarEngineContracts;
using System;

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

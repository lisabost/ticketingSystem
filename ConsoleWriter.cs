using System;
using System.IO;
using System.Collections.Generic;

namespace ticketingSystem
{
    class ConsoleWriter
    {
        public ConsoleWriter() { }

        public void WriteToScreen(string input)
        {
            Console.WriteLine(input);
        }
    }
}
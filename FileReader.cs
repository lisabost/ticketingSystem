using System;
using System.IO;
using System.Collections.Generic;

namespace ticketingSystem
{
    /*
    This class is going to read our file
    */
    class FileReader
    {
        //fields
        private static string _filepath = "tickets.txt";
        StreamReader sr = new StreamReader(_filepath);

        //method to find the total number of lines in the file
        public int TotalLines()
        {
            using (sr)
            {
                int i = 0;
                while (sr.ReadLine() != null) { i++; }
                return i;
            }
        }


    }
}
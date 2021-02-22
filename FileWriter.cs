using System;
using System.IO;
using System.Collections.Generic;

namespace ticketingSystem
{
    /*
    This class is going to write to our file
    */
    class FileWriter
    {
        //fields
        private static string _filepath = "tickets.txt";

        //constructor
        public FileWriter(){}

        //methods
        public void WriteToFile(Ticket input)
        {
            StreamWriter sw = new StreamWriter(_filepath, append: true);
            sw.WriteLine($"{input.GetTicketNum()},{input.GetSummary()},{input.GetStatus()},{input.GetPriority()},{input.GetSubmitter()},{input.GetAssigned()},{input.GetWatching()}");
            sw.Close();
        }
    }
}
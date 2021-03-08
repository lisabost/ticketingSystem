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
            sw.WriteLine($"{input.ticketNum},{input.summary},{input.status},{input.priority},{input.submitter},{input.assigned},{input.watching}");
            sw.Close();
        }

        public void WriteBugToFile(BugDefect input)
        {
            StreamWriter sw = new StreamWriter("tickets.txt", append: true);
            sw.WriteLine($"{input.ticketNum},{input.summary},{input.status},{input.priority},{input.submitter},{input.assigned},{string.Join("|", input.watching)},{input.severity}");
            sw.Close();
        }

        public void WriteEnhancementToFile(Enhancement input)
        {
            StreamWriter sw = new StreamWriter("Enhancements.txt", append:true);
            sw.WriteLine($"{input.ticketNum},{input.summary},{input.status},{input.priority},{input.submitter},{input.assigned},{string.Join("|", input.watching)},{input.software},{input.cost},{input.reason},{input.estimate}");
            sw.Close();
        }

        public void WriteTaskToFile(Task input)
        {
            StreamWriter sw = new StreamWriter("Tasks.txt", append:true);
            sw.WriteLine($"{input.ticketNum},{input.summary},{input.status},{input.priority},{input.submitter},{input.assigned},{string.Join("|", input.watching)},{input.projectName},{input.dueDate}");
            sw.Close();
        }
    }
}
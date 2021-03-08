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

        //constructor
        public FileWriter(){}

        //methods
        public void WriteBugToFile(BugDefect input)
        {
            StreamWriter sw = new StreamWriter("Tickets.csv", append: true);
            sw.WriteLine($"{input.ticketNum},{input.summary},{input.status},{input.priority},{input.submitter},{input.assigned},{string.Join("|", input.watching)},{input.severity}");
            sw.Close();
        }

        public void WriteEnhancementToFile(Enhancement input)
        {
            StreamWriter sw = new StreamWriter("Enhancements.csv", append:true);
            sw.WriteLine($"{input.ticketNum},{input.summary},{input.status},{input.priority},{input.submitter},{input.assigned},{string.Join("|", input.watching)},{input.software},{input.cost},{input.reason},{input.estimate}");
            sw.Close();
        }

        public void WriteTaskToFile(Task input)
        {
            StreamWriter sw = new StreamWriter("Tasks.csv", append:true);
            sw.WriteLine($"{input.ticketNum},{input.summary},{input.status},{input.priority},{input.submitter},{input.assigned},{string.Join("|", input.watching)},{input.projectName},{input.dueDate}");
            sw.Close();
        }
    }
}
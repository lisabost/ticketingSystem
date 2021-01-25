using System;
using System.IO;

namespace ticketingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "tickets.txt";
            string choice;
            //get current ticketNum from file based on number of tickets already assinged
            int ticketNum = TotalLines(file);

            //read the number of lines in the text file to not reuse ticket numbers
            int TotalLines(string filePath)
            {
                using (StreamReader r = new StreamReader(filePath))
                {
                    int i = 0;
                    while (r.ReadLine() != null) { i++; }
                    return i;
                }
            }
            do
            {
                Console.WriteLine("1) Enter a new ticket");
                Console.WriteLine("2) See previously entered tickets");
                Console.WriteLine("Enter or any key to exit");
                choice = Console.ReadLine();

                //choice 1: enter new tickets
                if (choice == "1")
                {
                    //create new file from data - if old file exists, append new data to existing file
                    StreamWriter sw = new StreamWriter(file, append: true);

                    //find out how many tickets they want to enter
                    Console.WriteLine("How many tickets do you have to enter?");
                    int ticketNumber = int.Parse(Console.ReadLine());

                    for (int x = 0; x < ticketNumber; x++)
                    {
                        //assign ticket number
                        ticketNum++;
                        //summary
                        Console.WriteLine("Enter ticket {0} summary", x + 1);
                        string prob = Console.ReadLine();
                        //status
                        Console.WriteLine("Enter the ticket's status");
                        string status = Console.ReadLine();
                        //priortiy
                        Console.WriteLine("Enter the ticket's priorty");
                        string priortiy = Console.ReadLine();
                        //submitter
                        Console.WriteLine("Enter the ticket's submitter");
                        string sub = Console.ReadLine();
                        //assigned
                        Console.WriteLine("Who is assigned to this ticket");
                        string assigned = Console.ReadLine();
                        //watching - can be multiple people
                        Console.WriteLine("How many people are watching this ticket?");
                        int numWatching = int.Parse(Console.ReadLine());
                        string[] watching = new string[numWatching];
                        for (int i = 0; i < numWatching; i++)
                        {
                            Console.WriteLine("Who is watching this ticket");
                            watching[i] = Console.ReadLine();
                        }
                        sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}", ticketNum, prob, status, priortiy, sub, assigned, string.Join("|", watching));
                    }
                    sw.Close();
                }
                else if (choice == "2")
                {
                    //make sure the file exists
                    if (File.Exists(file))
                    {
                        // read data from file
                        StreamReader sr = new StreamReader(file);
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            // convert string to array
                            string[] arr = line.Split(',');
                            // display array data
                            Console.WriteLine("Ticket Number: {0}, Summary: {1}, Status: {2}, Priority: {3}, Submitter: {4}, Assigned: {5}, Watching: {6}", arr[0], arr[1],
                            arr[2], arr[3], arr[4], arr[5], arr[6].Replace("|", ", "));
                        }
                        sr.Close();
                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                }
            }
            while (choice == "1" || choice == "2");
        }
    }
}

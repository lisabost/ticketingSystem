using System;
using System.IO;
using System.Collections.Generic;

namespace ticketingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "tickets.txt";
            string choice;

            FileReader fr = new FileReader();
            
            //get current ticketNum from file based on number of tickets already assinged
            int ticketNum = fr.TotalLines();
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
                    FileWriter fw = new FileWriter();

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
                        string priority = Console.ReadLine();
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
                        //make a ticket
                        Ticket ticket = new Ticket(ticketNum++, prob, status, priority, sub, assigned, string.Join("|", watching));
                        fw.WriteToFile(ticket);
                    }
                }
                else if (choice == "2")
                {
                    //make sure the file exists
                    if (File.Exists(file))
                    {
                        //get tickets from FileReader
                        List<Ticket> ticketsInFile = fr.ReadAll();
                        foreach (var item in ticketsInFile)
                        {
                            Console.WriteLine(item);
                        }
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

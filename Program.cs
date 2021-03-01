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
            ConsoleWriter cw = new ConsoleWriter();
            ConsoleReader cr = new ConsoleReader();
            
            //get current ticketNum from file based on number of tickets already assinged
            int ticketNum = fr.TotalLines();
            do
            {
                cw.WriteToScreen("1) Enter a new ticket");
                cw.WriteToScreen("2) See previously entered tickets");
                cw.WriteToScreen("Enter or any key to exit");
                choice = cr.ReadFromConsole();

                //choice 1: enter new tickets
                if (choice == "1")
                {
                    //create new file from data - if old file exists, append new data to existing file
                    FileWriter fw = new FileWriter();

                    //find out how many tickets they want to enter
                    cw.WriteToScreen("How many tickets do you have to enter?");
                    int ticketNumber = int.Parse(cr.ReadFromConsole());

                    for (int x = 0; x < ticketNumber; x++)
                    {
                        //assign ticket number
                        ticketNum++;
                        //summary
                        cw.WriteToScreen("Enter ticket {0} summary", x + 1);
                        string prob = cr.ReadFromConsole();
                        //status
                        cw.WriteToScreen("Enter the ticket's status");
                        string status = cr.ReadFromConsole();
                        //priortiy
                        cw.WriteToScreen("Enter the ticket's priorty");
                        string priority = cr.ReadFromConsole();
                        //submitter
                        cw.WriteToScreen("Enter the ticket's submitter");
                        string sub = cr.ReadFromConsole();
                        //assigned
                        cw.WriteToScreen("Who is assigned to this ticket");
                        string assigned = cr.ReadFromConsole();
                        //watching - can be multiple people
                        cw.WriteToScreen("How many people are watching this ticket?");
                        int numWatching = int.Parsecr.ReadFromConsole();
                        string[] watching = new string[numWatching];
                        for (int i = 0; i < numWatching; i++)
                        {
                            cw.WriteToScreen("Who is watching this ticket");
                            watching[i] = cr.ReadFromConsole();
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
                            cw.WriteToScreen(item);
                        }
                    }
                    else
                    {
                        cw.WriteToScreen("File does not exist");
                    }
                }
            }
            while (choice == "1" || choice == "2");
        }
    }
}

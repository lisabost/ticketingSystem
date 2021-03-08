using System;
using System.IO;
using System.Collections.Generic;

namespace ticketingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string file;
            string choice;

            FileReader fr = new FileReader();
            ConsoleWriter cw = new ConsoleWriter();
            ConsoleReader cr = new ConsoleReader();

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
                    cw.WriteToScreen("Select the type of ticket.");
                    cw.WriteToScreen("1) Bug or Defect");
                    cw.WriteToScreen("2) Enhancement");
                    cw.WriteToScreen("3) Task");

                    string response = cr.ReadFromConsole();

                    //This stuff is the same for any ticket
                    cw.WriteToScreen("Enter ticket summary");
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
                    List<string> watching = new List<string>();
                    string input;
                    do
                    {
                        cw.WriteToScreen("Enter who is watching (or done to quit)");
                        input = cr.ReadFromConsole();

                        if (input != "done" && input.Length > 0)
                        {
                            watching.Add(input);
                        }
                    } while (input != "done");

                    //Bug/Defect Ticket
                    if (response == "1")
                    {
                        //bug tickets need severity - their ticket numbers come from the tickets.txt file
                        int ticketNumber = fr.TotalLines("tickets.txt") + 1;

                        cw.WriteToScreen("Enter severity of bug or defect");
                        string severity = cr.ReadFromConsole();

                        //make our ticket and write it to the file
                        fw.WriteBugToFile(new BugDefect(ticketNumber, prob, status, priority, sub, assigned, watching, severity));
                    }
                    //Enhancement Ticket
                    else if (response == "2")
                    {
                        //enhancement tickets need software, cost, reason, estimate - their ticket numbers come from Enhancements.txt file
                        int ticketNumber = fr.TotalLines("Enhancements.txt") + 1;

                        cw.WriteToScreen("Enter software needed");
                        string software = cr.ReadFromConsole();

                        cw.WriteToScreen("Enter cost");
                        double cost = double.Parse(cr.ReadFromConsole());

                        cw.WriteToScreen("Enter reason");
                        string reason = cr.ReadFromConsole();

                        cw.WriteToScreen("Enter estimate");
                        string estimate = cr.ReadFromConsole();

                        //make our ticket and write it to the file
                        fw.WriteEnhancementToFile(new Enhancement(ticketNumber, prob, status, priority, sub, assigned, watching, software, cost, reason, estimate));
                    }
                    //Task ticket
                    else if (response == "3")
                    {
                        //task tickets need project name and due date - their ticket numbers come from the Tasks.txt file
                        int ticketNumber = fr.TotalLines("Tasks.txt");

                        cw.WriteToScreen("Enter the project name");
                        string projectName = cr.ReadFromConsole();

                        cw.WriteToScreen("Enter the Due Date as mm/dd/yyyy");
                        DateTime dueDate = DateTime.Parse(cr.ReadFromConsole());

                        //make our ticket and write it to the file
                        fw.WriteTaskToFile(new Task(ticketNumber, prob, status, priority, sub, assigned, watching, projectName, dueDate));
                    }

                }
                else if (choice == "2")
                {
                    //what kind of ticket do they want to see
                    cw.WriteToScreen("Select ticket type");
                    cw.WriteToScreen("1) Bug or Defect");
                    cw.WriteToScreen("2) Enhancement");
                    cw.WriteToScreen("3) Task");

                    string option = cr.ReadFromConsole();

                    //bug defect tickets
                    if (option == "1")
                    {
                        file = "tickets.txt";

                        //make sure the file exists
                        if (File.Exists(file))
                        {
                            //get tickets from FileReader
                            List<Ticket> ticketsInFile = fr.ReadAll();
                            foreach (var item in ticketsInFile)
                            {
                                cw.WriteToScreen(item.Display());
                            }
                        }
                        else
                        {
                            cw.WriteToScreen("File does not exist");
                        }
                    }
                    //enhancement tickets
                    else if (option == "2")
                    {
                        file = "Enhancements.txt";

                        //make sure the file exists
                        if (File.Exists(file))
                        {
                            //get tickets from FileReader
                            List<Ticket> ticketsInFile = fr.ReadAll();
                            foreach (var item in ticketsInFile)
                            {
                                cw.WriteToScreen(item.Display());
                            }
                        }
                        else
                        {
                            cw.WriteToScreen("File does not exist");
                        }
                    }
                    //task tickets
                    else if (option == "3")
                    {
                        file = "Tasks.txt";

                        //make sure the file exists
                        if (File.Exists(file))
                        {
                            //get tickets from FileReader
                            List<Ticket> ticketsInFile = fr.ReadAll();
                            foreach (var item in ticketsInFile)
                            {
                                cw.WriteToScreen(item.Display());
                            }
                        }
                        else
                        {
                            cw.WriteToScreen("File does not exist");
                        }
                    }


                }
            }
            while (choice == "1" || choice == "2");
        }
    }
}

using System;
using System.IO;
using System.Collections.Generic;
using NLog.Web;
using System.Linq;

namespace ticketingSystem
{
    class Program
    {
        //create static instance of logger
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        static void Main(string[] args)
        {
            logger.Info("Program Started");
            string file;
            string choice;

            FileReader fr = new FileReader();
            ConsoleWriter cw = new ConsoleWriter();
            ConsoleReader cr = new ConsoleReader();

            do
            {
                cw.WriteToScreen("1) Enter a new ticket");
                cw.WriteToScreen("2) See previously entered tickets");
                cw.WriteToScreen("3) Search tickets");
                cw.WriteToScreen("Press enter to exit");
                choice = cr.ReadFromConsole();

                //choice 1: enter new tickets
                if (choice == "1")
                {
                    logger.Info("User Choice: 1 - Add ticket");
                    //create new file from data - if old file exists, append new data to existing file
                    FileWriter fw = new FileWriter();

                        //find out what kind of ticket they want to enter
                        cw.WriteToScreen("Select the type of ticket.");
                        cw.WriteToScreen("1) Bug or Defect");
                        cw.WriteToScreen("2) Enhancement");
                        cw.WriteToScreen("3) Task");
                        cw.WriteToScreen("Press enter to exit");

                        string response = cr.ReadFromConsole();

                        logger.Info($"User Choice: {response}");

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
                            if (watching.Count == 0)
                            {
                                watching.Add("(no one is watching)");
                            }
                        } while (input != "done");

                        //Bug/Defect Ticket
                        if (response == "1")
                        {
                            //bug tickets need severity - their ticket numbers come from the tickets.txt file
                            int ticketNumber = fr.TotalLines("Tickets.csv") + 1;

                            cw.WriteToScreen("Enter severity of bug or defect");
                            string severity = cr.ReadFromConsole();

                            //make our ticket and write it to the file
                            fw.WriteBugToFile(new BugDefect(ticketNumber, prob, status, priority, sub, assigned, watching, severity));

                            logger.Info("New Bug/Defect Ticket created");
                        }
                        //Enhancement Ticket
                        else if (response == "2")
                        {
                            //enhancement tickets need software, cost, reason, estimate - their ticket numbers come from Enhancements.txt file
                            int ticketNumber = fr.TotalLines("Enhancements.csv") + 1;

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

                            logger.Info("New Enhancement Ticket created");
                        }
                        //Task ticket
                        else if (response == "3")
                        {
                            //task tickets need project name and due date - their ticket numbers come from the Tasks.txt file
                            int ticketNumber = fr.TotalLines("Tasks.csv") + 1;

                            cw.WriteToScreen("Enter the project name");
                            string projectName = cr.ReadFromConsole();

                            cw.WriteToScreen("Enter the Due Date as mm/dd/yyyy");
                            DateTime dueDate = DateTime.Parse(cr.ReadFromConsole());

                            //make our ticket and write it to the file
                            fw.WriteTaskToFile(new Task(ticketNumber, prob, status, priority, sub, assigned, watching, projectName, dueDate));

                            logger.Info("New Task Ticket created");
                        }
                        else
                        {
                            logger.Info("Invalid choice");
                        }
                }

                else if (choice == "2")
                {
                    logger.Info("User Choice: 2 - Display Tickets");

                    //what kind of ticket do they want to see
                    cw.WriteToScreen("Select ticket type");
                    cw.WriteToScreen("1) Bug or Defect");
                    cw.WriteToScreen("2) Enhancement");
                    cw.WriteToScreen("3) Task");

                    string option = cr.ReadFromConsole();

                    //bug defect tickets
                    if (option == "1")
                    {
                        logger.Info("Read back bug/defect file");
                        file = "tickets.csv";

                        //make sure the file exists
                        if (File.Exists(file))
                        {
                            //get tickets from FileReader
                            List<Ticket> ticketsInFile = fr.ReadAllBugs(file);
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
                        logger.Info("Read back enhancements file");
                        file = "Enhancements.csv";

                        //make sure the file exists
                        if (File.Exists(file))
                        {
                            //get tickets from FileReader
                            List<Ticket> ticketsInFile = fr.ReadAllEnhancements(file);
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
                        logger.Info("Read back tasks file");
                        file = "Tasks.csv";

                        //make sure the file exists
                        if (File.Exists(file))
                        {
                            //get tickets from FileReader
                            List<Ticket> ticketsInFile = fr.ReadAllTasks(file);
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
                else if (choice == "3")
                {
                    logger.Info("User Choice: 3 - Search tickets");

                    string bugFile = "Tickets.csv";
                    string enhanceFile = "Enhancements.csv";
                    string taskFile = "Tasks.csv";

                    List<Ticket> bugsInFile = fr.ReadAllBugs(bugFile);
                    List<Ticket> enhanceInFile= fr.ReadAllEnhancements(enhanceFile);
                    List<Ticket> tasksInFile= fr.ReadAllTasks(taskFile);

                    cw.WriteToScreen("Search by:");
                    cw.WriteToScreen("1) Status");
                    cw.WriteToScreen("2) Priority");
                    cw.WriteToScreen("3) Submitter");

                    var search = cr.ReadFromConsole();

                    if (search == "1")
                    {
                        //search by status
                        cw.WriteToScreen("Enter status");
                        var input = cr.ReadFromConsole().ToLower();

                        var bugStatuses = bugsInFile.Where(b => b.status.ToLower().Contains(input));
                        int bugStatusCount = bugStatuses.Count();

                        var enhanceStatuses = enhanceInFile.Where(e => e.status.ToLower().Contains(input));
                        int enhanceStatusCount = enhanceStatuses.Count();

                        var taskStatuses = tasksInFile.Where(t => t.status.ToLower().Contains(input));
                        int taskStatusCount = taskStatuses.Count();

                        cw.WriteToScreen($"There are {bugStatusCount + enhanceStatusCount + taskStatusCount} tickets with a status of \"{input}\".");
                        foreach (var b in bugStatuses) {
                            cw.WriteToScreen(b.Display());
                        }
                        foreach (var e in enhanceStatuses) {
                            cw.WriteToScreen(e.Display());
                        }
                        foreach (var t in taskStatuses) {
                            cw.WriteToScreen(t.Display());
                        }
                    }
                    else if (search == "2")
                    {
                        //search by priority
                        cw.WriteToScreen("Enter priority");
                        var input = cr.ReadFromConsole().ToLower();

                        var bugPriority = bugsInFile.Where(b => b.priority.ToLower().Contains(input));
                        var bugPriorityCount = bugPriority.Count();

                        var enhancePriority = enhanceInFile.Where(e => e.priority.ToLower().Contains(input));
                        var enhancePriorityCount = enhancePriority.Count();

                        var taskPriority = tasksInFile.Where(t => t.priority.ToLower().Contains(input));
                        var taskPriorityCount = taskPriority.Count();

                        cw.WriteToScreen($"There are {bugPriorityCount + enhancePriorityCount + taskPriorityCount} tickets with a priority of \"{input}\".");
                        foreach (var b in bugPriority) 
                        {
                            cw.WriteToScreen(b.Display());
                        }
                        foreach (var e in enhancePriority)
                        {
                            cw.WriteToScreen(e.Display());
                        }
                        foreach (var t in taskPriority)
                        {
                            cw.WriteToScreen(t.Display());
                        }
                    }
                    else if (search == "3")
                    {
                        //search by submitter
                    }
                }
            }
            while (choice == "1" || choice == "2" || choice == "3");
            logger.Info("Program ended");
        }
    }
}

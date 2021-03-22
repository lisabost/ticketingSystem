using System;
using System.IO;
using System.Collections.Generic;
using NLog.Web;

namespace ticketingSystem
{
    public class Task : Ticket
    {
        //fields - project name, due date
        public string projectName { get; set; }
        public DateTime dueDate { get; set; }
        
        //constructor
        public Task()
        {}

        public Task(int ticketNum, string summary, string status, string priority, string submitter, string assigned, List<string> watching, string projectName, DateTime dueDate)
        {
            this.ticketNum = ticketNum;
            this.summary = summary;
            this.status = status;
            this.priority = priority;
            this.submitter = submitter;
            this.assigned = assigned;
            this.watching = watching;
            this.projectName = projectName;
            this.dueDate = dueDate;
        }

        //methods
        public override string Display()
        {
            return "Task\n" + base.Display() + $"Project Name: {projectName}\nDue Date: {dueDate:d}\n";
        }
    }
}
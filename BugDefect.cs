using System;
using System.IO;
using System.Collections.Generic;
using NLog.Web;

namespace ticketingSystem
{
    public class BugDefect : Ticket
    {
        //fields
        public string severity { get; set; }

        //constructor
        public BugDefect()
        {}
        public BugDefect(int ticketNum, string summary, string status, string priority, string submitter, string assigned, List<string> watching, string severity)
        {
            this.ticketNum = ticketNum;
            this.summary = summary;
            this.status = status;
            this.priority = priority;
            this.submitter = submitter;
            this.assigned = assigned;
            this.watching = watching;
            this.severity = severity;
        }

        //methods
        public override string Display()
        {
            return "Bug/Defect\n" + base.Display() + $"Severity: {severity}\n";
        }
    }
}
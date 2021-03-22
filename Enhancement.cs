using System;
using System.IO;
using System.Collections.Generic;
using NLog.Web;

namespace ticketingSystem
{
    public class Enhancement : Ticket
    {
        //fields - software, cost, reason, estimate
        public string software { get; set; }
        public double cost { get; set; }
        public string reason { get; set; }
        public string estimate { get; set; }

        //constructor
        public Enhancement()
        {}

        public Enhancement(int ticketNum, string summary, string status, string priority, string submitter, string assigned, List<string> watching, string software, double cost, string reason, string estimate)
        {
            this.ticketNum = ticketNum;
            this.summary = summary;
            this.status = status;
            this.priority = priority;
            this.submitter = submitter;
            this.assigned = assigned;
            this.watching = watching;
            this.software = software;
            this.cost = cost;
            this.reason = reason;
            this.estimate = estimate;
        }

        //methods
        public override string Display()
        {
            return "Enhancement\n" + base.Display() + $"Software: {software}\nCost: {cost:C}\nReason: {reason}\nEstimate: {estimate}\n";
        }

        
    }
}
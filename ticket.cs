using System;
using System.IO;
using System.Collections.Generic;

namespace ticketingSystem
{
    public abstract class Ticket
    {
        //ticket fields set to private
        public int ticketNum { get; set; }
        public string summary { get; set; }
        public string status { get; set; }
        public string priority { get; set; }
        public string submitter { get; set; }
        public string assigned { get; set; }
        public List<string> watching { get; set; }

        public virtual string Display()
        {
            return $"Ticket Id: {ticketNum}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submitter}\nAssigned: {assigned}\nWatching: {string.Join(", ", watching)}\n";
        }

    }

}
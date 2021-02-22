using System;
using System.IO;
using System.Collections.Generic;

namespace ticketingSystem
{
    class Ticket
    {
        //ticket fields set to private
        private int _ticketNum;
        private string _summary;
        private string _status;
        private string _priority;
        private string _submitter;
        private string _assigned;
        private string _watching;

        //constructor
        public Ticket(){}

        public Ticket(int ticketNum, string summary, string status, string priority, string submitter, string assigned, string watching)
        {
            this._ticketNum = ticketNum;
            this._summary = summary;
            this._status = status;
            this._priority = priority;
            this._submitter = submitter;
            this._assigned = assigned;
            this._watching = watching;
        }

        //methods - getters and setters
        public string ticketNum
        {
            get; set;
        }
        public string Summary
        {
            get; set;
        }
        public string Status
        {
            get; set;
        }
        public string Priortiy
        {
            get; set;
        }
        public string Submitter
        {
            get; set;
        }
        public string[] Watching
        {
            get; set;
        }

        //override the ToString
        public override string ToString()
        {
            return "Ticket Number:" + this._ticketNum + ", Summary: " + this._summary + ", Status: " 
            + this._status + ", Priority: " + this._priority + ", Submitter: " +  this._submitter + ", Assigned: " 
            + this._assigned + ", Watching: " + this._watching;
        }
    }

}
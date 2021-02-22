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
        private string _watching;

        //constructor
        public Ticket(){}

        public Ticket(string ticketNum, string summary, string status, string priority, string submitter, string watching)
        {
            this._ticketNum = int.Parse(ticketNum);
            this._summary = summary;
            this._status = status;
            this._priority = priority;
            this._submitter = submitter;
            this._watching = watching;
        }

        //methods
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
        public string Watcher
        {
            get; set;
        }
    }

}
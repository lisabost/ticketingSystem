using System;
using System.IO;
using System.Collections.Generic;

namespace ticketingSystem
{
    class Ticket
    {
        //ticket fields set to private
        private string _ticketNum;
        private string _summary;
        private string _status;
        private string _priority;
        private string _submitter;
        private string[] _watching;

        //constructor
        public Ticket()
        {

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
        public string[] Watcher
        {
            get; set;
        }
    }

}
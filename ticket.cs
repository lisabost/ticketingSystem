using System;
using System.IO;

namespace ticketingSystem
{
    class ticket
    {
        //ticket fields
        private string _summary;
        private string _status;
        private string _priority;
        private string _submitter;
        private string[] _watching;

        //constructor
        public ticket()
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

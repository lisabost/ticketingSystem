using System;
using System.IO;
using System.Collections.Generic;

namespace ticketingSystem
{
    class ticketingSystem
    {
        private List<Ticket> ticketList;

        public void AddTicket(Ticket ticket)
        {
            ticketList.Add(ticket);
        }

        public List<Ticket> GetTickets()
        {
            return ticketList;
        }
    }

}
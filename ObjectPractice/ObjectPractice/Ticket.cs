using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPractice
{
    enum Priority
    {
        Critical,
        HighImportance,
        NonCritical
    }
    class Ticket
    {
        //step 1: declare properties
        public string ClientName { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public bool Resolved { get; set; }
        public DateTime DateEntered { get; set; }
        public DateTime DateResolved { get; set; }

        //step 2. COnstructor
        public Ticket(string clientName, string description, Priority priority)
        {
            this.ClientName = clientName;
            this.Description = description;
            this.Priority = priority;
            this.Resolved = false;
            this.DateEntered = DateTime.Now;
        }

        //STEP 3 methods
        public void ResolveTicket()
        {
            this.Resolved = true;
            this.DateResolved = DateTime.Now;
        }

        public string GetTicketInfo()
        {
            if (Resolved == false)
            {
                return "Client: " + this.ClientName + "/nDescription: " + Description + "/nPriority: " + Priority + "/nResolved: " + this.Resolved;
            }
            else
            {
                return "Client: " + this.ClientName + "/nDescription: " + Description + "/nPriority: " + Priority + "/nResolved: " + this.DateResolved;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a new car
            Car myCar = new Car("Bugatti", "Veyron");
            //Get car info
            myCar.GetInfo();

            //Create a student
            Student Matt = new Student(2065435, "Matt", "Fisher");
            Matt.Courses.Add(new Course("SeedPaths", "A"));
            Matt.Courses.Add(new Course("Life", "A"));
            Matt.Courses.Add(new Course("Females 101", "A"));
            Matt.Courses.Add(new Course("Make Shit Tons of Money 101", "A"));
            //Print info
            Matt.PrintInfo();

            //Tickets
            TicketExample();
            
            Console.ReadKey();
        }

        static void TicketExample()
        {
            //creat new list to hold tickets
            List<Ticket> ticketList = new List<Ticket>();
            //creat new ticket
            Ticket ticket1 = new Ticket("Nicole", "RSVP For Is Brocken", Priority.Critical);
            //let some time pass
            System.Threading.Thread.Sleep(1000);
            //resolved ticket 1
            ticket1.ResolveTicket();
            //add it to list
            ticketList.Add(ticket1);
            //add to more tickets
            ticketList.Add(new Ticket("Pat", "Hockey Stick Is Brocken", Priority.NonCritical));
            ticketList.Add(new Ticket("Logan", "Is Sick today", Priority.HighImportance));
            ticketList.Add(new Ticket("Trai", "Ditched", Priority.Critical));

            //Print ticket info
            Console.WriteLine(string.Join("/n", ticketList.OrderBy(x => x.Priority).Select(x => x.GetTicketInfo())));

        }
    }
}

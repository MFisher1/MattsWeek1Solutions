using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda_Expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            //declare a list of test strings
            List<string> myList = new List<string>() { "Kiwis", "Mangos", "Passion Fruit", "strawberry", "blackberry", "Rassberry", "Starfruit" };
            OrderByExample(myList);
            Console.ReadKey();
        }
        //End of main function
        
        //Functions
        //Example of Order By Lambda expression
        //Order by sorts items in acesding order acording to expression
        //Then By then sorts and tis(for instance if you were ordering by length, and two strings where the same length)
        static void OrderByExample(IEnumerable<string> myList)
        {
            //Order the List by Length and Print them to Console
            List<string> orderedList = myList.OrderBy(x => x.Length).ThenBy(x =>x).ToList();
            Console.WriteLine(string.Join(" , ", orderedList));
           
        }

        //Where Lambda
        //Displays items that meet condition
        static void WhereExample(IEnumerable<string> list)
        {
            //Print all items in that list that contain "berry"
            List<string> berries = list.Where(x => x.Contains("berry")).ToList();
            Console.WriteLine(string.Join(" ,", berries));
            //one line code
            Console.WriteLine(string.Join(" ,", list.Where(x => x.Contains("berry")).ToList()));

        }

        static void DistinctExample()
        {
            List<int> list = new List<int> { 1, 1, 2, 2, 3, 3, 4, 4 };
            Console.WriteLine(string.Join(" ,",list.Distinct()));
        }

        static void FirstAndLastExample(IEnumerable<string> list)
        {
            //we are going to sort the list alaphabetically and 
            //print first and last items
            List<string> sorted = list.OrderBy(x => x).ToList();
            Console.WriteLine(sorted.First());
            Console.WriteLine(sorted.Last());
        }

        static void SkipAndTakeExample(IEnumerable<string> list)
        {
            //print out the 3rd item from list ordered by length
            List<string> skip = list.OrderBy(x => x.Length).ToList();
            Console.WriteLine(list.Skip(2).Take(1).First());
        }
        //End of Functions
    }
}

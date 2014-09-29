using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fun_With_Listz
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare new list of strings for menu
            List<string> myMenu = new List<string>() { "Pizza", "Icecream", "Cake", "Curry" };
            myMenu.Add("Deep Fried Twix");

            //loop through our meny and print each item
            for (int i = 0; i < myMenu.Count; i++)
            {
                Console.WriteLine(myMenu[i]);
            }
            Console.ReadKey();
        }
    }
}

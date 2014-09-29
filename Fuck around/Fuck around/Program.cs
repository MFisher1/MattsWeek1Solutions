using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuck_around
{
    class Program
    {
        static void Main(string[] args)
        {
            //variables
            string inString = "dfsadkjl";
            for (int i = 0; i < inString.Length; i++)
            {
                string selectedLetter = inString[i].ToString();
                Console.Write(selectedLetter);
            }
            Console.ReadKey();
        }
    }
}

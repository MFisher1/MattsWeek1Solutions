using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Root
{
    class Program
    {
        static void Main(string[] args)
        {
            
            DigitalRoot("553244");

            Console.WriteLine("jldfas");
            Console.ReadKey();
        }

        //FUnctions
        static void DigitalRoot(string rootThis)
        {
            //variables
            int result = 0;

            List<char> numlist = rootThis.Select(x => x).ToList();
            if (numlist.Count == 1)
            {
                result = int.Parse(numlist[0].ToString());
            }


            while (numlist.Count() != 1)
            {
                foreach (var item in numlist)
                {
                    result += int.Parse(item.ToString());
                }
                if (numlist.Count > 1)
                {
                    numlist = result.ToString().Select(x => x).ToList();
                }
            }
            
            Console.WriteLine("The Digital Root of " + rootThis + " is " + result);
            
        }

    }
}

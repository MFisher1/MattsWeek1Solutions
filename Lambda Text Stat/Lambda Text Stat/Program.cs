using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda_Text_Stat
{
    class Program
    {
        static void Main(string[] args)
        {
            TextStat("And I told my soul to wait without hope. For hope would be hope for the wrong thing. Wait without love. For love would be love of the wrong thing. There is yet love and hope, but they are all in the waiting. Wait without thought for you are not ready for thought. And in the darkness there shall be light, and in the stillness dancing");

            Console.ReadKey();
        }

        //Functions

        static void TextStat(string input)
        {
            
            //standardize input
            input = input.ToLower();

            //print # of Letters
            Console.WriteLine("Number of Letters: {0}", input.Length);

            //print # of Words
            Console.WriteLine("Number of Words: {0}", input.Split(' ').Count());

            //Print # of Vowels
            Console.WriteLine("Nuber of Vowles: {0}", input.Where(x => "aeiou".Contains(x)).Count());

            //print # of Consanants
            Console.WriteLine("Number of Consanants: {0}", input.Where(x => !("aeiou".Contains(x))).Count());

            //print # of special characters
            Console.WriteLine("Number of Special Characters: {0}", input.Where(x => !("abcdefghijklmnopqrstuvwxyz".Contains(x))).Count());

            //print longest word
            Console.WriteLine("Longest Word: {0}", input.Split().OrderBy(x => x.Length).Last());

            //print shorest word
            Console.WriteLine("Longest Word: {0}", input.Split().OrderBy(x => x.Length).First());


        }
    }
}

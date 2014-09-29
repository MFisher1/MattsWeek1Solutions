using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1CodingChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            //Call FizzBuzz
            Console.WriteLine("FizzBuzz Function:");
            for (int i = 0; i <= 20; i++)
            {
                FizzBuzz(i);
            }

            for (int i = 92; i >= 72; i--)
            {
                FizzBuzz(i);
            }
            Console.WriteLine("");
            
            //Call Yodaizer 
            Console.WriteLine("Yodaizer Function:");
            Yodaizer("I like coding");
            Console.WriteLine(" ");
            Yodaizer("Racecar backwards is Racecar");
            Console.WriteLine(" ");
            Console.WriteLine("");
            //Call TextStat
            Console.WriteLine("TextStat Function:");
            TextStat("I like cheese! I like cheese! I like cheese! - Tyler the Creator");
            Console.WriteLine("");

            //Call IsPrime
            Console.WriteLine("IsPrime Function:");
            IsPrime(25);
            Console.WriteLine("");
            //Call DashInsert
            Console.WriteLine("DashInsert Function:");
            DashInsert(8675309);

            Console.ReadKey();
        }

        //Functions!!!!
        
        //FizzBuzz Function
        static void FizzBuzz(int number)
        {

            //If Input number is divible by 5 and 3 print FizzBuzz
            if (number % 5 == 0 && number % 3 == 0)
            {
                Console.WriteLine("FizzBuzz");
            }
            //If input number is divisible by 5 print Fizz
            else if (number % 5 == 0)
            {
                Console.WriteLine("Fizz");
            }
            //If input number is divisible by 3 print buzz
            else if (number % 3 == 0)
            {
                Console.WriteLine("Buzz");
            }
           //If none of the above is true print number
            else
            {
                Console.WriteLine(number);
            }
        }
        //End of FizzBuzz
       
        //Yodaizer Function
        //-Prints input string backwards, if string has 3 words print words in reverse
        static void Yodaizer(string strng)
        {

            List<string> list = strng.Split(' ').ToList();
            
            //Are there 3 words?
            //yes
            if (list.Count == 3)
            {
                //Print words in reverse
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    Console.Write(list[i] + ", ");
                }
            }
            //no
            else
            {
                //Print string backwards
                for (int i = strng.Length - 1; i >= 0; i--)
                {
                    Console.Write(strng[i]);
                }
            }
        }
        //End of Yodaizer

        static void TextStat(string input)
        {
            //Find Stats

            //Lists + variables
            List<string> textList = input.Split(' ').ToList();
            //-Might use this if I can figure out how to compare all the items in a list to on variable
            
            string vowels = "aeiou";
            string letters = "abcdefghijklmnopqrstuvwxyz";
            int numVowels = 0;
            int numCons = 0;
            //special character var
            int spesh = 0;
            //word length vars
            string longWord = textList[0];
            string shortWord = textList[0];
            string secLongWord = textList[0];

            //-find if vowel, special, consanant and word length
            for (int i = 0; i < input.Length; i++)
			{
                input.ToLower();
			    //special character?
                if(!(letters.Contains(input[i])))
                {
                    spesh++;
                }
                //vowel?
                if (vowels.Contains(input[i]))
                {
                    numVowels++;
                }
                //must be a consanant
                else
                {
                    numCons++;
                }
			}

            //Find word length
            for (int i = 0; i < textList.Count; i++)
            {
                //Find Longest & second longest Word
                if (textList[i].Length > longWord.Length)
                {
                    secLongWord = longWord;
                    longWord = textList[i];
                }
               
                //Find Shortest Word
                if (textList[i].Length < shortWord.Length)
                {
                    shortWord = textList[i];
                }
            }

            //Print Stats
            Console.WriteLine(input + " has: " + input.Length + " characters, " + textList.Count + " words, " + numVowels + " vowels, " + numCons + " consanants, " + spesh + " and special characters in it." + " The Longest word is '" + longWord + "', the second longest is '" + secLongWord + "' and the shortest is '" + shortWord +"'.");
            
        }
        //End of TextStat

        //Is Prime Function

        //Loops until input L is reached, if i is prime print x, if not print i value.
        static void IsPrime(int L)
        {
            //variables
            int i = 1;
            int j = 1;
            string output = "";

            //Figure out if prime
            //Loop numbers until L is reached
            //see if number i is divisible by anything but itself and 1

            
                for (j = 1; i <= L; j++)
                {
                    //If i is not prime
                    if (i % j == 0 && j != i && i != 1)
                    {
                        output+=i + ", ";
                        j = 1;
                        i++;
                    }
                    //i must be prime
                    else if (j == i)
                    {
                        output += i + " is prime, ";
                        j = 1;
                        i++;
                    }
                }
                Console.WriteLine(output);
            
         }
         //End of IsPrime  

        //DashInsert Function
        //Receive input number and prints with - between all odd numbers
        static void DashInsert(int num)
        {
            //variables
            //-number before current number, since there is no number behind 1st int make numB even so there wont be a dash
            int numB = 2;
            string output = "";

            //loop to see if i and numB are both odd
            foreach (var item in num.ToString())
            {
                Convert.ToInt32(item);
                if (numB % 2 != 0 && num % 2 != 0)
                {
                    output = output + "-" + item;
                }
                else
                {
                    output = output + item;
                }
                numB = item;
             }
            Console.WriteLine(output);
        }
        
        //End of functions

    }
}

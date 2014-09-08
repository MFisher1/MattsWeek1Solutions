using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_2_code_challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            //Call FizzBuzz for 0 -20
            for (int i = 0; i <= 20; i++)
            {
                FizzBuzz(i);
            }

            //Call Letter Counter Function
            LetterCounter("p", "Peter Piper picked a Peck of pickled pePPers");
            LetterCounter("i","I love biscuits and gravy. It's the best breakfast ever!");
            LetterCounter("n", "Never gonna give you up. Never gonna let you down.");
            LetterCounter("s", "Sally sells sea shells by the sea shore. She's from Sussex");

            //Keep Console Open
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

        //Letter Counter
        static void LetterCounter(string letter, string inString)
        {
            //variables
            int instancesOfLetter = 0;
            int lowerCase = 0;
            int upperCase = 0;
            string currentLetter;
            //Make a new variable to represent lower case letter
            string letterLowerC = letter.ToLower();

            //loop through word
            for (int i = 0; i < inString.Length; i++)
            {
                //add current index (index i) to currentLetter string for compatability
                currentLetter = inString[i].ToString(); ;
                
               //does index = letter?, make both lower for comparison
                if (currentLetter.ToLower() == letter.ToLower())
                {
                    //is letter lowercase?
                    if (currentLetter == letterLowerC)
                    {
                        //yes-add 1 to lowerCase variable
                        lowerCase++;
                    }
                    //must be uppercase
                    else
                    {
                        //increase upperCase variable by 1
                        upperCase++;
                    }
                    instancesOfLetter++;

                }
                

            }
            //Write results to console
            Console.WriteLine("Input: " + inString);
            Console.WriteLine("Number of Lowercase " + letter + "'s: " + lowerCase);
            Console.WriteLine("Number of Uppercase " + letter + "'s: " + upperCase);
            Console.WriteLine("Total Number of " + letter + "'s: " + instancesOfLetter);
             
        }
        //End of Letter Counter
    }
}

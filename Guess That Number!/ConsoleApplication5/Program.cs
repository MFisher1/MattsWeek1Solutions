using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            //How do I make the console read what I enter?
            int input = ConsoleInput();
            GuessThatNumber(input);
            
          Console.ReadLine();
        }
        //Functions
        static void GuessThatNumber(int guess)
        {
            //variables
            
            //Previous guess
            int pg = 0;

            //Guess counter
            int gc = 0;
            //Random number generator
            Random rng = new Random();
            int number = rng.Next(1, 100);
            if (guess == number)
            {
                Console.WriteLine("You got it!");
            }
            //Check if guess is "Hot" (within 10 of number)
            else if (Math.Abs(number - guess) <= 10)
            {
                Console.WriteLine("Hot!");
                //Increase Guess counter
                gc++;
                //Change guess to previous guess, so can check if they are getting warmer or colder
                pg = guess;
            }
            
            //Check if guess is "Cold" (further than 90 from number)
            else if (89 < Math.Abs(number - guess))
            {
                Console.WriteLine("Cold");
                //Increase Guess counter
                gc++;
                //Change guess to previous guess, so can check if they are getting warmer or colder
                pg = guess;
            }
            
            //Warm-see if guesses are getting closer
            else if (gc > 1 && Math.Abs(number - pg) > Math.Abs(number - guess))
            {
                Console.WriteLine("Warmer!");
                //Increase Guess counter
                gc++;
                //Change guess to previous guess, so can check if they are getting warmer or colder
                pg = guess;
            }

            //Cold-see if guesses are getting further
            else if (gc > 1 && Math.Abs(number - pg) < Math.Abs(number - guess))
            {
                Console.WriteLine("Colder!");
                //Increase Guess counter
                gc++;
                //Change guess to previous guess, so can check if they are getting warmer or colder
                pg = guess;
            }
            else
            {
              
                Console.WriteLine("Oops, wrong! Try again!");
                //Increase Guess counter
                gc++;
                //Change guess to previous guess, so can check if they are getting warmer or colder
                pg = guess;
            
            }
            
        }

        //FUnction to read console input
        static int ConsoleInput()
        {
            string readLine = Console.ReadLine();
            int input = Convert.ToInt32(readLine);
            return (input);
        }
        //End of Function
    }
}

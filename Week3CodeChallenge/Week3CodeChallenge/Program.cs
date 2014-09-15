using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3CodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            maxPrime(1001);
            Console.WriteLine(FibonacciSequencer(100000000));
            Console.ReadKey();
        }

        //Functions

        //Max Prime Function
        //Loops until input max is reached, if i is prime print x, if not print i value.
        static void maxPrime(int max)
        {
            //variables
            //number being checked for being a prime
            int i = 1;
            //number that checks if i is a prime
            int j = 1;
            //counts how many primes have been recorded
            int prime = 1;
            List<int> output = new List<int>();
            

            //Figure out if prime
            //Loop numbers until prime(prime counter) = max, 
            //see if number i is divisible by anything but itself and 1

             for (j = 1; prime <= max + 1; j++)
                {
                    //If i is not prime
                    if (i % j == 0 && j != i && i != 1)
                    {
                        j = 1;
                        i++;
                    }
                    //i must be prime, add i to output and increase prime counter
                    else if (j == i)
                    {
                        output.Add(i);
                        j = 1;
                        i++;
                        prime++;
                    }

                }
            
            
            //write the last item in output to console
            Console.WriteLine("The " + max + numSuffix(max) + " prime is " + output.Last());

        }
        //end of max prime
          
        //Even FibonacciSequencer
        //Adds values of all fibonacci numbers up to max value
        //figure out sequence by adding the two fibonacci numbers before it, starting with 1 and 2.
        static int FibonacciSequencer(int maxValue)
        {
            //variables
            //current fibonncaci # and previous #
            int currentFib = 2;
            int prevFib = 1;
            int output = 0;
            List<int> evenFib = new List<int>();
            List<int> fibNumbs = new List<int>(1);
           //loop to find fibonnaci #'s up to max
            while (currentFib < maxValue)
            {
                
                currentFib = prevFib + currentFib;
                if (currentFib <= maxValue)
                {
                    fibNumbs.Add(currentFib);
                }
                prevFib = fibNumbs[fibNumbs.Count - 1];
            }
            //add all even fib #'s to a list then add them together to get the output
            evenFib = fibNumbs.Where(x => x % 2 == 0).ToList();
            foreach (var item in evenFib)
            {
                output = output + item;
            }
            return output;
        }


        //figure out the suffix of a number
        static string numSuffix(int num)
        {
            string stringNum = num.ToString();
            if (stringNum.Last().Equals('1'))
            {
                return "st";
            }
            else if (stringNum.Last().Equals('2'))
            {
                return "nd";
            }
            else if (stringNum.Last().Equals('3'))
            {
                return "rd";
            }
            else
            {
                return "th";
            }
            
        }
        //End of numSuffix
     
        //End of Functions
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Disemvowler
{
    class Program
    {
        static void Main(string[] args)
        {
            //Call Disemvoweler function
            Console.WriteLine("Dismevowler: tears the vowels out of sentences...");
            Console.WriteLine("");
            Disemvoweler("Nickleback is definately not my favorite band. I'll code for you, but not I won't lie for you! XP");
            Console.WriteLine("");
            Disemvoweler("How many bears could bear grylls grill if bear grylls could grill bears? Answer: He's bear fricken grylls, he does what he wants.");
            Console.WriteLine("");
            Disemvoweler("I'm a code ninja baby. I make the functions and I make the calls");
            Console.WriteLine("");

            //Call Cashier
            Console.WriteLine("Cashier: We go up to Benjamin Franklin, even if you don't");
            Console.WriteLine("");
            Cashier(455.67);
            Console.WriteLine("");
            Cashier(3.18);
            Console.WriteLine("");
            Cashier(0.99);
            Console.WriteLine("");
            Cashier(12.93);
            Console.WriteLine("");
            Cashier(2347.2123);

            Console.ReadKey();
        }
        //Functions

        //THe Disemvoweler(duh duh duhnn...)
        static void Disemvoweler(string text)
        {
            //variables 
            string vowels = "aeiou";
            string output = "";

            //check if any characters are vowels
            for (int i = 0; i < text.Length; i++)
            {
                //if character isnt a vowel add it to output
                if (!(vowels.Contains(text[i])))
                {
                    output += text[i];
                }
            }
            //after string has been disemvoweled write original and disemvoweled text to console
            Console.WriteLine("Original: " + text);
            Console.WriteLine("Disemvoweled: " + output);

        }
        //End of Disemvoweler FUnction

        

        //Cashier
        static void Cashier(double amount)
        {
            //variables
            double benjamins = 0;
            double fifties = 0;
            double twenties = 0;
            double tens = 0;
            double fives = 0;
            double ones = 0;
            double remainder = 0;
            double quaters = 0;
            double dimes = 0;
            double nickles = 0;
            double pennys = 0;

            //Round to nearest penny
            remainder = Math.Round(amount,2);
            
            //Dollar amount(might write a for loop instead of writting each individual value, but I'd rather sleep..)

            //Hundreds
            benjamins = VariableSum(remainder, 100);
            remainder -= benjamins * 100;
           
            //Fities
            fifties = VariableSum(remainder, 50);
            remainder -= fifties * 50;
           

            //Twenties
            twenties = VariableSum(remainder, 20);
            remainder -= twenties * 20;
            

            //Tens
            tens = VariableSum(remainder, 10);
            remainder -= tens * 10;
           
            //Fives
            fives = VariableSum(remainder, 5);
            remainder -= fives * 5;
            
            //Ones
            ones = VariableSum(remainder, 1);
            remainder -= ones;

            //Change
            //How many quaters?
            quaters = VariableSum(remainder, .25);
            //Find remainder
            remainder -= quaters * .25;

            //Dimes?
            dimes = VariableSum(remainder, .1);
            remainder -= dimes * .1;

            nickles = VariableSum(remainder, .05);
            remainder -= nickles * .05;

            pennys = VariableSum(remainder, .01);
            remainder -= pennys * .01;
          

            
                Console.WriteLine("Your change for " + Math.Round(amount,2) + " is ");
                Console.WriteLine(benjamins + " 100's.");
                Console.WriteLine(fifties + " 50's.");
                Console.WriteLine(twenties + " 20's.");
                Console.WriteLine(tens + " 10's");
                Console.WriteLine(fives + " 5's.");
                Console.WriteLine(ones + " 1's.");
                Console.WriteLine(dimes + " dimes.");
                Console.WriteLine(nickles + " nickles.");
                Console.WriteLine(pennys + " pennies..");
            
        }
        //End of Cashier
        
        //VariableSum Function
        //-Figures out how many times a variable amount goes into a sum
        //-Note: variable = type of bill, or change. Remainder is the amount of the total left.
            //While variable(* amount its worth) is less than the remainder - variable value(*1), increase variable by 1 to figure out how
            // many times the variable goes into the remainder evenly. Subtract variable value(*1)
            //because the variable is increased in the while loop, so it will add an extra value to the variable before the look is ended.
        static double VariableSum(double sum, double value)
        {
            double variable = 0;
            while ((variable * value) < sum - value)
            {
                //Increase variable
                variable++;

            }
            return (variable);
        }
    }
}
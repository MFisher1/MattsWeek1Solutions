using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionPractice
{
    class Program
    {
        static void Main(string[] args)
        {
        //-Start of program

            //Variables
             
            //--Counter
            int c;


            //Call HelloWorld function
            HelloWolrd();

            //Call Greeting function
            Greeting("Matt");

            //Call DoubleIt Function
            int myAgeDoubled = DoubleIt(17);
          
            Console.WriteLine("My age doubled is " + myAgeDoubled);
           
            Console.WriteLine("Double my age doubled is " + DoubleIt(myAgeDoubled));

            //Call Multiply Function
            Console.WriteLine(Multiply(myAgeDoubled, 4));

            //Loop from 1-10 that triples each number
            for (int i = 1; i <= 10; i = i + 1)
            {
                Console.WriteLine(Multiply(i,3));
            }

            //Keep console window open
            Console.ReadKey();

         //-End of program
          } 

        //Functions
        static void HelloWolrd()
        {
            Console.WriteLine("Hello World!!!:)");
        }

        static void Greeting(string name)
        {
            Console.WriteLine("Hello " + name);
        }

        static int DoubleIt(int num)
        {
            return num * 2;
        }

        static int Multiply(int num1, int num2)
        {
            return num1 * num2;
        }
        //-End of functions
    }
}

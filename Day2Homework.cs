using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            // DECLARING VARIABLES
            // 1. Declare a string variable called "myName" and set it equal to your name
            string myName = "Matt";

            // 2. Declare a number varible called "myAge" and set it equal to your age
            int myAge = 17;

            // 3. Declare a boolean value called "myBool" and set it equal to true or false;
            bool myBool = true;

            // 4. Declare a new list of strings called "productsList" and set it equal to "basketball", "baseball glove", "tennis shoes", "hockey puck"
            List<string> productList = new List<string>() { "basketball", "baseball glove", "tennis shoes", "hockey puck" };

            // PRINTING VARIABLES TO THE CONSOLE USING CONSOLE.WRITELINE()
            // 1. Print your name to the console using the format: "My name is <myName> and I'm a beast of a programmer"
            Console.WriteLine("My name is " + myName + " I'm a beast of a programer");

            // 2. Print out your age to the console using the format: "I am <myAge> years awesome."
            Console.WriteLine("I am " + myAge + " years awesome");

            // 3. Print out your boolean value using the format: "I set my boolean value equal to <myBool>"
            Console.WriteLine("I set my boolean value to " + myBool);

            // 4. Using a For loop, print out each value in productsList.
            Console.WriteLine("Product List");
            for (int i = 0; i < productList.Count; i++)
            {
                Console.WriteLine(productList[i]);
            }

           

            // FOR LOOP PRACTICE
            // 1. Create a for loop that prints out the numbers 1 to 10.
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
            }
            // 2. Create a for loop that prints out the numbers 10 to 1.
            for (int i = 10; i >= 1; i--)
            {
                Console.WriteLine(i);
            }

            // 3. Create a for loop that prints out the numbers 10 to 30, only printing the even numbers
            for (int i = 10; i <= 30; i = i + 2)
            {
                Console.WriteLine(i);
            }

            // 4. Create a for loop that prints out the numbers 100 to 75, only printing every 5th number (100, 95, 90, 85, 80, 75)
            for (int i = 100; i >= 75; i += (-5))
            {
                Console.WriteLine(i);
            }

            
            // WHILE LOOP PRACTICE
            
            //Counter
            int c;

            // 1. Create a while loop that prints out the numbers from 1 to 10.
            c = 1;
            while (c <= 10)
            {
                Console.WriteLine(c);
                c++;
            }
            
            // 2. Create a while loop that prints out the numbers from 10 to 1.
            c = 10;
            while (c >= 1)
            {
                Console.WriteLine(c);
                c--;
            }

            // 3. Create a while loop that prints out the numbers from 15 to 30, only printing the even numbers
            c = 15;
            while (c >= 30)
            {
                Console.WriteLine(c);
                c+=2;
            }

            // 4. Create a while loop that prints out the numbers from 100 to 75, only printing every 5th number (100, 95, 90, 85, 80, 75)
            c = 100;
            while (c >= 75)
            {
                Console.WriteLine(c);
                c-=5;
            }

            // 5. Create a while loop that prints out the numbers from 1 to 10 until it reaches one that is divisible by 4.
            bool divby4 = false;
            c = 1;
            while (!(divby4))
            {
                Console.WriteLine(c);
                c++;
                if ((c / 4) == 0)
                {
                    divby4 = true;
                }
            }

            // PUTTING IT TOGETHER
            // Use either FOR or WHILE loops to accomplish the following:
            // 1. Print out the number of letters in your name using the format: "My name, <myName>, has <number of letters> in it."
            Console.WriteLine("My name " + myName + " has " + myName.Length + " letters in it.");

            // 2. Print out the number of items in your list using the format: "My product list has <number of items> in it."
             
            //Lol this is some pretty ridiculous code, but you said use a for loop so I did my best XP 
            
            for (int i = 0; i <= 5; i++)
            {
                if(i == productList.Count)
                {
                    Console.WriteLine("My product list has " + i + " items in it.");
                }
            }
            

            // 3. Print out the number of letters of each item in productsList using the format: "<product> has <number of letters> in it."
            for (int i = 0; i < productList.Count; i++)
            {
                Console.WriteLine(productList[i] + " has " + productList[i].Length);
            }

            // DECLARING AND CALLING FUNCTIONS
            // 1. Create a function called "Greeting" that takes one string parameter called "name".  This function will print "Hello <name>"
                //Below

            // 2. Call the Greeting function by passing in "Geronimo Jackson" as your parameter.
            Greeting("Geronimo Jackson");

            // 3. Call the Greeting function by passing in myName as your parameter.
            Greeting(myName);
             
            // 4. Create a function called "DoubleIt" that takes one integer parameter called "number".  This function will print "<number> doubled is <number * 2>"
                //Bellow

            // 5. Call your DoubleIt Function by passing in 1337 as your parameter.
            DoubleIt(1337);

            // 6. Call your DoubleIt function by passing in myAge as your parameter.
            DoubleIt(myAge);

            // 7. Create a function called "Multiply" that takes two integer parameters called "num1" and "num2".  This function will print "<num1> times <num2> is <num1 * num2>"
                //Bellow

            // 8. Call your Multiply function by passing in 2 and 8 as your parameters.
            Multiply(2, 8);

            // 9. Call your Multiply function by passing in 3 and myAge as your parameters.
            Multiply(3, myAge);

            // 10. Create a function called "LoopThis" that takes two integer parameters called "startNum" and "endNum".  
            //      This function will print out: 
            //          a. "I'm looping from <startNum> to <endNum>."  
            //          b. The numbers from startNum to endNum, one per line.
                        //Bellow

            // 11. Call your LoopThis function by passing in 20 and 30 as your parameters.
            LoopThis(20, 30);

            // 12. Call your LoopThis function by passing in 0 and myAge as your parameters.
            LoopThis(0, myAge);

            // 13. Create a function called "SuperLoop" that takes three integer parameters called "startNum", "endNum", and "increment".  
            //      You will need to track how many times the loop has been executed in a variable called "loopCount".
            //      This function will print out: 
            //          a. "I'm looping from <startNum> to <endNum>, incrementing <increment> each time"  
            //          b. The numbers from startNum to endNum, one per line.
            //          c. "That loop was craaaaaazy, we looped X times"
                        //Bellow

            // 14. Call your SuperLoop function by passing in 0, 100, and 15 as your parameters.
            SuperLoop(0, 100, 15);

            // 15. Call your SuperLoop function by passing in 0, 200, and myAge as your parameters.
            SuperLoop(0, 200, myAge);

            //DECLARING AND CALLING RETURN FUNCTIONS
            // 1. Create a function called "NewGreeting" that takes one string parameter called "name".  This function will return a string in the format of "Hello, <name>"
            // 2. Using your NewGreeting function as the parameter for Console.WriteLine(), call your NewGreeting function using the parameter "Neil deGrasse-Tyson"
            //          EX: Console.WriteLine(FunctionCall("myParameter"));
            Console.WriteLine(NewGreeting("Neil deGrasse-Tyson"));

            // 3. Using your NewGreeting function as the parameter for Console.WriteLine(), call your NewGreeting function using the parameter myName.
            Console.WriteLine(NewGreeting(myName));
            
            // 4. Create a function called "TripleIt" that takes one integer parameter called "number".  This function will return the number times 3.
            //Below

            // 5. Using your TripleIt function as part of the parameter for Console.WriteLine(), 
            //      call your TripleIt function using the parameter of 10 to print out "10 tripled is <TripleIt Function Call>"
            Console.WriteLine("10 trippled is " + TrippleIt(10));

            // 6. Using your TripleIt function as part of the parameter for Console.WriteLine(), 
            //      call your TripleIt function using the parameter of myAge to print out "<myAge> tripled is <TripleIt Function Call>"
            Console.WriteLine(myAge + " tripled is " + TrippleIt(myAge));

            // 7. Create a function called "RealMultiply" that takes two integer parameters called "num1", and "num2".  This function will return the num1 * num2.
                //Bellow

            // 8. Using your RealMultiply function as part of the parameter for Console.WriteLine(), 
            //      call your RealMultiply function using the parameter of 5 and 10 to print out the returned value from your function.
            Console.WriteLine(RealMultiply(5, 10));

            // 9. Using your RealMultiply function as part of the parameter for Console.WriteLine(), 
            //      call your RealMultiply function using the parameter of 2 and myAge to print out the returned value from your function.
            Console.WriteLine(RealMultiply(myAge, 2));

            //FUNCTION CALL MADNESS! XD!!!
            // 1. Call your SuperLoop function using the following parameters:
            //      startNum = Call RealMultiply with the parameters 1, 5
            //      endNum = Call TripleIt with the parameter myAge
            //      increment = Call TripleIt with the parameter of myAge minus 10
            SuperLoop(RealMultiply(1,5), TrippleIt(myAge), TrippleIt(myAge - 10));

            // 2. Call your SuperLoop function using the following parameters:
            //      startNum = Call RealMultiply with the parameters 1, and TripleIt with the parameter of 3.
            //      endNum = Call TripleIt with the parameter RealMultiply with the parameters: myAge, 7
            //      increment = Call TripleIt with the parameter of myAge minus RealMultiply with the parameters 2, 4.
            SuperLoop(RealMultiply(1,TrippleIt(3)), TrippleIt(RealMultiply(myAge,7)), TrippleIt(myAge - RealMultiply(2,4)));
            Console.ReadKey();

        }

        //START -- FUNCTION DECLARATIONS 

        //Greeting Function
        static void Greeting(string name)
        {
            Console.WriteLine("Hello " + name);
        }

        //Double it function
        static void DoubleIt(int num)
        {
            Console.WriteLine(num + " doubled is " + num * 2);
        }

        //Multiply Function
        static void Multiply(int num1, int num2)
        {
            Console.WriteLine(num1 + " times " + num2 + " is " + num1 * num2);
        }

        //Loop This Function
        static void LoopThis(int startNum, int endNum)
        {
            Console.WriteLine("Looping from " + startNum + " to " + endNum);
            while (startNum <= endNum)
            {
                Console.WriteLine(startNum);
                startNum++;
            }
        }

        //Super Loop Function
        static void SuperLoop(int startNum, int endNum, int increment)
        {
            int loop = 0;
            Console.WriteLine("Looping from " + startNum + " to " + endNum + " and incrementing by " + increment);
            while (startNum <= endNum)
            {
                Console.WriteLine(startNum);
                if (startNum == endNum)
                {
                    Console.WriteLine("That was crazy! We looped " + loop + " times!");
                }
                startNum+= increment;
                loop++;
            }
        }

        //New Greeting Function
        static string NewGreeting(string name)
        {
            return("Hello " + name);
        }

        //Triple It function
        static int TrippleIt(int num)
        {
            return (num * 3);
        }

        //Real Multiply Function
        static int RealMultiply(int num1, int num2)
        {
            return(num1 * num2);
        }
        //END   -- FUNCTION DECLARATIONS
    }
}

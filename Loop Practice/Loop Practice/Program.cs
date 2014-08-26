using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loop_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
        //-Start of program
    
            //Variables

            //Call WhileTest function
            WhileTest();

            //Call CoinToss
            CoinToss(100);

            //Call FlipForHeads
            FlipForHeads(48490489);

            //Keep Console Open 
            Console.ReadKey();

        //-End of program
        }

        
        //Functions
        static void WhileTest()
        {
            Console.WriteLine("While Loop Test");
            //While Loop From 1-10WhileTest()
        

            // declare incrementor
            int i = 1;
            
            //define the while loop condition
            while(i <= 10)
            {
                Console.WriteLine(i);
                //increment i
                i = i + 1;
            }
        }

        static void CoinToss(int flips)
        {
            //Heads or tails
            int headsCount = 0;
            int tailsCount = 0;

            //Rand num generator
            Random rng = new Random();

            for (int i = 1; i <= flips; i++)
            {
                //Flip the coin
                int flip = rng.Next(0,2);

                if (flip == 0)
                {
                    tailsCount++;
                }
                else
                {
                    headsCount++;
                }
            }
            Console.WriteLine("Coin fliped " + flips + " times");
            Console.WriteLine("Number of heads: " + headsCount);
            Console.WriteLine("Number of tails " + tailsCount);
        }

        static void FlipForHeads(int numHeads)
        {
            //counts how many heads have been flipped
            int headsFlipped = 0;

            //incrementor and # of flips
            int flips = 0;
            
            //random number generator
            Random rng = new Random();
            

            //while loop to flip coins until desired num of heads is reached
            
            while (flips <= numHeads)
            {
                if (rng.Next(0,2) == 1)
                {
                    headsFlipped = headsFlipped + 1;
                }
                flips = flips + 1;
            }
            Console.WriteLine("It took " + flips + " flips to get " + headsFlipped + " heads.");
        }
        //-End of Functions
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            HangMan();
            Console.ReadKey();
        }
        //Functions
        //Get word Function
        static void HangMan()   
        {
            //Variables
            List<string> answer = new List<string>();
            bool playing = true;
            bool start = false;
            char guess;
            string name;
            string answerString = answer.ToString();
            
            //Make list for wordbank
            List<string> wordbank = new List<string> {"Hippopatamus", "Tiger", "Zebra", "PerryThePlatapus"};
            //Random # generator 
            Random RW = new Random();
            //Random index variable
            int index = RW.Next(0, wordbank.Count);
            //Get random word from wordbank
            string word = wordbank[index];
            
            //Print a "_" for every letter in word
            for (int i = 0; i < word.Length; i++)
            {
                answer.Add("_");
            }
            
            //Ask for users name then print it
            Console.WriteLine("Hello User! Whats your Name??!");
            name = Console.ReadLine();
            Console.WriteLine("Hello " + name + "! " + "Press any key to play hangman!");
            Console.ReadKey();
            //Game is being played
            while (playing)
            {
                
                guess = Console.ReadKey().KeyChar;
                
                //change to string so it will be compatible with answer
                string guessString = guess.ToString();
                
                //does word contain guess?
                if (word.Contains(guess))
                {
                    //Loop through word letters
                    for (int i = 0 ; i < word.Length; i++)
                    {
                        //does word item (letter) = guess?
                        if (word[i] == guess)
                        {
                            //if it does replace the "_" in the position of the answer, that is the same as the word index with correct letter with "X".
                            answer[i] = "X";
                            //Replace "X"'s (all the letters that = correct guess) with guess
                            answer[i].Replace("X", guessString);
                        }
                        //end of if statment
                    }
                    //end of for statment
                }
                //end of if statment
                
            }
            //End of Game played while loop
            
        }
    }
}

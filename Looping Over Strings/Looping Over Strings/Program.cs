using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Looping_Over_Strings
{
    class Program
    {
        static void Main(string[] args)
        {

        }
        //Functions

        //create a new function to loop over the letters of a string
        static void FindALetter(string letterToFind, string text)
        {
            //Letter matches
            int letterCount = 0;

            //loop over string
            for (int i = 0; i < text.Length; i++)
            {
                //Get Current Letter We're looking at an convert to string 
                string letter = text[i].ToString();

                //is this a letter we need to find?
                if (letter.ToLower() == letterToFind.ToLower())
                {
                    letterCount++;
                }
            }
            //Display Output
            Console.WriteLine("Found " + letterCount + " " + letterToFind + "'s in " + text);
        }

        static void FindAWord(string WordToFind, string text)
        {
            int wordCount = 0;

            List<string> words = text.Split(' ').ToList();

            for (int i = 0; i < words.Count; i++)
            {
                string item = words[i];
                if (item.ToLower() == WordToFind.ToLower())
                {
                    wordCount++;
                }
            }
        }
        
        //End of Function
    }
}

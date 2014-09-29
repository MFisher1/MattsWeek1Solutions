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
            
            GuessThatNumber();
            
          Console.ReadLine();
        }
        //Functions
        static void GuessThatNumber()
        {
            //variables
            
            //Previous guess
            int pg = 0;

            //Guess counter
            int gc = 0;
            
            //Random number generator
            Random rng = new Random();
            int number = rng.Next(1, 100);
            number = 20;
            int guess = ConsoleInput();
            while (!(guess == number))
            {   //set guess to console input
                guess = ConsoleInput();
                if (Console.ReadLine() == "Give Up")
                {
                    Console.WriteLine(number);
                }
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
            Console.WriteLine(number.ToString());
            AddHighScore(guess);
            DisplayHighScores();
        }
        //FUNCTIONS

        //FUnction to read console input
        static int ConsoleInput()
        {
            
            int input = Convert.ToInt32(Console.ReadLine());
            return (input);
        }

        //Add highscore to list
        static void AddHighScore(int playerScore)
        {
            Console.WriteLine("Your Name: ");
            string playerName = Console.ReadLine();

            //create a gateway to database
            MattEntities db = new MattEntities();
            //create new highscore
            HighScore newHighScore = new HighScore();
            newHighScore.Date = DateTime.Now;
            newHighScore.Game = "Guess That Number";
            newHighScore.Name = playerName;
            newHighScore.Score = playerScore;

            //add to database
            db.HighScores.Add(newHighScore);
            db.SaveChanges();
        }

        //display highscore
        static void DisplayHighScores()
        {
            Console.Clear();
            //Write high scores to console
            Console.WriteLine("Guess That Number Highscores:");
            //create connection to database
            MattEntities db = new MattEntities();
            //get highscore list
            List<HighScore> HighScores = db.HighScores.Where(x => x.Game == "GuessThatNumber")
                .OrderByDescending(x => x.Score)
                .Take(10)
                .ToList();

            foreach (HighScore highscore in HighScores)
            {
                Console.WriteLine("{0} - {1} - {2} on {3}", 
                    HighScores.IndexOf(highscore) + 1, 
                    highscore.Name, highscore.Score, 
                    highscore.Date.Value.ToShortDateString());
            }
            db.SaveChanges();
        }
        //End of Functions
    }
}

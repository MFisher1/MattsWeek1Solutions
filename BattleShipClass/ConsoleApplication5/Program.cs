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
            //Cheater
            bool Nuke = true;
            //Shots fired to keep track of score
            int shotsFired = 10;
           
            //Create a new grid
            Grid grid = new Grid();
            Point point = grid.PlayerOcean[1, 1];
            //Create ships
           
            /*
            Console.WriteLine("Do you want to place your own ships?(y/n)");
            if (Console.ReadLine() == "y")
            {
                grid.PlaceShipInterface(grid);
            }
            else
            {
                grid.AutoPlaceUserShips();
            }
             */
            Console.WriteLine("Press 'p' to play or 'h' for highscores");
            if (Console.ReadLine() == "h")
            {
                DisplayHighScores();
            }
            else
            {
                Console.Clear();
                //Place Users Ships
                grid.DisplayPlayerOcean();
                grid.PlaceShipInterface(grid);
                //Place Enemy SHips
                Ship enemyCarrier = new Ship(Ship.ShipType.Carrier);
                Ship enemyBattleship = new Ship(Ship.ShipType.Battleship);
                Ship enemyCruiser = new Ship(Ship.ShipType.Cruiser);
                Ship enemyMinesweeper = new Ship(Ship.ShipType.Minesweeper);
                Ship enemySubmarine = new Ship(Ship.ShipType.Submarine);
                grid.PlaceEnemyShip(enemyCarrier, Grid.ShipDirection.Right, 1, 1);
                grid.PlaceEnemyShip(enemyBattleship, Grid.ShipDirection.Up, 9, 9);
                grid.PlaceEnemyShip(enemyCruiser, Grid.ShipDirection.Left, 7, 7);
                grid.PlaceEnemyShip(enemySubmarine, Grid.ShipDirection.Down, 7, 1);
                grid.PlaceEnemyShip(enemyMinesweeper, Grid.ShipDirection.Left, 8, 8);
                List<Ship> enemyShips = new List<Ship> { enemyCarrier, enemyBattleship, enemyCruiser, enemyMinesweeper, enemySubmarine };
                
                //Play Game
                while (enemyShips.All(x => !x.IsDestroyed) || grid.UserShips.All(x => !x.IsDestroyed) || !Nuke)
                {
                    //Display Ocean
                    Console.WriteLine("Player Ocean");
                    grid.DisplayPlayerOcean();
                    Console.WriteLine();
                    Console.WriteLine("Enemy Ocean");
                    grid.DisplayEnemyOcean();
                    grid.UserFire();
                    Console.WriteLine("Press Enter To Continue");
                    Console.ReadKey();
                    Console.Clear();
                    grid.EnemyFire();
                    Console.WriteLine("Press Enter To Continue");
                    Console.ReadKey();
                    shotsFired++;
                    
                }
                if (grid.UserShips.All(x => x.IsDestroyed) || Nuke)
                {
                    Console.WriteLine("All of our Ships Are Sunk, Prepare For a Water Grave Captain");
                }
                else
                {
                    Console.WriteLine("All Enemy Ships Sunk! You Win!");
                    AddHighScore(shotsFired);
                }
                Console.ReadKey();
            }
        }
        //Functions
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
            newHighScore.Game = "BattleShip";
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
            Console.WriteLine("Battleship Highscores:");
            Console.WriteLine("(Scored By How Many Shots It Took To Win)");
            //create connection to database
            MattEntities db = new MattEntities();
            //get highscore list
            List<HighScore> HighScores = db.HighScores.Where(x => x.Game == "BattleShip")
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

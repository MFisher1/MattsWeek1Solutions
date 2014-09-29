using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Grid  
    {
        public enum ShipDirection
        {
            Up, Down, Left, Right
        }
        //PROPERTIES
        //create a multideminsional array of points called ocean
        public Point[,] PlayerOcean { get; set; }
        public Point[,] EnemyOcean { get; set; }
        //List of user ships
        private List<Ship> _userShips = new List<Ship>();

        public List<Ship> UserShips
        {
            get { return _userShips; }
            set { _userShips = value; }
        }
        

        private bool _userShipsPlaced = false;

        public bool UserShipsPlaced
        {
            get { return _userShipsPlaced; }
            set { _userShipsPlaced = value; }
        }
        private bool _enemyShipsPlaced = false;

        public bool EnemyShipsPlaced
        {
            get { return _enemyShipsPlaced; }
            set { _enemyShipsPlaced = value; }
        }
       
        
        
       
        //CONSTRUCTOR
        public Grid()
        {
            //Player Ocean
            //set ocean array to be 15 points by 15 points
            this.PlayerOcean = new Point[10, 10];
            //initialize ocean
            //for x and y of points create a new point, at current x y, and set its status to empty
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    this.PlayerOcean[x, y] = new Point(x, y, Point.PointStatus.Empty);
                }
            }

            //Enemy Ocean
            this.EnemyOcean = new Point[10, 10];
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    this.EnemyOcean[x, y] = new Point(x, y, Point.PointStatus.Empty);
                }
            }
            }
            
        //METHODS

        //PLAYER METHODS

        //Attack
        public void UserFire()
        { 
            int x;
            int y;
            Console.WriteLine("Fire on your Enemy!");
           
            Console.WriteLine("Enter an X cordinate between 0 and 9");
            x = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter a Y corinate between 0 and 9");
            y = Int32.Parse(Console.ReadLine());
            if (this.EnemyOcean[x, y].Status == Point.PointStatus.Ship)
            {
                Console.WriteLine("Direct Hit!");
                this.EnemyOcean[x, y].Status = Point.PointStatus.Hit;
            }
            else if (this.EnemyOcean[x, y].Status == Point.PointStatus.Hit)
            {
                Console.WriteLine("You've already hit this ship");
            }
            else
            {
                Console.WriteLine("Miss!");
                this.EnemyOcean[x, y].Status = Point.PointStatus.Miss;
            }
        }


        //Place ship MEthod(this is where shit starts to get complicated)
        //Create a function called create user ship that takes the parameter of: SHIP(object of ship class), GRID.SHIPDIRECTION(an enum set in grid
        //to store which way a ship is facing), STARTX(starting x of ship), and STARTY(starting y of ship)

        //Auto Place User Ships
        //Randomly places Enemy Ships
        public void AutoPlaceUserShips()
        {

            //Ships
            Ship userCarrier = new Ship(Ship.ShipType.Carrier);
            Ship userBattleship = new Ship(Ship.ShipType.Battleship);
            Ship userCruiser = new Ship(Ship.ShipType.Cruiser);
            Ship userMinesweeper = new Ship(Ship.ShipType.Minesweeper);
            Ship userSubmarine = new Ship(Ship.ShipType.Submarine);

            //Position info
            int x = RandomCordinate();
            int y = RandomCordinate();
            ShipDirection direction = RandomDirection();

            //Place Ships
            //Place Carrier
            while (!CanPlace(userCarrier, direction, x, y))
            {
                if (CanPlace(userCarrier, direction, x, y))
                {
                    PlaceUserShip(userCarrier, direction, x, y);
                }
                x = RandomCordinate();
                y = RandomCordinate();
                direction = RandomDirection();
            }

            //Place BattleShip
            while (!CanPlace(userBattleship, direction, x, y))
            {
                if (CanPlace(userBattleship, direction, x, y))
                {
                    PlaceUserShip(userBattleship, direction, x, y);
                }
                x = RandomCordinate();
                y = RandomCordinate();
                direction = RandomDirection();
            }

            //Place Enemy Cruiser
            while (!CanPlace(userCruiser, direction, x, y))
            {
                if (CanPlace(userCruiser, direction, x, y))
                {
                    PlaceUserShip(userCruiser, direction, x, y);
                }
                x = RandomCordinate();
                y = RandomCordinate();
                direction = RandomDirection();
            }

            //Place Minesweeper
            while (!CanPlace(userMinesweeper, direction, x, y))
            {
                if (CanPlace(userMinesweeper, direction, x, y))
                {
                    PlaceUserShip(userMinesweeper, direction, x, y);
                }
                x = RandomCordinate();
                y = RandomCordinate();
                direction = RandomDirection();
            }

            //Place Submarine
            while (!CanPlace(userSubmarine, direction, x, y))
            {
                if (CanPlace(userSubmarine, direction, x, y))
                {
                    PlaceUserShip(userSubmarine, direction, x, y);
                }
                x = RandomCordinate();
                y = RandomCordinate();
                direction = RandomDirection();
            }
            this.UserShipsPlaced = true;
        }

        public void PlaceUserShip(Ship shipToPlace, Grid.ShipDirection direction, int startX, int startY)
        {
            //variables
            bool shipPlaced = false;
            
            //set current point to starting x and y
            Point currentPoint;
            //While can place is not true (see can place function below for details) exectute code
            //do this because if the user needs to keep changing his ship position until it is valid(otherwise the program will crash)
            while (!CanPlace(shipToPlace, direction, startX, startY) || !shipPlaced)
            {
                //if user can place the ship(CanPlace == true) execute code
                if (CanPlace(shipToPlace, direction, startX, startY))
                {


                    currentPoint = this.PlayerOcean[startY, startX];
                    //loop for the length of the ship
                    for (int i = 0; i <= shipToPlace.Length; i++)
                    {
                       
                        //Ship Direction is Horizontal Right
                        if (direction == ShipDirection.Right)
                        {
                            //set point status
                            currentPoint.Status = Point.PointStatus.Ship;
                            //add current point to Occupied points list of ship
                            shipToPlace.OccupiedPoints.Add(currentPoint);
                            //set the current point to start x + i (because it moves the point to the right)
                            currentPoint = this.PlayerOcean[startY, startX + i];
                            
                        }
                        //Ship direction is Horeztonal left
                        //same as above on now move points to the left
                        if (direction == ShipDirection.Left)
                        {
                            currentPoint.Status = Point.PointStatus.Ship;
                            shipToPlace.OccupiedPoints.Add(currentPoint);
                            currentPoint = this.PlayerOcean[startY, startX - i];
                            
                        }
                        //Ship direction is Vertical Up
                        //you get the picture
                        if (direction == ShipDirection.Up)
                        {
                            currentPoint.Status = Point.PointStatus.Ship;
                            shipToPlace.OccupiedPoints.Add(currentPoint);
                            currentPoint = this.PlayerOcean[startY - i, startX];
                              
                        }
                        //Ship direction is vertical down
                        if (direction == ShipDirection.Down)
                        {
                            currentPoint.Status = Point.PointStatus.Ship;
                            shipToPlace.OccupiedPoints.Add(currentPoint);
                            currentPoint = this.PlayerOcean[startY + i, startX];
                            
                        }
                    }
                    shipPlaced = true;
                }
                
                
            }
                
        }
        //end of place ship
        
        //Can place ship function
        //figure out if ship can be place and return true or false
        public bool CanPlace(Ship shipToPlace, Grid.ShipDirection direction, int startX, int startY)
        {
            //Variables
            //If any points in the area that you are placing the ship already contain a ship return false
            bool alreadyHasShip;
            //if ships starting cordinates are out of bounds return false
            if (startX > 10 || startX < 0 || startY > 10 || startY < 0)
            {
                return false;
            }
            else if (direction == ShipDirection.Right)
            {
                
                //if the start X + the length of the ship (length of ship to the right) is off the grid return false 
                if (startX + (shipToPlace.Length - 1) > 10 || startX + (shipToPlace.Length - 1) < 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
                //loop to see if any points already contain a ship
                for (int i = 0; i < shipToPlace.Length; i++)
                {
                    if (this.PlayerOcean[startY, startX +i].Status == Point.PointStatus.Ship)
                    {
                        return false;
                    }
                }

            }
            else if (direction == ShipDirection.Left)
            {
                
                if (startX - (shipToPlace.Length - 1) > 10 || startX - (shipToPlace.Length - 1) < 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
                //loop to see if any points already contain a ship
                for (int i = 0; i < shipToPlace.Length; i++)
                {
                    if (this.PlayerOcean[startY, startX - i].Status == Point.PointStatus.Ship)
                    {
                        return false;
                    }
                }
            }
            else if (direction == ShipDirection.Up)
            {
                
                if (startY - (shipToPlace.Length - 1) > 10 || startY - (shipToPlace.Length - 1) < 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
                //loop to see if any points already contain a ship
                for (int i = 0; i < shipToPlace.Length; i++)
                {
                    if (this.PlayerOcean[startY - i, startX].Status == Point.PointStatus.Ship)
                    {
                        return false;
                    }
                }
            }
            
                
            else if (direction == ShipDirection.Down)
            {
                if (startY + (shipToPlace.Length - 1) > 10 || startY + (shipToPlace.Length - 1) < 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
                //loop to see if any points already contain a ship
                for (int i = 0; i < shipToPlace.Length; i++)
                {
                    if (this.PlayerOcean[startY, startX + i].Status == Point.PointStatus.Ship)
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }
        //End of Canplace function

        //Place SHip interface
        //Allows user to place ships form console.

        public void PlaceShipInterface(Grid grid)
        {
            //Variables
            bool carrierPlaced = false;
            bool battleshipPlaced = false;
            bool cruiserPlaced = false;
            bool submarinePlaced = false;
            bool minesweeperPlaced = false;
            
            
            //Ships
            Ship userCarrier = new Ship(Ship.ShipType.Carrier);
            Ship userBattleship = new Ship(Ship.ShipType.Battleship);
            Ship userCruiser = new Ship(Ship.ShipType.Cruiser);
            Ship userMinesweeper = new Ship(Ship.ShipType.Minesweeper);
            Ship userSubmarine = new Ship(Ship.ShipType.Submarine);

            //Interface
            Console.WriteLine("Place Your Ships!(Press Enter)");
            Console.ReadKey();
            Console.Clear();
            //Place Carrier
            Console.WriteLine("Place Your Carrier");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            DisplayPlayerOcean();
            PlaceShipPromt(carrierPlaced, userCarrier, grid);
            Console.Clear();
            //Place Battleship
            Console.WriteLine("Place your Battleship");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            PlaceShipPromt(battleshipPlaced, userBattleship, grid);
            Console.Clear();
            //Place Cruiser
            Console.WriteLine("Place your Cruiser");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            PlaceShipPromt(cruiserPlaced, userCruiser, grid);
            Console.Clear();
            //Place Submarine
            Console.WriteLine("Place your Submarine");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            PlaceShipPromt(submarinePlaced, userSubmarine, grid);
            Console.Clear();
            //Place Minsweeper
            Console.WriteLine("Place your Minesweeper");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            PlaceShipPromt(minesweeperPlaced, userMinesweeper, grid);
            Console.Clear();

            this.UserShipsPlaced = true;
            //Add ships to user ships list
            this.UserShips.Add(userCarrier);
            this.UserShips.Add(userBattleship);
            this.UserShips.Add(userCruiser);
            this.UserShips.Add(userMinesweeper);
            this.UserShips.Add(userSubmarine);

        }

        //Place Ship Prompt
        public void PlaceShipPromt(bool shipPlaced, Ship shipToPlace, Grid grid)
        {
            Grid.ShipDirection direction;
            int sX;
            int sY;
            string lineRead;
            while (!shipPlaced)
            {
                Console.Clear();
                DisplayPlayerOcean();
                //Let user enter starting X and Y cordinates and direction
                Console.WriteLine("Enter the X cordinate you want your ship to start at");
                sX = Int32.Parse(Console.ReadLine().ToString());
                Console.WriteLine("Enter the Y cordinate you want your ship to start at");
                sY = Int32.Parse(Console.ReadLine().ToString());
                Console.WriteLine("Enter the direction you want your ship to face(Up, Down, Left, Right)");
                lineRead = Console.ReadLine();
                if (lineRead == "Up")
                {
                    direction = Grid.ShipDirection.Up;
                }
                else if (lineRead == "Down")
                {
                    direction = Grid.ShipDirection.Down;
                }
                else if (lineRead == "Left")
                {
                    direction = Grid.ShipDirection.Left;
                }
                else
                {
                    direction = Grid.ShipDirection.Right;
                }


                Console.Clear();

                if (CanPlace(shipToPlace, direction, sX, sY))
                {
                    grid.PlaceUserShip(shipToPlace, direction, sX, sY);
                    grid.DisplayPlayerOcean();
                    Console.WriteLine("Is this where you want to place your ship?(y/n)");
                    lineRead = Console.ReadLine();
                    if (lineRead == "n")
                    {
                        foreach (var item in shipToPlace.OccupiedPoints)
                        {
                            item.Status = Point.PointStatus.Empty;
                        }
                    }
                    else
                    {
                        shipPlaced = true;
                    }
                }
                //if user is trying to put the ship in an invalid position tell them to choose another position
                else
                {
                    Console.WriteLine("Invalid Position, choose another position for your ship");
                    Console.WriteLine("Press Enter To Continue");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        //Display Player Ocean
        public void DisplayPlayerOcean() 
        {
            //User Ocean
            //show ships in ocean if = true
            bool showShips = true;
            //loop through the length of the ocean for x and why and write to the console the status of each point
            //Display Cordinates
            Console.WriteLine("  0   1   2   3   4   5   6   7   8   9");
            for (int x = 0; x < 10 ; x++)
            {
                Console.Write(x);
                for (int  y = 0; y < 10 ; y++)
                {
                    
                    if (this.PlayerOcean[x, y].Status == Point.PointStatus.Miss)
                    {
                        Console.Write("[O] ");
                    }
                    //Can us the name of enum as string, or as a pointstatus enum
                    else if (this.PlayerOcean[x, y].Status.ToString() == "Hit")
                    {
                        Console.Write("[X] ");
                    }
                    else if (this.PlayerOcean[x, y].Status == Point.PointStatus.Ship && showShips)
                    {
                        Console.Write("[S] ");
                    }
                    else
                    {
                        Console.Write("[ ] ");
                    }
                }
                Console.WriteLine();
                
                
              }
        }
        //End of display player Ocean

        //ENEMY METHODS

        //Place Enemy SHips
        public void PlaceEnemyShip(Ship shipToPlace, Grid.ShipDirection direction, int startX, int startY)
        {
            //variables
            bool shipPlaced = false;

            //set current point to starting x and y
            Point currentPoint;
            //While can place is not true (see can place function below for details) exectute code
            //do this because if the user needs to keep changing his ship position until it is valid(otherwise the program will crash)
            while (!CanPlace(shipToPlace, direction, startX, startY) || !shipPlaced)
            {
                //if user can place the ship(CanPlace == true) execute code
                if (CanPlace(shipToPlace, direction, startX, startY))
                {


                    currentPoint = this.EnemyOcean[startY, startX];
                    //loop for the length of the ship
                    for (int i = 0; i < shipToPlace.Length; i++)
                    {

                        //Ship Direction is Horizontal Right
                        if (direction == ShipDirection.Right)
                        {
                            //add current point to Occupied points list of ship
                            shipToPlace.OccupiedPoints.Add(currentPoint);
                            //set the current point to start x + i (because it moves the point to the right)
                            currentPoint = this.EnemyOcean[startY, startX + i];
                            //set point status
                            currentPoint.Status = Point.PointStatus.Ship;
                        }
                        //Ship direction is Horeztonal left
                        //same as above on now move points to the left
                        if (direction == ShipDirection.Left)
                        {
                            shipToPlace.OccupiedPoints.Add(currentPoint);
                            currentPoint = this.EnemyOcean[startY, startX - i];
                            currentPoint.Status = Point.PointStatus.Ship;
                        }
                        //Ship direction is Vertical Up
                        //you get the picture
                        if (direction == ShipDirection.Up)
                        {
                            shipToPlace.OccupiedPoints.Add(currentPoint);
                            currentPoint = this.EnemyOcean[startY - i, startX];
                            currentPoint.Status = Point.PointStatus.Ship;
                        }
                        //Ship direction is vertical down
                        if (direction == ShipDirection.Down)
                        {
                            shipToPlace.OccupiedPoints.Add(currentPoint);
                            currentPoint = this.EnemyOcean[startY + i, startX];
                            currentPoint.Status = Point.PointStatus.Ship;
                        }
                    }
                    shipPlaced = true;
                }


            }

        }
        //end of place ship

        //Display Enemy Ocean
        public void DisplayEnemyOcean()
        {
            //User Ocean
            //show ships in ocean if = true
            bool showShips = false;
            //Display Cordinates
            Console.WriteLine("  0   1   2   3   4   5   6   7   8   9");
            //loop through the length of the ocean for x and y and write to the console the status of each point
            for (int x = 0; x < 10; x++)
            {
                Console.Write(x);
                for (int y = 0; y < 10; y++)
                {

                    if (this.EnemyOcean[x, y].Status == Point.PointStatus.Miss)
                    {
                        Console.Write("[O] ");
                    }
                    //Can us the name of enum as string, or as a pointstatus enum
                    else if (this.EnemyOcean[x, y].Status.ToString() == "Hit")
                    {
                        Console.Write("[X] ");
                    }
                    else if (this.EnemyOcean[x, y].Status == Point.PointStatus.Ship && showShips)
                    {
                        Console.Write("[S] ");
                    }
                    else
                    {
                        Console.Write("[ ] ");
                    }
                }
                Console.WriteLine();


            }
        }
        //End of display Ocean
        
        //Randomly places Enemy Ships
        public void RandomlyPlaceEnemyShips()
        {
            
            //Ships
            Ship enemyCarrier = new Ship(Ship.ShipType.Carrier);
            Ship enemyBattleship = new Ship(Ship.ShipType.Battleship);
            Ship enemyCruiser = new Ship(Ship.ShipType.Cruiser);
            Ship enemyMinesweeper = new Ship(Ship.ShipType.Minesweeper);
            Ship enemySubmarine = new Ship(Ship.ShipType.Submarine);

            //Position info
            int x = RandomCordinate();
            int y = RandomCordinate();
            ShipDirection direction = RandomDirection();

            //Place Ships
            //Place Carrier
            while (!CanPlace(enemyCarrier, direction, x, y))
            {
                if (CanPlace(enemyCarrier, direction, x, y))
                {
                    PlaceEnemyShip(enemyCarrier, direction, x, y);
                }
                x = RandomCordinate();
                y = RandomCordinate();
                direction = RandomDirection();
            }

            //Place BattleShip
            while (!CanPlace(enemyBattleship, direction, x, y))
            {
                if (CanPlace(enemyBattleship, direction, x, y))
                {
                    PlaceEnemyShip(enemyBattleship, direction, x, y);
                }
                x = RandomCordinate();
                y = RandomCordinate();
                direction = RandomDirection();
            }

            //Place Enemy Cruiser
            while (!CanPlace(enemyCruiser, direction, x, y))
            {
                if (CanPlace(enemyCruiser, direction, x, y))
                {
                    PlaceEnemyShip(enemyCruiser, direction, x, y);
                }
                x = RandomCordinate();
                y = RandomCordinate();
                direction = RandomDirection();
            }

            //Place Minesweeper
            while (!CanPlace(enemyMinesweeper, direction, x, y))
            {
                if (CanPlace(enemyMinesweeper, direction, x, y))
                {
                    PlaceEnemyShip(enemyMinesweeper, direction, x, y);
                }
                x = RandomCordinate();
                y = RandomCordinate();
                direction = RandomDirection();
            }

            //Place Submarine
            while (!CanPlace(enemySubmarine, direction, x, y))
            {
                if (CanPlace(enemySubmarine, direction, x, y))
                {
                    PlaceEnemyShip(enemySubmarine, direction, x, y);
                }
                x = RandomCordinate();
                y = RandomCordinate();
                direction = RandomDirection();
            }
            this.EnemyShipsPlaced = true;
        }
        //End of Randomly Place Enemy Ships
     

        //GENERAL METHODS
        //Creates a random direction
        public ShipDirection RandomDirection()
        {
            Random rng = new Random();
            int random = rng.Next(1, 5);
            if (random == 1)
            {
                return ShipDirection.Up;
            }
            else if (random == 2)
            {
                return ShipDirection.Down;
            }
            else if (random == 3)
            {
                return ShipDirection.Left;
            }
            else 
            {
                return ShipDirection.Right;
            }
        }

        //Enemy Fire
        public void EnemyFire()
        {
            int x = RandomCordinate();
            int y = RandomCordinate();

            if (this.PlayerOcean[x, y].Status == Point.PointStatus.Ship)
            {
                Console.WriteLine("Mayday Mayday You've Been Hit!");
                this.PlayerOcean[x, y].Status = Point.PointStatus.Hit;
            }
            else
            {
                Console.WriteLine("The Enemy Missed!");
                this.PlayerOcean[x, y].Status = Point.PointStatus.Miss;
            }
        }

        //GENERAL METHODS

        //Creates a Random Cordinate
        public int RandomCordinate()
        {
            Random rng = new Random();
            return rng.Next(1, 10);
        }

        }
    }


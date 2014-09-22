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
        public Point[,] Ocean { get; set; }
        
        
       
        //CONSTRUCTOR
        public Grid()
        {
            //set ocean array to be 15 points by 15 points
            this.Ocean = new Point[15, 15];
            //initialize ocean
            //for x and y of points create a new point, at current x y, and set its status to empty
            for (int x = 1; x < 15; x++)
                for (int y = 1; y < 15; y++)
                {
                    this.Ocean[x, y] = new Point(x, y, Point.PointStatus.Empty);
                }
            }
            
        //METHODS
        //Place ship(this is where shit starts to get complicated)
        //Create a function called create user ship that takes the parameter of: SHIP(object of ship class), GRID.SHIPDIRECTION(an enum set in grid
        //to store which way a ship is facing), STARTX(starting x of ship), and STARTY(starting y of ship)
        public void PlaceUserShip(Ship shipToPlace, Grid.ShipDirection direction, int startX, int startY)
        {
            //variables
            bool shipPlaced = false;
            //While can place is not true (see can place function below for details) exectute code
            //do this because if the user needs to keep changing his ship position until it is valid(otherwise the program will crash)
            while (!CanPlace(shipToPlace, direction, startX, startY) || !shipPlaced)
            {
                //if user can place the ship(CanPlace == true) execute code
                if (CanPlace(shipToPlace, direction, startX, startY))
                {
                    //set current point to starting x and y
                    Point currentPoint = new Point(startX, startY, Point.PointStatus.Ship);
                    currentPoint = this.Ocean[startY, startX];
                    //set status to ship
                    currentPoint.Status = Point.PointStatus.Ship;
                    //loop for the length of the ship
                    for (int i = 1; i <= shipToPlace.Length; i++)
                    {
                        //Ship Direction is Horizontal Right
                        if (direction == ShipDirection.Right)
                        {
                            //add current point to Occupied points list of ship
                            shipToPlace.OccupiedPoints.Add(currentPoint);
                            //set the current point to start x + i (because it moves the point to the right)
                            currentPoint = this.Ocean[startY, startX - i];
                            //set point status
                            currentPoint.Status = Point.PointStatus.Ship;
                        }
                        //Ship direction is Horeztonal left
                        //same as above on now move points to the left
                        if (direction == ShipDirection.Left)
                        {
                            shipToPlace.OccupiedPoints.Add(currentPoint);
                            currentPoint = this.Ocean[startY, startX + i];
                            currentPoint.Status = Point.PointStatus.Ship;
                        }
                        //Ship direction is Vertical Up
                        //you get the picture
                        if (direction == ShipDirection.Up)
                        {
                            shipToPlace.OccupiedPoints.Add(currentPoint);
                            currentPoint = this.Ocean[startY - i, startX];
                            currentPoint.Status = Point.PointStatus.Ship;
                        }
                        //Ship direction is vertical down
                        if (direction == ShipDirection.Down)
                        {
                            shipToPlace.OccupiedPoints.Add(currentPoint);
                            currentPoint = this.Ocean[startY + i, startX];
                            currentPoint.Status = Point.PointStatus.Ship;
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
            if (startX > 15 || startX < 1 || startY > 15 || startY < 1)
            {
                return false;
            }
            else if (direction == ShipDirection.Right)
            {
                //loop to see if any points already contain a ship
                for (int i = 1; i < shipToPlace.Length; i++)
                {
                    if (this.Ocean[startY, startX - i].Status == Point.PointStatus.Ship)
                    {
                        return false;
                    }
                }
                //if the start X + the length of the ship (length of ship to the right) is off the grid return false 
                if (startX + (shipToPlace.Length - 1) > 15 || startX + (shipToPlace.Length - 1) < 1)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            else if (direction == ShipDirection.Left)
            {
                //loop to see if any points already contain a ship
                for (int i = 1; i < shipToPlace.Length; i++)
                {
                    if (this.Ocean[startY, startX + i].Status == Point.PointStatus.Ship)
                    {
                        return false;
                    }
                }
                if (startX - (shipToPlace.Length - 1) > 15 || startX - (shipToPlace.Length - 1) < 1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (direction == ShipDirection.Up)
            {
                //loop to see if any points already contain a ship
                for (int i = 1; i < shipToPlace.Length; i++)
                {
                    if (this.Ocean[startY - i, startX].Status == Point.PointStatus.Ship)
                    {
                        return false;
                    }
                }
                if (startY + (shipToPlace.Length - 1) > 15 || startY + (shipToPlace.Length - 1) < 1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (direction == ShipDirection.Down)
            {
                //loop to see if any points already contain a ship
                for (int i = 1; i < shipToPlace.Length; i++)
                {
                    if (this.Ocean[startY, startX + i].Status == Point.PointStatus.Ship)
                    {
                        return false;
                    }
                }
                if (startY - (shipToPlace.Length - 1) > 15 || startY - (shipToPlace.Length - 1) < 1)
                {
                    return false;
                }
                else
                {
                    return true;
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

        public bool PlaceShipInterface(Grid grid)
        {
            //Variables
            bool carrierPlaced = false;
            bool battleshipPlaced = false;
            bool minesweeperPlaced = false;
            bool submarinePlaced = false;
            
            //Ships
            Ship carrier = new Ship(Ship.ShipType.Carrier);
            Ship battleship = new Ship(Ship.ShipType.Battleship);
            Ship cruiser = new Ship(Ship.ShipType.Cruiser);
            Ship minesweeper = new Ship(Ship.ShipType.Minesweeper);
            Ship submarine = new Ship(Ship.ShipType.Submarine);

            //Interface
            Console.WriteLine("Place Your Ships!(Press Enter)");
            Console.ReadKey();
            Console.Clear();
            //Place Carrier
            Console.WriteLine("Place Your Carrier");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            PlaceShipPromt(carrierPlaced, carrier, grid);
            Console.Clear();
            //Place Battleship
            Console.WriteLine("Place your Battleship");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            PlaceShipPromt(battleshipPlaced, battleship, grid);
            Console.Clear();
            //Place Minsweeper
            Console.WriteLine("Place your Minesweeper");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            PlaceShipPromt(minesweeperPlaced, minesweeper, grid);
            Console.Clear();
            //Place Minsweeper
            Console.WriteLine("Place your Minesweeper");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            PlaceShipPromt(minesweeperPlaced, minesweeper, grid);
            Console.Clear();
            //Place Submarine
            Console.WriteLine("Place your Submarine");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            PlaceShipPromt(submarinePlaced, submarine, grid);
            Console.Clear();
            return true;

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
                    grid.DisplayOcean();
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

        //Display Ocean
        public void DisplayOcean() 
        {
            //show ships in ocean if = true
            bool showShips = true;
            //loop through the length of the ocean for x and why and write to the console the status of each point
            for (int x = 1; x < 15 ; x++)
            {
                for (int  y = 1; y < 15 ; y++)
                {
                    
                    if (this.Ocean[x, y].Status == Point.PointStatus.Miss)
                    {
                        Console.Write("[O] ");
                    }
                    //Can us the name of enum as string, or as a pointstatus enum
                    else if (this.Ocean[x, y].Status.ToString() == "Hit")
                    {
                        Console.Write("[X] ");
                    }
                    else if (this.Ocean[x, y].Status == Point.PointStatus.Ship && showShips)
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

        }
    }


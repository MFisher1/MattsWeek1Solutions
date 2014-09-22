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
           
            //Create a new grid
            Grid grid = new Grid();
            Point point = grid.Ocean[1, 1];
            //Create ships
            /*
            Ship battleship = new Ship(Ship.ShipType.Battleship);
            grid.PlaceUserShip(battleship,Grid.ShipDirection.Down,9,9);
            */

            grid.PlaceShipInterface(grid);
            
             
            //Display Ocean

            grid.DisplayOcean();
                
            
            //
            
            Console.ReadKey();
           
        }
        //Functions

        
    }
}

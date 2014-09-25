using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Ship
    {
        public enum ShipType
        {
            Carrier, Battleship, Cruiser, Submarine, Minesweeper
        }

        //PROPERTIES
        public ShipType Type { get; set; }
        
        //Occupied Points
        private List<Point> _occupiedPoints = new List<Point>();
        public List<Point>  OccupiedPoints
        {
            get { return _occupiedPoints; }
            set { _occupiedPoints = value; }
        }
        //Ship length
        public int Length { get; set; }
        //Ss destroyed propertied
        public bool IsDestroyed
        {
            get { return OccupiedPoints.All(x => x.Status == Point.PointStatus.Hit); }
        }


        //CONTRUCTOR
        public Ship(ShipType type)
        {
            this.Type = type;
            if (this.Type == ShipType.Carrier)
            {
                this.Length = 5;
            }
            if (this.Type == ShipType.Battleship)
            {
                this.Length = 4;
            }
            if (this.Type == ShipType.Cruiser)
            {
                this.Length = 3;
            }
            if (this.Type == ShipType.Submarine)
            {
                this.Length = 2;
            }
            if (this.Type == ShipType.Minesweeper)
            {
                this.Length = 1;
            }
        }
        
    }
}

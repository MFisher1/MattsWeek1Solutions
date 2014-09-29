using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Point
    {
        public enum PointStatus
        {
            Empty, Ship, Hit, Miss
        }

        //PROPERTIES

        //Cordinates
        public int X { get; set; }
        public int Y { get; set; }
        //Status
        public PointStatus Status { get; set; }

        //CONSTRUCTOR
        public Point(int x, int y, PointStatus status)
        {
            this.X = x;
            this.Y = y;
            this.Status = status;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPractice
{
    class Car
    {
        //Step 1
        //declare properties and variables
        //varibale for make property
        private string _make;
        //declare Make property
        public string Make
        {
            get
            {
                return _make;
            }
            set
            {
                _make = value.ToUpper();
            }
        }

        //short hand version of a property
        public string Model { get; set; }

        //Step 2. Declare Constructor
        public Car(string make, string model)
        {
            this.Make = make;
            this.Model = model;
        }

        //Step 3 Methods
        public void Honk()
        {
            Console.WriteLine("Beeeeppp beeeeep");
            Console.Beep();
            Console.Beep();
        }

        public string GetInfo()
        {
            //Returns a string with info about the car
            return this.Make + " " + this.Model;
        }

    }
}

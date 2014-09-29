using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Enemy
    {
        //PROPERTIES
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value.ToUpper(); }
        }

        //Health of enemy
        private int _hp;

        public int HP
        {
            get { return _hp; }
            set { _hp = value; }
        }
        
        //create random # generator
        private Random rng = new Random();

        //CONSTRUCTOR
        public Enemy(string name, int startingHP)
        {
            this.HP = startingHP;
            this.Name = name;
        }

        //METHODS

        //Attack Method
        public void Attack(Player player)
        {
            //80% chance of hitting
            if (rng.Next(0,100) > 2)
            {
                //hit! roll for 5 - 15
                int damage = rng.Next(5, 16);

                   
            }
        }
        
    }
}

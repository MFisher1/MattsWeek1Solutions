using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    //Pokemon Moves
    enum Types 
    {
        ELECTRIC,
        FIRE,
        DRAGON,
        GRASS,
        PSYCIC,
        WATER
    }
    enum Effects
    {
       POSION,
       PARALYZE,
       BURN,
       SLEEP
       
    }

    class MoveResult
    {
        //PROPERTIES
        public int Damage { get; set; }
        public int Heal { get; set; }
        public int Acuracy { get; set; }
        public Effects Effect { get; set; }

        //CONSTRUCTOR
        public MoveResult(Effects effect, int damage, int acuracy, int heal)
        {
            this.Effect = effect;
            this.Damage = damage;
            this.Acuracy = acuracy;
            this.Heal = heal;
        }
    }

   
   
    class Moves
    {
        //PROPERTIES
        public string Name { get; set; }
        public Type Type { get; set; }
        public int Damage { get; set; }
        public int Heal { get; set; }
        public int Acuracy { get; set; }
        public Effects Effect { get; set; }
        

        //METHODS
        
        //Moves
        
        //Electric
        public MoveResult THUNDERBOLT
        {
            
        }

        
        

    }

    class Pokemon 
    {
        //PROPERTIES

        //Health Points
        public int HP { get; set; }
        private List<Moves> _learnedMoves;

        public List<Moves> LearnedMoves
        {  
            get { return _learnedMoves; }
            set { _learnedMoves = value; }
        }
        

        //
    }
}

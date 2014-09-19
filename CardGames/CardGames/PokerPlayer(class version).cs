using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    class PokerPlayer_class_version_
    {
        
        
        //Step1: Declare properties
        //public Deck PokerDeck { get; set; }
        
        private List<Card> _userHand = new List<Card>();

        public List<Card> UserHand
        {
            get { return _userHand; }
            set { _userHand = value;}
        }
        
        
        //Step2: Constructor
        
         
        

        //Step3: Methods or functions
        //function to draw hand
        public void DrawHand(Deck pokerDeck)
        {
            this.UserHand = pokerDeck.Deal(5);
        }

        //Find hand value functions
        
        //Find HighCard Value
        public Rank HighCard()
        {
            //Select rank, order from lowest to highest, return last rank on list as it is the highest
            return this.UserHand.Select(x => x.Rank).OrderBy(x => x).Last();
        }
        //figure out if hand is a pair
        public bool IsPair()
        {
            //select rank, return true if the number of distinct ranks is 4(because there are 5 cards that mean that two are the same rank ie. a pair).
            return this.UserHand.Select(x => x.Rank).Distinct().Count() == 4;
        }
        //figure out if hand is three of a kind
        public bool IsThreeOfAKind()
        {
            return this.UserHand.Select(x => x.Rank).Distinct().Count() == 3;
        }
        //figure out if hand is four of a kind
        public bool IsFourOfaKind()
        {
            
            return this.UserHand.Select(x => x.Rank).Distinct().Count() == 2;
        }
        //figure out if hand is a flush
        public bool IsFlush()
        {
            return this.UserHand.Select(x => x.Suit).Distinct().Count() == 1;
        }
        //figure out if hand is a fullhouse
        public bool IsFullHouse()
        {
            if (this.UserHand.Select(x => x.Rank).Distinct().Count() == 2)
            {
                IEnumerable<IGrouping<Rank, Card>> group = this.UserHand.GroupBy(x => x.Rank);
                return group.Any(x => x.Count() == 3);
            }
            else return false;
        }
        //figure out if hand is a royal flush 
        public bool IsRoyalFlush()
        {
            return this.UserHand.Select(x => x.Suit).Distinct().Count() == 1 && this.UserHand.Select(x => x.Rank).Contains(Rank.Ace);
        }
        //figure out if hand is a straight
        public bool IsStraight()
        {
            bool rtn;
            List<Card> orderedHand = this.UserHand.OrderBy(x => x.Rank).ToList();
            rtn = true;
            Card prevcard = orderedHand[0];
            for (int i = 1; i < this.UserHand.Count; i++)
            {
                if (Convert.ToInt32(prevcard.Rank) + 1 != Convert.ToInt32(orderedHand[i].Rank))
                {
                    rtn = false;
                }
            }
            return rtn;
            
        }
    }

    
}

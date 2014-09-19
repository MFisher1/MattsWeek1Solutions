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
        
         
        

        //METHODS

        //function to draw hand
        public void DrawHand(Deck pokerDeck)
        {
            this.UserHand = pokerDeck.Deal(5);
        }

        //HAND VALUE METHODS
        
        //Find HighCard Value
        public Rank HighCard()
        {
            //Select rank, order from lowest to highest, return last rank on list as it is the highest
            return this.UserHand.Select(x => x.Rank).OrderBy(x => x).Last();
        }

        //figure out if hand is a pair
        public bool IsPair()
        {
            //select rank, return true if the number of distinct ranks is 4(because there are 5 cards that mean that 2 are the same rank ie. a pair).
            return this.UserHand.Select(x => x.Rank).Distinct().Count() == 4;
        }

        //figure out if hand is three of a kind
        public bool IsThreeOfAKind()
        {
            //select rank, return true if the number of distinct ranks is 3(because there are 5 cards that mean that 3 are the same rank ie. 3 of a kind).
            return this.UserHand.Select(x => x.Rank).Distinct().Count() == 3;
        }

        //figure out if hand is four of a kind
        public bool IsFourOfaKind()
        {
            //select rank, return true if the number of distinct ranks is 2(because there are 5 cards that mean that four are the same rank ie. 4 of a kind).
            return this.UserHand.Select(x => x.Rank).Distinct().Count() == 2;
        }

        //figure out if hand is a flush
        public bool IsFlush()
        {
            //select suit, if there is only 1 distinct value of suit, that means that all of the cards must be the same suit
            return this.UserHand.Select(x => x.Suit).Distinct().Count() == 1;
        }

        //figure out if hand is a royal flush 
        public bool IsRoyalFlush()
        {
            //select suit, if there is only 1 distinct value of suit, that means that all of the cards must be the same suit, then if 
            //hand contains an ace, king, queen, and jack then it is a royal flush.
            return this.UserHand.Select(x => x.Suit).Distinct().Count() == 1 && this.UserHand.Select(x => x.Rank).Contains(Rank.Ace)
            && this.UserHand.Select(x => x.Rank).Contains(Rank.King) && this.UserHand.Select(x => x.Rank).Contains(Rank.Queen) &&
            this.UserHand.Select(x => x.Rank).Contains(Rank.Jack);
        }

        //figure out if hand is a fullhouse
        public bool IsFullHouse()
        {
            if (this.UserHand.Select(x => x.Rank).Distinct().Count() == 2)
            {
                //Group the cards by rank
                IEnumerable<IGrouping<Rank, Card>> group = this.UserHand.GroupBy(x => x.Rank);
                //if there is a group of 3 cards and a pair(figured out by any lambda) then hand is a full house
                return group.Any(x => x.Count() == 3) && group.Any(x => x.Count() == 2);
            }
            else return false;
        }
        
        //figure out if hand is a straight
        public bool IsStraight()
        {
            //create a bool to return whether Is Strait is true or false
            bool rtn;
            //order users hand then put it into a new list
            List<Card> orderedHand = this.UserHand.OrderBy(x => x.Rank).ToList();
            //return is true unless proven wrong
            rtn = true;
            //make a variable to compare previous card in hand to current card
            Card prevcard = orderedHand[0];
            //starting at the lowest card, compare every card in the hand to the previous one(ordered by value of rank)
            for (int i = 1; i < this.UserHand.Count; i++)
            {
                //if hand is a straight the previous card's rank plus one should equal the current card rank. 
                if (Convert.ToInt32(prevcard.Rank) + 1 != Convert.ToInt32(orderedHand[i].Rank))
                {
                    // if it doenst change rtn bool to false
                    rtn = false;
                }
            }
            //return rtn bool
            return rtn;
            
        }
    }

    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    class MattsPokerPlayer
    {
        
            //PROPERTIES
            //Hand Options

        public void MattsPokerGame()
        {
            int turn = 1;
            //create and shuffle deck
            Deck PokerDeck = new Deck();
            PokerDeck.Shuffle();
            

	        
	

            //deal cards
            List<Card> UsersCards = PokerDeck.Deal(5);
            List<Card> OpponentCards = PokerDeck.Deal(5);

            //Print Users cards
            Console.WriteLine("Your Hand:");
            Console.WriteLine();
            foreach (var item in UsersCards)
            {
                Console.WriteLine(item.Rank + " of " + item.Suit + ", ");
            }

            //Play

        }
        //End of Poker

        public void HandValue(List<Card> Hand)
        {
            //variables
            int sameRankCards = 0;
            Rank ofAKindRank;
            //Hands variables
            bool fourOfaKind = false;
            bool threeOfaKind = false;
            bool pair = false;

            //check for pairs, 3 and 4 of a kind
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < Hand.Count(); j++)
                {
                    if ((Rank)i == Hand[j].Rank)
                    {
                        sameRankCards++;
                    }
                    if (sameRankCards == 4)
                    {
                        fourOfaKind = true;
                        threeOfaKind = false;
                        pair = false;
                        ofAKindRank = (Rank)i;
                    }
                    else if (sameRankCards == 3)
                    {
                        threeOfaKind = true;
                        pair = false;
                        ofAKindRank = (Rank)i;
                    }
                    else if (sameRankCards == 2)
                    {
                        pair = true;
                        ofAKindRank = (Rank)i;
                    }
                    sameRankCards = 0;
                }
                //end of for loop
            }
            //End of for loop
        }
    }
}

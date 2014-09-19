using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Deck Deck = new Deck();
            Console.WriteLine(string.Join(" ", Deck.Cards.Select(x => x.Rank)));
            Console.WriteLine("Shuffle");
            Deck.Shuffle();
            Console.WriteLine(string.Join(" ", Deck.Cards.Select(x => x.Rank)));
            List<Card> myCards = Deck.Deal(5);
             */
            
            //Poker
            Poker();

            Console.ReadLine();

        }

        static void Poker()
        {
            //varible
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

        static string HandValue(List<Card> Hand)
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
                        ofAKindRank = (Rank)i;
                    }
                    else if (sameRankCards == 3)
                    {
                        threeOfaKind = true;
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

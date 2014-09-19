using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    public enum Suit { Spades, Hearts, Diamonds, Clubs }
    public enum Rank { Two,Three,Four,Five, Six, Seven, Eigth, Nine,Ten,Jack,Queen,King,Ace}
     
    public class Card
    {
        public Suit Suit { get; set; }

        public Rank Rank { get; set; }
        public Card(Suit suit, Rank rank)
        {
            this.Suit = suit;
            this.Rank = rank;
        }
    }

    public class Deck
        {
        public List<Card> Cards { get; set; }
        public Deck()
        {
           this.Cards = new List<Card>();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13 ; j++)
                {
                    
                    Card card = new Card((Suit)i, (Rank)j);
                    this.Cards.Add(card);
                }
            }
        }

        public void Shuffle()
        {
          Random rnd = new Random();
          List<Card> newlist = new List<Card>();
          for (int i = 0; i < 52; i++)
          {
              int r = rnd.Next(0,this.Cards.Count);
              newlist.Add(this.Cards[r]);
              this.Cards.Remove(this.Cards[r]);
          }
          this.Cards = newlist;
        }
        public List<Card> Deal(int number)
        {
            List<Card> cards = new List<Card>();
            for (int i = 0; i < number; i++)
            {
                cards.Add(this.Cards[0]);
                this.Cards.Remove(this.Cards[0]);
            }
            return cards;
        }

        }
    
}

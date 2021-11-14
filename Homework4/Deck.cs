using System;
using System.Collections.Generic;
namespace Homework4
{
    public class Deck
    {
    
            List<Card> cards = new List<Card>();
            Rank[] rank = (Rank[])Enum.GetValues(typeof(Rank));
            Suit[] suit = (Suit[])Enum.GetValues(typeof(Suit));
            public Deck()
            {
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                    {
                        cards.Add(new Card(rank.ToString(), suit.ToString()));
                    }
                }
            }
            public int Count
            {
                get { return cards.Count; }
            }

            public bool Empty
            {
                get { return cards.Count == 0; }
            }


            public Card TakeTopCard()
            {
                if (!Empty)
                {
                    Card topCard = cards[cards.Count - 1];
                    cards.RemoveAt(cards.Count - 1);
                    return topCard;
                }
                else
                    return null;
            }

            public void Shuffle()
            {
                Random rand = new Random();

                for (int i = cards.Count - 1; i >= 0; i--)
                {
                    int randomNr = rand.Next(0, i);
                    Card temp = cards[i];
                    cards[i] = cards[randomNr];
                    cards[randomNr] = temp;

                }
            }

        }
    }


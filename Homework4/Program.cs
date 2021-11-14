using System;
using System.Collections.Generic;

namespace Homework4
{

    class Program
    {
        public static int input1, input2, total;
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            deck.Shuffle();
            List<Card> card10 = new List<Card>();
            int max = 10;
            bool pair;
            DealCards(card10, max, ref deck);


            Console.WriteLine("Number of cards left in the deck " + deck.Count);

            Console.WriteLine("\nList of cards:");

            DisplayList(card10, ref deck);
            Console.WriteLine("\nChoose 2 cards from the list\n");

            bool game=true;
            do
            {
                pair = PairCheck(card10, ref deck);

                if (pair)
                {
                    total = SelectTwoCards(card10);
                    if (total == 10)
                    {
                        RemoveAndReplace(card10, ref deck);
                        Console.WriteLine("\nWe removed 2 cards and added 2 others");
                        DisplayList(card10, ref deck);
                        Console.WriteLine("\nNumber of cards left in the deck " + deck.Count);

                        //game = true;
                    }


                }
                else
                {
                    Console.WriteLine("\nThere are no pairs of 10 left");
                    Console.WriteLine("You lost ");

                    //game = false;
                }

            }
            while (pair);
        }

        static bool PairCheck(List<Card> list, ref Deck deck)
        {
            int CardValue;
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    CardValue = 0;
                    CardValue += (int)System.Enum.Parse(typeof(Rank), list[i].Rank) + 1;
                    CardValue += (int)System.Enum.Parse(typeof(Rank), list[j].Rank) + 1;
                    if (CardValue == 10)
                        return true;
                }
            }
            return false;
        }
         static void DealCards(List<Card> list, int max,ref Deck deck)
            {
            for (int i = 0; i < max; i++)
            {
                list.Add(deck.TakeTopCard());
            }

              }
         static void DisplayList(List<Card> list, ref Deck deck)
            {
                if (list.Count == 0)
                {
                    Console.WriteLine("\nThe list is empty");

                }
                else
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        Console.WriteLine(i + 1 + ". " + list[i].Suit + ": " + list[i].Rank);
                    }
                }
              
            }
        static int SelectTwoCards( List<Card> list)
        {

          int CardValue;

                Console.WriteLine("Select your first card: ");

                input1 = Convert.ToInt32(Console.ReadLine());
    
                while (input1 > 10 || input1 < 1)
                    {

                    Console.WriteLine("Choose a different number from " + input1);

                    input1 = Convert.ToInt32(Console.ReadLine());

                    }

                CardValue = (int)System.Enum.Parse(typeof(Rank), list[input1 - 1].Rank) + 1;

                Console.WriteLine("Select your second card: ");

                input2 = Convert.ToInt32(Console.ReadLine());

                 while (input2 > 10 || input2 < 1 || input2 == input1)
                 {
                      if (input2 == input1)
                         {
                           Console.WriteLine("Choose a different number from " + input1);

                           input2 = Convert.ToInt32(Console.ReadLine());

                            }
                      else
                          {
                           Console.WriteLine("Choose a different number between 1 and 10");
                        
                           input2 = Convert.ToInt32(Console.ReadLine());
                          }   


                 }

            CardValue+= (int)System.Enum.Parse(typeof(Rank), list[input2 - 1].Rank) + 1;

            return CardValue;
                
       }
          static void RemoveAndReplace(List<Card> card10, ref Deck deck)
                    {

                        if (input1 < input2)
                        {

                            card10.RemoveAt(input1 - 1);
                            card10.RemoveAt(input2 - 2);
                        }
                        else
                        {
                            card10.RemoveAt(input1 - 2);
                            card10.RemoveAt(input2 - 1);
                        }


                        card10.Add(deck.TakeTopCard());
                        card10.Add(deck.TakeTopCard());
                    }
         }
    }

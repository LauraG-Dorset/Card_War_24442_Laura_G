using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_War
{
    class Card
    {
        public string ShortName { get; set; }
        public string Colour { get; set; }
        public int Value { get; set; }

        public Card(string color, int value)
        {
            Colour = color;
            Value = value;
        }

       /// <summary>
       /// Create the main deck of 52 card (it is not 54 because we play without joker in this game)
       /// </summary>
       /// <returns>returns a queue of 52 elements reprensting the main deck of cards</returns>
       public static Queue<Card> CreateDeck()
        {
            Queue<Card> MainDeck = new Queue<Card>();
            for(int i=1; i<=4; i++)
            {
                if(i==1)
                {
                    for(int j=2; j<=14;j++)
                    {
                        Card card = new Card("spade", j);
                        if(j==14)
                        {
                            card.ShortName = "S" + "A"; //the card is an Ace 
                        }
                        else if(j==13)
                        {
                            card.ShortName = "S" + "K"; //the card is a king 
                        }
                        else if(j==12)
                        {
                            card.ShortName = "S" + "Q"; //the card is a queen
                        }
                        else if(j==11)
                        {
                            card.ShortName = "S" + "J"; //the card is a jack
                        }
                        else card.ShortName = "S" + j.ToString();
                        MainDeck.Enqueue(card);
                    }
                }
                else if(i==2)
                {
                    for (int j = 2; j <= 14; j++)
                    {
                        Card card = new Card("Diamond", j);
                        if (j == 14)
                        {
                            card.ShortName = "D" + "A"; //the card is an Ace 
                        }
                        else if (j == 13)
                        {
                            card.ShortName = "D" + "K"; //the card is a king 
                        }
                        else if (j == 12)
                        {
                            card.ShortName = "D" + "Q"; //the card is a queen
                        }
                        else if (j == 11)
                        {
                            card.ShortName = "D" + "J"; //the card is a jack
                        }
                        else card.ShortName = "D" + j.ToString();
                        MainDeck.Enqueue(card);
                    }
                }
                else if (i == 3)
                {
                    for (int j = 2; j <= 14; j++)
                    {
                        Card card = new Card("Heart", j);
                        if (j == 14)
                        {
                            card.ShortName = "H" + "A"; //the card is an Ace 
                        }
                        else if (j == 13)
                        {
                            card.ShortName = "H" + "K"; //the card is a king 
                        }
                        else if (j == 12)
                        {
                            card.ShortName = "H" + "Q"; //the card is a queen
                        }
                        else if (j == 11)
                        {
                            card.ShortName = "H" + "J"; //the card is a jack
                        }
                        else card.ShortName = "H" + j.ToString();
                        MainDeck.Enqueue(card);
                    }
                }
                else if (i == 4)
                {
                    for (int j = 2; j <= 14; j++)
                    {
                        Card card = new Card("Club", j);
                        if (j == 14)
                        {
                            card.ShortName = "C" + "A"; //the card is an Ace 
                        }
                        else if (j == 13)
                        {
                            card.ShortName = "C" + "K"; //the card is a king 
                        }
                        else if (j == 12)
                        {
                            card.ShortName = "C" + "Q"; //the card is a queen
                        }
                        else if (j == 11)
                        {
                            card.ShortName = "C" + "J"; //the card is a jack
                        }
                        else card.ShortName = "C" + j.ToString();
                        MainDeck.Enqueue(card);
                    }
                }
                else { Console.WriteLine("error"); }
                
            }
            return MainDeck;
        } 
    } 
}

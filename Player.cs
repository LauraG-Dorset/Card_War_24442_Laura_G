using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_War
{
    class Player
    {
        public string Name { get; set; }
        public Queue<Card> Deck { get; set; }

        public Player(string name)
        {
            Name = name;
        }

        /// <summary>
        /// This function alows the player to distribute the cards evenly, 
        /// the player who distributes the cards starts by giving the first card to the other player because that's how we traditionnaly deal cards 
        /// </summary>
        /// <param name="deck">The main deck representing the 52 cards </param>
        /// <param name="player1cards">Player 1's deck</param>
        /// <param name="player2cards">Player 2's deck</param>
        public void Deal(Queue<Card> deck,Queue<Card>player1cards, Queue<Card> player2cards)
        {

            int counter = 2;
            while (deck.Count!=0)
            {
                if (counter % 2 == 0) 
                {
                    player2cards.Enqueue(deck.Dequeue());
                }
                else
                {
                    player1cards.Enqueue(deck.Dequeue());
                }
                counter++;
            }

        }
    }
}

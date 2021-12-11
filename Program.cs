using System;
using System.Collections.Generic;
using System.Linq;

namespace Card_War
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to The Card Battle !!! \n Let's start by initializing the game : \n");
            Console.WriteLine("What is the name of the first player ?");
            string name1 = Convert.ToString(Console.ReadLine());
            Console.WriteLine();
            Player player1 = new Player(name1);
            Console.WriteLine("What is the name of the second player ?");
            string name2 = Convert.ToString(Console.ReadLine());
            Console.WriteLine();
            Player player2 = new Player(name2);
            int answer = 0;
            while (answer !=1 ||answer!=2)
            {
                Console.WriteLine("What type of game do you want to play ? \n \n " +
                      "1) Play 20 turns\n" +
                      "2) Play until one player runs out of cards");
                answer = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (answer == 1) Game(player1, player2, 1);
                else if (answer == 2) Game(player1, player2, 2);
                else Console.WriteLine("please try again");
            }
            

        }
        /// <summary>
        /// Shuffles the main deck using the Fisher Yates or Knuth method
        /// </summary>
        /// <param name="MainDeck">the deck of cards created using the "createDeck" method</param>
        /// <returns>returns a shuffled queue of cards</returns>
        static public Queue<Card> Shuffle(Queue<Card> MainDeck)
        {
            List<Card> listOfCards = MainDeck.ToList();
            Random r = new Random();
            for (int i = 0; i < 52; i++)
            {
                int j = r.Next(0, 52);
                Card memory = listOfCards[j];
                listOfCards[j] = listOfCards[i];
                listOfCards[i] = memory;
            }
            Queue<Card> shuffledDeck = new Queue<Card>();
            foreach (var Card in listOfCards)
            {
                shuffledDeck.Enqueue(Card);
            }
            return shuffledDeck;
        }
       /// <summary>
       /// The game 
       /// </summary>
       /// <param name="player1">Name of the first player</param>
       /// <param name="player2">Name of the second player</param>
       /// <param name="answer"> 1 if we play in 20 turns and 2 if we play until one of the players runs out of cards </param>
        static void Game(Player player1, Player player2,int answer)
        {
            Queue<Card> MainDeck = Card.CreateDeck();
            MainDeck = Shuffle(MainDeck);
            Queue<Card> player1deck = new Queue<Card>();
            Queue<Card> player2deck = new Queue<Card>();
            int numberOfTurns = 1;
            player1.Deal(MainDeck, player1deck, player2deck);
            Queue<Card> Stock = new Queue<Card>();
            bool end = false;
            while (player1deck.Count != 0 && player2deck.Count != 0)
            {
                Console.WriteLine("This is turn number : "+ numberOfTurns);
                Card playedCard1 = player1deck.Dequeue();
                Card playedCard2 = player2deck.Dequeue();

                Stock.Enqueue(playedCard1);
                Stock.Enqueue(playedCard2);

                Console.WriteLine(player1.Name + " plays " + playedCard1.ShortName);
                Console.WriteLine(player2.Name + " plays " + playedCard2.ShortName);

                if (playedCard1.Value > playedCard2.Value)
                {
                    Console.WriteLine(player1.Name + " wins this battle \n");
                    while (Stock.Count != 0)
                    {
                        player1deck.Enqueue(Stock.Dequeue());
                    }
                    Console.WriteLine("Number of Cards in " + player1.Name + "'s deck : " + player1deck.Count());
                    Console.WriteLine("Number of Cards in " + player2.Name + "'s deck : " + player2deck.Count());
                    numberOfTurns++;
                }
                else if (playedCard2.Value > playedCard1.Value)
                {
                    Console.WriteLine(player2.Name + " wins this battle \n");
                    while (Stock.Count != 0)
                    {
                        player2deck.Enqueue(Stock.Dequeue());
                    }
                    Console.WriteLine("Number of Cards in " + player1.Name + "'s deck : " + player1deck.Count());
                    Console.WriteLine("Number of Cards in " + player2.Name + "'s deck : " + player2deck.Count());
                    numberOfTurns++;
                }
                else
                {
                    Console.WriteLine("the cards are equals therefor it's WAR ! " +
                        "\n You will see who won at the next turn \n");
                    if (player1deck.Count > 2 && player2deck.Count > 2)
                    {
                        Stock.Enqueue(player1deck.Dequeue());
                        Stock.Enqueue(player2deck.Dequeue());
                    }
                    else if (player1deck.Count > player2deck.Count) Console.WriteLine(player1.Name + " wins \n");
                    else Console.WriteLine(player2.Name + " wins \n");

                    Console.WriteLine("Number of Cards in " + player1.Name + "'s deck : " + player1deck.Count());
                    Console.WriteLine("Number of Cards in " + player2.Name + "'s deck : " + player2deck.Count());
                    numberOfTurns++;
                }
                if (answer == 1 && numberOfTurns == 20) end = true;
                Console.WriteLine("End of the turn, please press a key to proceed" + "\n");
                Console.ReadKey();
                if (end == true)
                {
                    Console.WriteLine("It is the 20th turn, it is the end of the game ! ");
                    if (player1deck.Count + player2deck.Count != 52)
                    {
                        player1deck.Enqueue(Stock.Dequeue());
                        player2deck.Enqueue(Stock.Dequeue());
                    }
                    if (player1deck.Count > player2deck.Count) Console.WriteLine(player1.Name + " wins");
                    else Console.WriteLine(player2.Name + " wins \n");
                    break;
                }
            }
            if(answer==2)
            {
                Console.WriteLine("One of the players ran out of cards, it is the end of the game ! ");
                if (player1deck.Count == 0) Console.WriteLine(player1.Name + " wins");
                else Console.WriteLine(player2.Name + " wins \n");
            }
            
        }
    
    }
   
}

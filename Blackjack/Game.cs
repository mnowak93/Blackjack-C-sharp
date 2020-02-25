using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Game
    {
        public Player player = new Player();
        public Player dealer = new Player();
        public Deck deck = new Deck();

        public int cardPosistion = 0;
        public bool stand = false;
        public bool bust = false;

        //Constructor creating a player, deck and setting dealer name
        public Game()
        {
            player.CreatePlayer();
            dealer.SetName("Dealer");
            deck.makeDeck();
            deck.Shuffle();
        }

        public void Bet()
        {
            player.PrintBank();
            while (true)
            {
                try
                {
                    Console.Write("Enter your bet: ");
                    int temp = Convert.ToInt32(Console.ReadLine());
                    if (temp > player.GetBank())
                    {
                        Console.Clear();
                        Console.WriteLine("Not enough money");
                        continue;
                    }
                    player.SetBet(temp);
                    break;
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Enter a number!");
                    continue;
                }
            }
        }
    }
}

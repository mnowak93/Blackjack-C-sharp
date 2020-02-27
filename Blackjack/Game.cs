using System;

namespace Blackjack
{
    class Game
    {
        private Player player = new Player();
        private Player dealer = new Player();
        private Deck deck = new Deck();

        private int cardPosistion = 0;
        private bool stand = false;
        private bool bust = false;

        //Constructor creating a player, deck and setting dealer name
        public Game()
        {
            player.CreatePlayer();
            dealer.SetName("Dealer");
        }

        private void AnotherRound()
        {
            if (player.CheckBank())
            {
                string temp = "z";
                Console.Write("\nPlay another round? [Y/N]: ");
                temp = Console.ReadLine();

                while (temp.ToUpper() != "Y" && temp.ToUpper() != "N")
                {
                    Console.WriteLine("Try again: ");
                    temp = Console.ReadLine();
                }

                if (temp.ToUpper() == "Y")
                {
                    Console.Clear();
                    player.PrintRecord();
                    Play();
                }
                else
                {
                    player.PrintRecord();
                    Console.WriteLine("\nThanks for playing");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("You don't have any money");
                Console.ReadLine();
            }
        }

        private void Bet()
        {            
            while (true)
            {
                try
                {
                    Console.Write("\nEnter your bet: ");
                    int temp = Convert.ToInt32(Console.ReadLine());
                    if (temp > player.GetBank())
                    {
                        Console.Clear();
                        Console.WriteLine("Not enough money");
                        continue;
                    }
                    else if (temp <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Bet must be greater than 0");
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

        private void Check4Bust()
        {
            player.CountHand();
            if (player.PlayerHandValue() > 21)
            {
                Console.Clear();
                Console.WriteLine("Player BUSTS (Current hand: {0})!!!", player.PlayerHandValue());
                bust = true;
                stand = true;
                player.CorrectRecord("Bust");
                player.BankCorrection('-');
            }
        }

        private void Check4Win()
        {
            player.CountHand();
            dealer.CountHand();

            if (player.PlayerHandValue() == 21)
            {
                Console.Clear();
                Console.WriteLine("You've got 21!");
                player.CorrectRecord("Win");
                player.BankCorrection('+');
            }
            else if (dealer.PlayerHandValue() > 21)
            {
                Console.WriteLine("\nDealer Bust ({0})", dealer.PlayerHandValue());
                player.CorrectRecord("Win");
                player.BankCorrection('+');
            }
            else if (player.PlayerHandValue() < dealer.PlayerHandValue())
            {
                Console.Clear();
                Console.WriteLine("Player: {0}\nDealer: {1}\nDealer Wins", player.PlayerHandValue(), dealer.PlayerHandValue());
                player.CorrectRecord("Loss");
                player.BankCorrection('-');
            }
            else if (player.PlayerHandValue() > dealer.PlayerHandValue())
            {
                Console.Clear();
                Console.WriteLine("Player: {0}\nDealer: {1}\nYou Win", player.PlayerHandValue(), dealer.PlayerHandValue());
                player.CorrectRecord("Win");
                player.BankCorrection('+');
            }
            else if (player.PlayerHandValue() == dealer.PlayerHandValue())
            {
                Console.Clear();
                Console.WriteLine("Player: {0}\nDealer: {1}\nTie", player.PlayerHandValue(), dealer.PlayerHandValue());
            }
        }

        private void DealerTurn()
        {
            int counter = 0;
            dealer.CountHand();

            Console.Clear();
            if (player.PlayerHandValue() <= 21 && dealer.PlayerHandValue() <= 20)
            {
                while (dealer.PlayerHandValue() < player.PlayerHandValue())
                {
                    dealer.AddCard(deck.GetCard(cardPosistion));
                    cardPosistion++;
                    counter++;
                    dealer.CountHand();
                }
            }

            Console.Clear();
            Console.WriteLine("Dealer took {0} cards\n", counter);

            player.PrintDetails();
            Console.WriteLine();
            dealer.PrintDetails();
        }

        private void GameStart()
        {
            player.AddCard(deck.GetCard(cardPosistion));
            player.AddCard(deck.GetCard(cardPosistion + 1));
            cardPosistion += 2;

            dealer.AddCard(deck.GetCard(cardPosistion));
            dealer.AddCard(deck.GetCard(cardPosistion + 1));
            cardPosistion += 2;

            Console.Clear();
            player.PrintDetails();
            Console.WriteLine();
            dealer.PrintDetails();
        }

        private void Hit()
        {            
            player.AddCard(deck.GetCard(cardPosistion));
            cardPosistion++;

            Console.Clear();
            player.PrintDetails();
            Console.WriteLine();
            dealer.PrintDetails();
        }

        //Main function to play the game
        public void Play()
        {
            stand = false;
            bust = false;
            cardPosistion = 0;
            deck.Shuffle();

            player.ResetHand();
            dealer.ResetHand();
            //player.CountHand();
            //dealer.CountHand();
            Bet();
            GameStart();

            while (stand == false)
            {
                PlayerDecision();
                Check4Bust();
            }

            if (bust == false)
            {
                DealerTurn();
                Check4Win();
            }

            player.PrintBank();
            AnotherRound();
        }

        //Player decision to hit or pass
        private void PlayerDecision()
        {
            string ch = "z";
            while (true)
            {
                Console.Write("\nHit? (Y/N): ");
                ch = Console.ReadLine();
                if (ch.ToUpper() == "Y")
                {
                    Hit();
                    break;
                }
                else if (ch.ToUpper() == "N")
                {
                    stand = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input! Try again!");
                    continue;
                }
            }
        }
    }
}

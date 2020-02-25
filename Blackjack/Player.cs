using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Player
    {
        public Dictionary<string, int> record = new Dictionary<string, int>(){
                                                {"Win",0},
                                                {"Loss",0},
                                                {"Bust",0}
                                            };
        public List<Card> playerHand = new List<Card>();
        public int playerHandValue = 0;
        public int currentBet = 0;
        public int bank = 100;
        public string name = "";

        //Creating player
        public void CreatePlayer()
        {
            Console.Clear();
            Console.Write("Enter your name: ");
            SetName(Console.ReadLine());

            SetBank();
            PrintRecord();
            Console.WriteLine("(press enter)");
            Console.ReadLine();
            Console.Clear();
        }

        //Player setting bank ammount
        public void SetBank()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter your bank amount: ");
                    bank = Convert.ToInt32(Console.ReadLine());
                    if (bank <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Ammount must be greater than 0: ");
                        continue;
                    }
                    break;
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Wrong ammount, try again!");
                    continue;
                }
            }
        }

        public int GetBank()
        {
            return bank;
        }

        //Setting a name for player
        public void SetName(string newName)
        {
            name = newName;
        }

        //Printing player record
        public void PrintRecord()
        {
            Console.Clear();
            Console.WriteLine("Player: {0}", name);
            Console.WriteLine("Bank: {0}", bank);
            Console.WriteLine("Wins: {0}, Losses: {1}, Busts: {2}", record["Win"], record["Loss"], record["Bust"]);
        }

        //adding card do player hand
        public void addCard(Card crd)
        {
            playerHand.Add(crd);
        }

        //printing player hand
        public void PrintHand()
        {
            Console.WriteLine("Player: {0}", name);
            foreach (Card crd in playerHand)
            {
                crd.PrintCard();
            }
            Console.WriteLine("Total: {0}", playerHandValue);
        }

        public void PrintBank()
        {
            Console.WriteLine("Bank: {0}", bank);
        }

        //printing value of current bet
        public void PrintBet()
        {
            Console.WriteLine("Current bet: {0}", currentBet);
        }
    
        //Setting a new bet    
        public void SetBet(int newBet)
        {
            currentBet = newBet;
        }

        //Getting a bet value;
        public int GetBet()
        {
            return currentBet;
        }

        //counting sum of player hand
        public void CountHand()
        {
            playerHandValue = 0;
            foreach (Card crd in playerHand)
            {
                playerHandValue += crd.value;
            }
        }

        //reseting hand of player in preparation for another round
        public void ResetHand()
        {
            playerHand.Clear();
            playerHandValue = 0;
        }

        //cheching the bank if ammount is greater than 0 returning true, if not return false
        public bool CheckBank()
        {
            if (bank > 0) return true;
            else return false;
        }

        //adding or subtracting current Bet to player bank 
        public void BankCorrection(char ch)
        {
            if (ch == '-') bank -= currentBet;
            else bank += Convert.ToInt32(currentBet * 1.5);
        }
    }
}

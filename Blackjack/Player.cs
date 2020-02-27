using System;
using System.Collections.Generic;

namespace Blackjack
{
    class Player
    {
        private Dictionary<string, int> record = new Dictionary<string, int>(){
                                                {"Win",0},
                                                {"Loss",0},
                                                {"Bust",0}
                                            };
        private List<Card> playerHand = new List<Card>();
        private int playerHandValue = 0;
        private int currentBet = 0;
        private int bank = 100;
        private string name = "";

        //Adding card do player hand
        public void AddCard(Card crd)
        {
            playerHand.Add(crd);
        }

        //adding or subtracting current Bet to player bank 
        public void BankCorrection(char ch)
        {
            if (ch == '-') bank -= currentBet;
            else bank += Convert.ToInt32(currentBet * 1.5);
        }

        //cheching the bank if ammount is greater than 0 returning true, if not return false
        public bool CheckBank()
        {
            if (bank > 0) return true;
            else return false;
        }

        public void CountHand()
        {
            playerHandValue = 0;
            foreach (Card crd in playerHand)
            {
                playerHandValue += crd.GetValue();
            }
        }

        public void CorrectRecord(string str)
        {
            record[str] += 1;
        }

        //Creating player
        public void CreatePlayer()
        {
            Console.Clear();
            Console.Write("Enter your name: ");
            SetName(Console.ReadLine());

            SetBank();
            PrintRecord();
        }

        public int GetBank()
        {
            return bank;
        }

        public int PlayerHandValue()
        {
            return playerHandValue;
        }

        public void PrintBank()
        {
            Console.WriteLine("Bank: {0}", bank);
        }

        public void PrintDetails()
        {
            PrintName();
            PrintHand();
        }

        //printing player hand
        public void PrintHand()
        {
            Console.WriteLine("Player: {0}", name);
            foreach (Card crd in playerHand)
            {
                crd.PrintCard();
            }
            CountHand();
            Console.WriteLine("Total: {0}", playerHandValue);
        }

        public void PrintName()
        {
            Console.WriteLine("{0}: ", name);
        }

        //Printing player record
        public void PrintRecord()
        {
            Console.Clear();
            Console.WriteLine("Player: {0}", name);
            Console.WriteLine("Bank: {0}", bank);
            Console.WriteLine("Wins: {0}, Losses: {1}, Busts: {2}", record["Win"], record["Loss"], record["Bust"]);
        }

        //reseting hand of player in preparation for another round
        public void ResetHand()
        {
            playerHand.Clear();
            playerHandValue = 0;
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

        public void SetBet(int newBet)
        {
            currentBet = newBet;
        }

        //Setting a name for player
        public void SetName(string newName)
        {
            name = newName;
        }
    }
}

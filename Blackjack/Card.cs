using System;

namespace Blackjack
{
    public class Card
    {
        private string suit = "";
        private string rank = "";
        private int value = 0;

        //Constructor
        public Card(string argSuit, string argRank)
        {
            suit = argSuit;
            rank = argRank;
        }

        public string GetRank()
        {
            return rank;
        }

        public int GetValue()
        {
            return value;
        }

        //Printing card
        public void PrintCard()
        {
            Console.WriteLine("Card: {0} of {1}", rank, suit);
        }

        //Adding value to the card
        public void SetValue(int argValue)
        {
            value = argValue;
        }            
    }
}

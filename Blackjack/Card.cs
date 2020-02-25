using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Card
    {
        public string suit = "";
        public string rank = "";
        public int value = 0;
        public bool used = false;

        //Constructor
        public Card(string argSuit, string argRank)
        {
            suit = argSuit;
            rank = argRank;
        }

        //Function changing used to true value (card is used)
        public void CardUsed()
        {
            used = true;
        }

        //Function changing used to false value (card is in deck)
        public void CardNotUsed()
        {
            used = false;
        }

        //Adding value to the card
        public void SetValue(int argValue)
        {
            value = argValue;
        }

        //Printing card
        public void PrintCard()
        {
            Console.WriteLine("Card: {0} of {1}", rank, suit);
        }
    }
}

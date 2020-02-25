using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Deck
    {
        public string[] arrSuits = { "Hearts", "Diamonds", "Clubs", "Spades" };
        public string[] arrRanks = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        private static Random rng = new Random();

        public List<Card> cardDeck = new List<Card>();

        //Creating deck
        public void makeDeck()
        {   
            //Making new instances of Card object in the list
            foreach (string strSuit in arrSuits)
            {
                foreach (string strRank in arrRanks)
                {
                    cardDeck.Add(new Card(strSuit, strRank));
                }
            }
            AddValue();            
        }

        //Adding values to cards
        public void AddValue()
        {
            foreach (Card tempCard in cardDeck)
            {
                switch (tempCard.rank)
                {
                    case "A":
                        tempCard.SetValue(11);
                        break;
                    case "2":
                        tempCard.SetValue(2);
                        break;
                    case "3":
                        tempCard.SetValue(3);
                        break;
                    case "4":
                        tempCard.SetValue(4);
                        break;
                    case "5":
                        tempCard.SetValue(5);
                        break;
                    case "6":
                        tempCard.SetValue(6);
                        break;
                    case "7":
                        tempCard.SetValue(7);
                        break;
                    case "8":
                        tempCard.SetValue(8);
                        break;
                    case "9":
                        tempCard.SetValue(9);
                        break;
                    case "10":
                        tempCard.SetValue(10);
                        break;
                    case "J":
                        tempCard.SetValue(10);
                        break;
                    case "Q":
                        tempCard.SetValue(10);
                        break;
                    case "K":
                        tempCard.SetValue(10);
                        break;
                    default:
                        tempCard.SetValue(0);
                        break;
                }
            }
        }

        //Shuffling the deck
        public void Shuffle()
        {
            int n = cardDeck.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = cardDeck[k];
                cardDeck[k] = cardDeck[n];
                cardDeck[n] = value;
            }
        }

        //Printing card from deck
        public void PrintCard(int i)
        {
            cardDeck[i].PrintCard();
            Console.WriteLine(cardDeck[i].value);
        }

        //Geting value of card from deck
        public int GetValueFromDeck(int i)
        {
            return cardDeck[i].value;
        }

        //Removing card from deck
        public void RemoveCard(int i)
        {
            cardDeck[i].CardUsed();
        }

        //Adding all cards back to deck
        public void ResetDeck()
        {
            foreach (Card card in cardDeck) card.CardNotUsed();
        }
    }
}

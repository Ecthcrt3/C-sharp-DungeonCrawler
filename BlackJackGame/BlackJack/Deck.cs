using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Deck
    {
        List<Card> deck = new List<Card> 
        { 
            new Card("Two", 2, "Clubs"),
            new Card("Three", 3, "Clubs"),
            new Card("Four", 4, "Clubs"),
            new Card("Five", 5, "Clubs"),
            new Card("Six", 6, "Clubs"),
            new Card("Seven", 7, "Clubs"),
            new Card("Eight", 8, "Clubs"),
            new Card("Nine", 9, "Clubs"),
            new Card("Ten", 10, "Clubs"),
            new Card("Jack", 10, "Clubs"),
            new Card("Queen", 10, "Clubs"),
            new Card("King", 10, "Clubs"),
            new Card("Ace", 11, "Clubs"),

            new Card("Two", 2, "Hearts"),
            new Card("Three", 3, "Hearts"),
            new Card("Four", 4, "Hearts"),
            new Card("Five", 5, "Hearts"),
            new Card("Six", 6, "Hearts"),
            new Card("Seven", 7, "Hearts"),
            new Card("Eight", 8, "Hearts"),
            new Card("Nine", 9, "Hearts"),
            new Card("Ten", 10, "Hearts"),
            new Card("Jack", 10, "Hearts"),
            new Card("Queen", 10, "Hearts"),
            new Card("King", 10, "Hearts"),
            new Card("Ace", 11, "Hearts"),

            new Card("Two", 2, "Spades"),
            new Card("Three", 3, "Spades"),
            new Card("Four", 4, "Spades"),
            new Card("Five", 5, "Spades"),
            new Card("Six", 6, "Spades"),
            new Card("Seven", 7, "Spades"),
            new Card("Eight", 8, "Spades"),
            new Card("Nine", 9, "Spades"),
            new Card("Ten", 10, "Spades"),
            new Card("Jack", 10, "Spades"),
            new Card("Queen", 10, "Spades"),
            new Card("King", 10, "Spades"),
            new Card("Ace", 11, "Spades"),

            new Card("Two", 2, "Diamonds"),
            new Card("Three", 3, "Diamonds"),
            new Card("Four", 4, "Diamonds"),
            new Card("Five", 5, "Diamonds"),
            new Card("Six", 6, "Diamonds"),
            new Card("Seven", 7, "Diamonds"),
            new Card("Eight", 8, "Diamonds"),
            new Card("Nine", 9, "Diamonds"),
            new Card("Ten", 10, "Diamonds"),
            new Card("Jack", 10, "Diamonds"),
            new Card("Queen", 10, "Diamonds"),
            new Card("King", 10, "Diamonds"),
            new Card("Ace", 11, "Diamonds"),
        };//end list

        public Deck()
        {
        }

        public Card Deal()
        {
            Random rand = new Random();
            Card chosenCard = deck[rand.Next(deck.Count()-1)];
            deck.Remove(chosenCard);
            return chosenCard;
        }

        public int Count()
        {
            return deck.Count();
        }
    }
}

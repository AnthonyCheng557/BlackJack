using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackjackApp.Models
{
     /* This Model is a class. The class represents a single playing card
     * in BlackJack. There are two string instance variables, (Suit, and Rank). */
    public class Card
    {
        //String Instance Variables
        public string Suit { get; set; }
        public string Rank { get; set; }
        /*Switch, similiar to If else Statements, controls the flow of code
         * based on the value of given epression. "A"=> 11 */
        public int Value => Rank switch
        {
            "A" => 11,
            "K" or "Q" or "J" => 10,
            _ => int.Parse(Rank)
            
        };
        //ImagePath needed for Razor.
        public string ImagePath => $"/Images/{Rank.ToLower()}_of_{Suit.ToLower()}.png";
        /* Not needed, compiler will generate a constructor for you.
        public Card(string rank, string suit)
        {
            Rank = rank;
            Suit = suit;
                  
        }
        */


    }

    /* Below is a Deck that represents the 52 playable cards
     * in BlackJack. */
    public class Deck
    {
        //A list of Card object
        private List<Card> cards = new List<Card>();
        //A random object that genereates a random number
        private Random rnd = new Random();


        public Deck()
        {
            var suits = new[] { "Hearts", "Diamonds", "Clubs", "Spades" };
            var ranks = new[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            foreach (var suit in suits)
                foreach (var rank in ranks)
                    cards.Add(new Card { Suit = suit, Rank = rank });

            Shuffle();
        }


        public void Shuffle()
        {
            cards = cards.OrderBy(c => rnd.Next()).ToList();
        }
        //Draw a card from the front of the list., store it into a card object, while removing the first element.
        public Card Draw()
        {
            var card = cards[0];
            cards.RemoveAt(0);
            return card;
        }
    }

    /* A BlackJack game instance. There are two players, you and a dealer. 
     * Provides methods in order to handle the logic of the game.*/
    public class BlackjackGame
    {
        //Create an instance of the Deck
        private Deck deck = new Deck();
        //Create two instances of List of Cards.
        public List<Card> PlayerHand { get; set; } = new List<Card>();
        public List<Card> DealerHand { get; set; } = new List<Card>();
        public string Result { get; set; }

        public void Start()
        {
            //Clear their respective hands
            PlayerHand.Clear();
            DealerHand.Clear();
            //Reset the Deck
            deck = new Deck();
            //Draw
            PlayerHand.Add(deck.Draw());
            PlayerHand.Add(deck.Draw());
            DealerHand.Add(deck.Draw());
            DealerHand.Add(deck.Draw());

            Result = string.Empty;
        }
        //Player Hit, draw a card, if value is greater than 21 then bust.
        public void PlayerHit()
        {

            PlayerHand.Add(deck.Draw());
            if (PlayerHand.Sum(c => c.Value) > 21)
                Result = "Bust! Dealer Wins!";
        }
        /* when DealerPlays he draws his final card. Whielt the total value is < 17, keep drawing.
           Finally Logic is handled based on the outcome of the score. */
        public void DealerPlay()
        {
            while (DealerHand.Sum(c => c.Value) < 17)
                DealerHand.Add(deck.Draw());

            int playerScore = PlayerHand.Sum(c => c.Value);
            int dealerScore = DealerHand.Sum(c => c.Value);
            Console.WriteLine(playerScore + " " + dealerScore);

            //Special case for BlackJack results
            if (playerScore == 21 && dealerScore == 21)
            {
                Result = "Tie! Both Party got BlackJack";
                return;
            }
            else if (playerScore == 21) 
            {
                Result = "Player Wins! BlackJack!";
                return;
            }

            //Normal results
            if (dealerScore > 21 || playerScore > dealerScore || playerScore == 21)
            {
                Result = "Player Wins!";

            }
            else if (dealerScore > playerScore)
            {
                Result = "Dealer Wins!";
            }
            else
            {
                Result = "Tie!";
            }
        }
    }
}

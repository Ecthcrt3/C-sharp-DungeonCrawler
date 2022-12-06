namespace BlackJack
{
    internal class Gameplay
    {
        static void Main(string[] args)
        {
            bool isPlaying = true;
            bool isStanding = false;
            bool busted = false;
            bool dealerBusted = false;
            string userInput, userName;
            int dealerTotal = 0, handTotal = 0;


            Console.Title = "--&& BlackJack &&--";
            Console.WriteLine("Welcome to the BlackJack table!\n" +
                "\nPlease enter your name or type \"exit\" to quit\n");
           
            userName = Console.ReadLine();

            if(userName.ToLower() == "exit")
            {
                isPlaying = false;
            }
            Deck playDeck = new Deck();
            while (isPlaying)
            {
                if(playDeck.Count() < 10)
                {
                    playDeck = new Deck();
                }
                Console.Clear();
                isStanding = false;
                busted = false;
                dealerBusted = false;
                List<Card> playerHand = new List<Card>();
                List<Card> computerHand = new List<Card>();

                for(int i = 0; i < 2; i++)
                {
                    playerHand.Add(playDeck.Deal());
                    computerHand.Add(playDeck.Deal());
                }

                do
                {
                    Console.Clear();
                    handTotal = 0;
                    Console.WriteLine($"Dealer's Hand: {computerHand[1].Name}, Face down card");
                    Console.Write($"\n\n{userName}'s Hand: ");
                    int numberOfAces = 0;
                    foreach(var card in playerHand)
                    {
                        if(card.Name == "Ace")
                        {
                            numberOfAces++;
                        }
                        Console.Write(card.Name + ", ");
                        handTotal += card.FaceValue;
                        if(handTotal > 21)
                        {
                            handTotal -= 10 * numberOfAces;
                        }
                    }
                    Console.WriteLine("\n\nYour total is:" + handTotal);

                    if(handTotal > 21)
                    {
                        Console.WriteLine("\nYou Bust! Better luck next time");
                        isStanding = true;
                        busted = true;
                    }
                    if (handTotal == 21) { Console.WriteLine("BLACKJACK!"); isStanding = true; }

                    if (!busted && !isStanding)
                    {
                        Console.WriteLine("\nWould you like to: " +
                            "\n1) Hit" +
                            "\n2) Stand");
                        userInput = Console.ReadLine().ToUpper();
                        switch (userInput)
                        {
                            case "1":
                            case "H":
                            case "HIT":
                                playerHand.Add(playDeck.Deal());
                                break;
                            case "2":
                            case "S":
                            case "STAND":
                                isStanding = true;
                                break;
                            default:
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Input not recognized, please try again. . .");
                                Console.ResetColor();
                                break;
                        }
                    }
                } while (!isStanding);

                if (!busted)
                {
                    isStanding = false; 
                    do
                    {
                        dealerTotal = 0;
                        Console.Clear();
                        int numberOfAces = 0;
                        Console.Write("Dealer's Hand: ");
                        foreach (var card in computerHand)
                        {
                            if (card.Name == "Ace")
                            {
                                numberOfAces++;
                            }
                            Console.Write(card.Name + ", ");
                            dealerTotal += card.FaceValue;
                            if (handTotal > 21)
                            {
                                handTotal -= 10 * numberOfAces;
                            }
                        }
                        if (dealerTotal < 17)
                        {
                            computerHand.Add(playDeck.Deal());
                        }
                        else if (dealerTotal >= 17 && dealerTotal <= 21)
                        {
                            Console.WriteLine("\n\nThe dealer stands at " + dealerTotal);
                            isStanding = true;
                        }
                        else
                        {
                            Console.WriteLine("\nDealer Busted!");
                            dealerBusted = true;
                            isStanding = true;
                        }

                        Console.Write($"\n\n{userName}'s Hand: ");
                        foreach (var card in playerHand)
                        {
                            Console.Write(card.Name + ", ");
                        }
                        Console.WriteLine("\n\nYour total is: " + handTotal + "\n\n");
                    } while (!isStanding);
                }
                if (!busted)
                {
                    if (handTotal < dealerTotal && !dealerBusted)
                    {
                        Console.WriteLine("You Lose Better luck next time!");
                    }
                    else if (handTotal == dealerTotal)
                    {
                        Console.WriteLine("Tie game");
                    }
                    else if (handTotal > dealerTotal)
                    {
                        Console.WriteLine("Congratulations you win!");
                    }
                }


                Console.WriteLine("\nWould you like to quit? Y/N");
                userInput = Console.ReadLine().ToUpper();
                if(userInput == "Y")
                {
                    isPlaying = false;
                }
            }
            Console.WriteLine("Thank You for playing!");
        }
    }
}
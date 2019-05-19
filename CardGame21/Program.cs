using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame21
{
    public enum CardSuit { Spades, Hearts, Clubs, Diamonds }
    public enum CardsValue { Six = 6, Seven = 7, Eight = 8, Nine = 9, Ten = 10, Jack = 2, Lady = 3, King = 4, Ace = 11 }

    struct Card
    {
        public CardsValue _cardsValue;
        public CardSuit _cardSuit;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Game();
        }

        static void CreateDeck(Card[] _deck)
        {
            for (int i = 0; i < 36; i++)
            {
                switch (i / 9)
                {
                    case 0:
                        _deck[i]._cardSuit = CardSuit.Spades;
                        break;
                    case 1:
                        _deck[i]._cardSuit = CardSuit.Hearts;
                        break;
                    case 2:
                        _deck[i]._cardSuit = CardSuit.Clubs;
                        break;
                    case 3:
                        _deck[i]._cardSuit = CardSuit.Diamonds;
                        break;
                }
                switch (i % 9)
                {
                    case 0:
                        _deck[i]._cardsValue = CardsValue.Ace;
                        break;
                    case 1:
                        _deck[i]._cardsValue = CardsValue.King;
                        break;
                    case 2:
                        _deck[i]._cardsValue = CardsValue.Lady;
                        break;
                    case 3:
                        _deck[i]._cardsValue = CardsValue.Jack;
                        break;
                    case 4:
                        _deck[i]._cardsValue = CardsValue.Ten;
                        break;
                    case 5:
                        _deck[i]._cardsValue = CardsValue.Nine;
                        break;
                    case 6:
                        _deck[i]._cardsValue = CardsValue.Eight;
                        break;
                    case 7:
                        _deck[i]._cardsValue = CardsValue.Seven;
                        break;
                    case 8:
                        _deck[i]._cardsValue = CardsValue.Six;
                        break;
                }
            }
        }

        static void ShuffleDeck(Card[] cards)
        {
            Random rand = new Random();
            Card tempcard;
            for (int i = 0; i < cards.Length; i++)
            {
                int randindex = rand.Next(1, 35);
                tempcard = cards[i];
                cards[i] = cards[randindex];
                cards[randindex] = tempcard;
            }
        }

        static bool Validation()
        {
            string answer = "";
            while (true)
            {
                Console.WriteLine("Do you want to play more game?(y/n)");
                answer = Console.ReadLine();
                if (answer == "y")
                {
                    return true;

                }
                else if (answer == "n")
                {
                    return false;
                }
                else
                    Console.WriteLine("You don't write correct answer!");
            }
        }

        static bool ChooseHand()
        {
            string handanswer = "";
            while (true)
            {
                Console.WriteLine("Now you will select Who receives first cards! (p/c)");
                handanswer = Console.ReadLine();
                if (handanswer == "p")
                {
                    return true;

                }
                else if (handanswer == "c")
                {
                    return false;
                }
                else
                    Console.WriteLine("You don't write correct answer!");
            }
        }

        static void Game()
        {
            int drawScore = 0;
            int playerScore = 0;
            int computerScore = 0;
            int countofGames = 1;
            int computerValueSum = 0;
            int playerValueSum = 0;
            Card[] _gamedeck = new Card[36];
            CreateDeck(_gamedeck);
            for (int i = 0; i < _gamedeck.Length; i++)
            {
                bool BlackJack = false;
                bool endgame = false;
                bool hand = false;
                if (i == 0)
                {
                    Console.WriteLine("###############################");
                    Console.WriteLine($"START GAME - {countofGames} RESULT: PLAYER SCORE - {playerScore} | COMPUTER SCORE - {computerScore} | DRAW - {drawScore}");
                    Console.WriteLine("###############################");
                    ShuffleDeck(_gamedeck);
                    countofGames++;
                    hand = ChooseHand();
                }
                if (computerValueSum < 22 && playerValueSum < 22)
                {
                    if (hand == true)
                    {
                        while (i < 2 && BlackJack == false)
                        {
                            playerValueSum += (int)_gamedeck[i]._cardsValue;
                            Console.WriteLine($"{_gamedeck[i]._cardsValue} of {_gamedeck[i]._cardSuit}");
                            Console.WriteLine($"PLAYER SCORE = { playerValueSum}");
                            i++;
                            if (playerValueSum == 21 || playerValueSum == 22)
                            {
                                Console.WriteLine("PLAYER WIN!!! YOU VERY LUCKY!!!");
                                playerScore++;
                                if (Validation() == true)
                                {
                                    i = -1;
                                    computerValueSum = 0;
                                    playerValueSum = 0;
                                    BlackJack = true;
                                }
                                else
                                {
                                    Console.WriteLine($"Result: Player win = {playerScore}  Computer win = {computerScore}  Draw - {drawScore}");
                                    endgame = true;
                                    break;
                                }
                            }
                        }
                        while (i < 4 && BlackJack == false && endgame == false)
                        {
                            computerValueSum += (int)_gamedeck[i]._cardsValue;
                            i++;
                            if (computerValueSum == 21 || computerValueSum == 22)
                            {
                                Console.WriteLine($"COMPUTER WIN! SCORE - {computerValueSum}  MACHINE IS VERY LUCKY");
                                computerScore++;
                                if (Validation() == true)
                                {
                                    i = -1;
                                    computerValueSum = 0;
                                    playerValueSum = 0;
                                    BlackJack = true;
                                }
                                else
                                {
                                    Console.WriteLine($"Result: Player win = {playerScore}  Computer win = {computerScore}  Draw - {drawScore}");
                                    endgame = true;
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        while (i < 2 && BlackJack == false)
                        {
                            computerValueSum += (int)_gamedeck[i]._cardsValue;
                            i++;
                            if (computerValueSum == 21 || computerValueSum == 22)
                            {
                                Console.WriteLine("COMPUTER WIN! MACHINE IS VERY LUCKY");
                                Console.WriteLine($"COMPUTER SCORE = {computerValueSum}");
                                computerScore++;
                                if (Validation() == true)
                                {
                                    i = -1;
                                    computerValueSum = 0;
                                    playerValueSum = 0;
                                    BlackJack = true;
                                }
                                else
                                {
                                    Console.WriteLine($"Result: Player win = {playerScore}  Computer win = {computerScore}  Draw - {drawScore}");
                                    endgame = true;
                                    break;
                                }
                            }
                        }
                        while (i < 4 && BlackJack == false && endgame == false)
                        {
                            playerValueSum += (int)_gamedeck[i]._cardsValue;
                            Console.WriteLine($"{_gamedeck[i]._cardsValue} of {_gamedeck[i]._cardSuit}");
                            Console.WriteLine($"PLAYER SCORE = { playerValueSum}");
                            i++;
                            if (playerValueSum == 21 || playerValueSum == 22)
                            {
                                Console.WriteLine("PLAYER WIN!!! YOU VERY LUCKY!!!");
                                playerScore++;
                                if (Validation() == true)
                                {
                                    i = -1;
                                    computerValueSum = 0;
                                    playerValueSum = 0;
                                    BlackJack = true;
                                }
                                else
                                {
                                    Console.WriteLine($"Result: Player win = {playerScore}  Computer win = {computerScore}  Draw - {drawScore}");
                                    endgame = true;
                                    break;
                                }
                            }
                        }
                    }

                    // Player must choose: take additional card or stop game
                    if (endgame == true)
                        break;
                    if (BlackJack == false)
                    {
                        Console.WriteLine("Do you want to take additional card?(y/n)");
                        string answer = Console.ReadLine();
                        if (answer == "y")
                        {
                            playerValueSum += (int)_gamedeck[i]._cardsValue;
                            Console.WriteLine($"{_gamedeck[i]._cardsValue} of {_gamedeck[i]._cardSuit}");
                            Console.WriteLine($"PLAYER SCORE = { playerValueSum}");
                            i++;
                        }
                        else if (answer == "n")
                        {
                            while (computerValueSum < 17)
                            {
                                computerValueSum += (int)_gamedeck[i]._cardsValue;
                                Console.WriteLine($"{_gamedeck[i]._cardsValue} of {_gamedeck[i]._cardSuit}");
                                Console.WriteLine($"COMPUTER SCORE = {computerValueSum}");
                                i++;
                            }
                            if (computerValueSum > 21)
                            {
                                Console.WriteLine($"PLAYER WIN!");
                                playerScore++;
                                if (Validation() == true)
                                {
                                    i = -1;
                                    computerValueSum = 0;
                                    playerValueSum = 0;
                                }
                                else
                                {
                                    Console.WriteLine($"Result: Player win = {playerScore}  Computer win = {computerScore}  Draw - {drawScore}");
                                    break;
                                }
                            }
                            else
                            {
                                if (computerValueSum < playerValueSum)
                                {
                                    Console.WriteLine($"PLAYER WIN! COMPUTER SCORE = {computerValueSum} ");
                                    playerScore++;
                                }
                                else if (computerValueSum == playerValueSum)
                                {
                                    Console.WriteLine("Draw!");
                                    drawScore++;
                                }
                                else
                                {
                                    Console.WriteLine($"COMPUTER WIN! COMPUTER SCORE = {computerValueSum}");
                                    computerScore++;
                                }
                                if (Validation() == true)
                                {
                                    i = -1;
                                    computerValueSum = 0;
                                    playerValueSum = 0;
                                }
                                else
                                {
                                    Console.WriteLine($"Result: Player win = {playerScore}  Computer win = {computerScore}  Draw - {drawScore}");
                                    break;
                                }
                            }
                        }
                        else
                            Console.WriteLine("You don't write correct answer!");
                    }
                }
                else
                {
                    if (computerValueSum > playerValueSum)
                    {
                        Console.WriteLine("PLAYER WIN!");
                        playerScore++;
                    }
                    else if (computerValueSum == playerValueSum)
                    {
                        Console.WriteLine("Draw!");
                        drawScore++;
                    }
                    else
                    {
                        Console.WriteLine($"Computer WIN! COMPUTER SCORE - {computerValueSum}");
                        computerScore++;
                    }
                    if (Validation() == true)
                    {
                        i = -1;
                        computerValueSum = 0;
                        playerValueSum = 0;
                    }
                    else
                    {
                        Console.WriteLine($"Result: Player win = {playerScore}  Computer win = {computerScore}  Draw - {drawScore}");
                        break;
                    }
                }
            }
        }
    }
}

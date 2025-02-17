using System;

namespace L20250204  // 네임스페이스 선언
{
    internal class Program  // 클래스 시작 (반드시 중괄호 `{}` 필요)
    {
        static void Initialize(int[] deck)
        {
            for (int i = 0; i < deck.Length; i++)
            {
                deck[i] = i + 1;
            }
        }

        static void Shuffle(int[] deck)
        {
            Random random = new Random();

            for (int i = 0; i < deck.Length * 10; ++i)
            {
                int firstCardIndex = random.Next(0, deck.Length);
                int secondCardIndex = random.Next(0, deck.Length);

                // 두 카드를 교환 (Swap)
                int temp = deck[firstCardIndex];
                deck[firstCardIndex] = deck[secondCardIndex];
                deck[secondCardIndex] = temp;
            }
        }

        enum CardType
        {
            None = -1,
            Heart = 0,
            Diamond = 1,
            Clover = 2,
            Spade = 3,
        }

        static int GetScore(int cardNumber)
        {
            int value = (((cardNumber - 1) % 13) + 1);
            return value > 10 ? 10 : value;
        }

        static void PrintCardList(int[] deck)
        {
            Console.WriteLine("Computer");
            for (int i = 0; i < 3; ++i)
            {
                Console.WriteLine($"{CheckCardType(deck[i])} {CheckCardName(deck[i])}");
            }
            Console.WriteLine("-------------");

            Console.WriteLine("Player");
            for (int i = 3; i < 6; ++i)
            {
                Console.WriteLine($"{CheckCardType(deck[i])} {CheckCardName(deck[i])}");
            }
            Console.WriteLine("-------------");
        }

        static void Print(int[] deck)
        {
            PrintCardList(deck);

            int computerScore = GetScore(deck[0]) + GetScore(deck[1]) + GetScore(deck[2]);
            int playerScore = GetScore(deck[3]) + GetScore(deck[4]) + GetScore(deck[5]);

            Console.WriteLine($"Computer Score: {computerScore}, Player Score: {playerScore}");

            if (playerScore > 21 && computerScore <= 21)
            {
                Console.WriteLine("Computer Win");
            }
            else if (computerScore > 21 && playerScore <= 21)
            {
                Console.WriteLine("Player Win");
            }
            else if (playerScore > 21 && computerScore > 21)
            {
                Console.WriteLine("Draw");
            }
            else if (computerScore < playerScore)
            {
                Console.WriteLine("Player Win");
            }
            else if (computerScore > playerScore)
            {
                Console.WriteLine("Computer Win");
            }
            else
            {
                Console.WriteLine("Draw");
            }
        }

        static CardType CheckCardType(int cardNumber)
        {
            int valueType = (cardNumber - 1) / 13;
            return (CardType)valueType;
        }

        static string CheckCardName(int cardNumber)
        {
            int cardValue = ((cardNumber - 1) % 13) + 1;
            switch (cardValue)
            {
                case 1: return "A";
                case 11: return "J";
                case 12: return "Q";
                case 13: return "K";
                default: return cardValue.ToString();
            }
        }

        static void Main(string[] args)
        {
            int[] deck = new int[52];

            Initialize(deck);
            Shuffle(deck);
            Print(deck);
        }
    }  // 클래스 Program의 끝
}  // 네임스페이스 L20250204의 끝

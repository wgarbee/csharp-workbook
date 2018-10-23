using System;
using System.Threading;

namespace RockPaperScissors
{
    class Program
    {
        public static void Main()
        {
            getUserInput();
        }

        public static void getUserInput()
        {
            Console.Clear();  // Clears the console prior to game start
            Console.WriteLine("Welcome to Rock | Paper | Scissors!");
            Console.WriteLine("When prompted, type either 'Rock', 'Paper', or 'Scissors' without single quotes.");
            Thread.Sleep(1000);
            Console.WriteLine("Type 'Quit' without single quotes to stop playing");
            Console.WriteLine("Enter hand 1: ");
            string hand1 = Console.ReadLine();
            Console.Clear();

            // If the user enters the word quit, terminates the program and clears the console
            while (hand1.ToUpper() != "QUIT")
            {
                // Random number generator for computer turn that is then assigned
                Random randNum = new Random();
                string hand2 = Convert.ToString(randNum.Next(1, 4));

                // Calls the method that checks who the winner is
                CompareHands(hand1, hand2);

                Thread.Sleep(500);
                
                Console.WriteLine("Type either 'Rock', 'Paper', or 'Scissors' without single quotes to play again!");
                Console.WriteLine("Type 'Quit' without single quotes to stop playing");
                hand1 = Console.ReadLine();
                Console.Clear();

            }

            Console.Clear();
        }
        
        public static string CompareHands(string hand1, string hand2)
        {
            // Your code here
            if (hand2 == "1")
            {
                hand2 = "Rock";
            }
            else if (hand2 == "2")
            {
                hand2 = "Paper";
            }
            else
            {
                hand2 = "Scissors";
            }

            if (hand1.ToUpper() == hand2.ToUpper())
            {
                Console.WriteLine(hand1 + ' ' + hand2);
                Console.WriteLine("It's a tie!");
            } 
            else if (hand1.ToUpper() == "ROCK")
            {
                if (hand2.ToUpper() == "PAPER")
                {
                    Console.WriteLine(hand1 + ' ' + hand2);
                    Console.WriteLine("Computer wins!");
                }
                else if (hand2.ToUpper() == "SCISSORS")
                {
                    Console.WriteLine(hand1 + ' ' + hand2);
                    Console.WriteLine("Player wins!");
                }
            }
            else if (hand1.ToUpper() == "PAPER")
            {
                if (hand2.ToUpper() == "ROCK")
                {
                    Console.WriteLine(hand1 + ' ' + hand2);
                    Console.WriteLine("Player wins!");
                }
                else if (hand2.ToUpper() == "SCISSORS")
                {
                    Console.WriteLine(hand1 + ' ' + hand2);
                    Console.WriteLine("Computer wins!");
                }
            }
            else if (hand1.ToUpper() == "SCISSORS")
            {
                if (hand2.ToUpper() == "ROCK")
                {
                    Console.WriteLine(hand1 + ' ' + hand2);
                    Console.WriteLine("Computer wins!");
                }
                else if (hand2.ToUpper() == "PAPER")
                {
                    Console.WriteLine(hand1 + ' ' + hand2);
                    Console.WriteLine("Player wins!");
                }
            }

            return hand1 + ' ' + hand2;
        }
    }
}

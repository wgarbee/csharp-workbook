using System;
using System.Threading;

namespace RockPaperScissors
{
    class Program
    {
        public static int PlayerScore = 0;
        public static int ComputerScore = 0;
        public static void Main()
        {
            getUserInput();
        }

        public static void getUserInput()
        {
            String hand1;
            Console.Clear();  // Clears the console prior to game start
            Console.WriteLine("Welcome to Rock | Paper | Scissors!");
            Thread.Sleep(1000);

            do  // Runs as long as the user does not enter quit
            {
                Console.WriteLine("When prompted, type either 'Rock', 'Paper', or 'Scissors' without single quotes.");
                Console.WriteLine("Type 'Quit' without single quotes to stop playing.");
                Console.WriteLine("Enter hand 1: ");
                hand1 = Console.ReadLine().ToUpper();
            
                // Random number generator for computer turn that is then assigned
                Random randNum = new Random();
                String hand2 = Convert.ToString(randNum.Next(1, 4));
                String winner = "";

                // Calls the method that checks who the winner is
                hand2 = ConvertComputerHand(hand2);
                try // attempts to 
                {
                    winner = CompareHands(hand1, hand2);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("Invalid input. Please type, 'Rock', 'Paper', or 'Scissors'.");
                    Console.WriteLine("User loses 1 point.");
                    Console.WriteLine("Player: {0}   Computer: {1}", PlayerScore, ComputerScore);
                }
                finally
                {
                    // Console.Clear();
                    DeclareWinner(hand1, hand2, winner);    
                }

                Thread.Sleep(500);
                
            }while (hand1.ToUpper() != "QUIT" && hand1.ToUpper() != "Q");

            Console.Clear();
        }

        public static string ConvertComputerHand(String hand2)
        {
            // Assigns the string value based on the number pased into for the hand2 variable
            if (hand2 == "1")
            {
                hand2 = "ROCK";
            }
            else if (hand2 == "2")
            {
                hand2 = "PAPER";
            }
            else
            {
                hand2 = "SCISSORS";
            }

            return hand2;
        }
        
        public static String CompareHands(String hand1, String hand2)
        {
            String winner = "";
            hand1 = hand1.ToUpper();

            // Compares the values of hand1 and hand2 to determine the winner
            if (hand1 == hand2)
            {
                winner = "0";
            } 
            else if (hand1 == "ROCK")
            {
                if (hand2 == "PAPER")
                {
                    winner = "2";
                    ComputerScore++;
                }
                else if (hand2 == "SCISSORS")
                {
                    winner = "1";
                    PlayerScore++;
                }
            }
            else if (hand1 == "PAPER")
            {
                if (hand2 == "ROCK")
                {
                    winner = "1";
                    PlayerScore++;
                }
                else if (hand2 == "SCISSORS")
                {
                    winner = "2";
                    ComputerScore++;
                }
            }
            else if (hand1 == "SCISSORS")
            {
                if (hand2 == "ROCK")
                {
                    winner = "2";
                    ComputerScore++;
                }
                else if (hand2 == "PAPER")
                {
                    winner = "1";
                    PlayerScore++;
                }
            }
            else if (hand1 == "QUIT")
            {
                return winner;
            }
            else
            {
                PlayerScore = PlayerScore - 1;
                throw new Exception("Invalid user input.");
            }

            return winner;
        }

        public static void DeclareWinner(String hand1, String hand2, String winner)
        {
            if (winner == "0")
            {
                Console.WriteLine(hand1 + " " + hand2);
                Console.WriteLine("It's a tie!");
                Console.WriteLine("Player: {0}   Computer: {1}", PlayerScore, ComputerScore);
            }
            else if (winner == "1")
            {
                Console.WriteLine(hand1 + " " + hand2);
                Console.WriteLine("Player wins!");
                Console.WriteLine("Player: {0}   Computer: {1}", PlayerScore, ComputerScore);
            }
            else if (winner == "2")
            {
                Console.WriteLine(hand1 + " " + hand2);
                Console.WriteLine("Computer wins!");
                Console.WriteLine("Player: {0}   Computer: {1}", PlayerScore, ComputerScore);
            }
        }
    }
}

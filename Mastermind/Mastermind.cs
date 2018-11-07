using System;
using System.Collections.Generic;

namespace Mastermind
{
    class Program
    {
       public static void Main(String[] args)
       {
            // Init the Game class and passes strings of characters into the string array
            Game game = new Game();
            game.runGame();
       }
    }

    class Game
    {
        List<Row> userGuesses;
        String[] answer;

        public Game()
        {
            answer = new String[] {"a", "b", "c", "d"};
            userGuesses = new List<Row>();
        }

        public void runGame()
        {
            bool won = false;
            int turns = 10;

            while (!won && turns > 0)
            {
                displayAllGuesses();

                Row newGuess = null;
                
                try
                {
                    newGuess = getUserGuess();
                }
                catch
                {
                    Console.WriteLine("Invalid entry.");
                }

                if (newGuess != null)
                {
                    userGuesses.Add(newGuess);

                    String newHint = getHint();
                    newGuess.hint = newHint;

                    won = checkForWin();
                    
                    turns--;
                }
            }
        }

        public void displayAllGuesses()
        {
            foreach (Row guess in userGuesses)
            {
                Console.WriteLine(guess.readableString());
            }
        }

        public Row getUserGuess()
        {
            Console.WriteLine("Please enter a string of 4 alpha chars");
            String guess = Console.ReadLine().ToLower().Trim();
            
            if (guess.Length != 4)
            {
                throw new Exception ("The entry should be a string of 4 alpha characters");
            }

            Row newRow = new Row(guess);
            return newRow;
        }

        public String getHint()
        {
            return "0-0";
        }

        public bool checkForWin()
        {
            if (getHint() == "4-0")
            {
                return true;
            }
            return false;
        }
    }

    class Row
    {
        public Ball[] balls { get; }
        
        public String hint { get; set; }

        public Row(String letters)
        {
            balls = new Ball[4];

            for (int i = 0; i < 4; i++)
            {
                balls[i] = new Ball(letters[i].ToString());
            }
        }

        public String readableString()
        {
            String formattedString = "";
            foreach (Ball ball in balls)
            {
                formattedString += ball.letter + " ";
            }
            return formattedString.Trim() + "  Your hint is: " + hint;
        }
    }

    class Ball
    {
        public String letter { get; }
        public Ball(String letter)
        {
            this.letter = letter;
        }
    }
}

using System;
using System.IO;
using System.Collections.Generic;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.StartGame();
        }
    }

    class Game
    {
        public Game()
        {

        }

        public void StartGame()
        {
            Board board = new Board();
            char userInput;

            board.CreateBoard();

            Console.Clear();
            Console.WriteLine(board.DrawBoard());

            do
            {
                Console.WriteLine("Good Guesses: " + board.goodGuesses);
                Console.WriteLine("Bad guesses: " + board.badGuesses);
                // Console.WriteLine("Word length: " + board.word.randomWord.Length);

                Console.WriteLine("Please enter a letter to make a guess:");
                userInput = Convert.ToChar(Console.ReadLine());

                if ((int)userInput == 1)
                {
                    Console.WriteLine(board.word.randomWord);
                }
                else
                {
                    board.CheckWord(userInput);
                    Console.Clear();
                }

                Console.WriteLine(board.DrawBoard());
            } while(!board.Win() && board.badGuesses != 6);

            if (board.Win())
            {
                Console.WriteLine("You win!");
            }
            else
            {
                Console.WriteLine("Womp womp");
            }
        }
    }

    class Board
    {
        // Tracks the number of users bad guesses
        public int badGuesses = 0;

        // Tracks the number of users good guesses
        public int goodGuesses = 0;

        public Word word = new Word();

        public Board()
        {

        }

        public void CreateBoard()
        {
            word.GetWords();
            word.GetRandomWord();
            word.BuildEmptyRandomWordArray();
        }

        // Draws the board to the console
        public String DrawBoard()
        {
            String formattedBoard = "";

            // Console.WriteLine(word.randomWord);

            if (badGuesses == 0)
            {
                formattedBoard += "Welcome to Hangman!\n\n\n\n\n";
                Console.WriteLine(word.ToString());
            }
            else if (badGuesses == 1)
            {
                formattedBoard  = "Welcome to Hangman!\n";
                formattedBoard += "        O          \n";
                formattedBoard += "\n\n\n";
                Console.WriteLine(word.ToString());
            }
            else if (badGuesses == 2)
            {
                formattedBoard  = "Welcome to Hangman!\n";
                formattedBoard += "        O          \n";
                formattedBoard += "        |          \n";
                formattedBoard += "        |          \n";
                formattedBoard += "\n";
                Console.WriteLine(word.ToString());
            }
            else if (badGuesses == 3)
            {
                formattedBoard  = "Welcome to Hangman!\n";
                formattedBoard += "        O          \n";
                formattedBoard += "        |          \n";
                formattedBoard += "        |          \n";
                formattedBoard += "       /           \n";
                Console.WriteLine(word.ToString());
            }
            else if (badGuesses == 4)
            {
                formattedBoard  = "Welcome to Hangman!\n";
                formattedBoard += "        O          \n";
                formattedBoard += "        |          \n";
                formattedBoard += "        |          \n";
                formattedBoard +=@"       / \         " + "\n";
                Console.WriteLine(word.ToString());
            }
            else if (badGuesses == 5)
            {
                formattedBoard  =  "Welcome to Hangman!\n";
                formattedBoard +=  "        O          \n";
                formattedBoard +=  "       /|          \n";
                formattedBoard +=  "        |          \n";
                formattedBoard += @"       / \         " + "\n";
                Console.WriteLine(word.ToString());
            }
            else if (badGuesses == 6)
            {
                formattedBoard  =  "Welcome to Hangman!\n";
                formattedBoard +=  "        O          \n";
                formattedBoard += @"       /|\         " + "\n";
                formattedBoard +=  "        |          \n";
                formattedBoard += @"       / \         " + "\n";
                Console.WriteLine(word.ToString());
            }

            return formattedBoard;
        }

        public void CheckWord(char userInput)
        {
            int i = 0;
            int numberOfMatches = 0;

            foreach (char letter in word.randomWord)
            {
                if (letter == userInput)
                {
                    word.randomWordArray[i] = userInput.ToString();
                    goodGuesses++;
                    numberOfMatches++;
                }
                i++;
            }

            if (numberOfMatches == 0)
            {
                badGuesses++;
            }
        }

        public bool Win()
        {
            if (badGuesses < 6 && goodGuesses == word.randomWord.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class Word
    {
        private String[] words { get; set; }

        public String[] randomWordArray;

        public String randomWord { get; private set; }

        private Random randomNumber = new Random();

        public Word()
        {

        }

        public void GetWords()
        {
            String file = @"words_alpha.txt";
            words = File.ReadAllLines(file);
        }

        public void GetRandomWord()
        {
            int randomWordLocation = randomNumber.Next(0, words.Length);

            randomWord = words[randomWordLocation];
        }

        public void BuildEmptyRandomWordArray()
        {
            randomWordArray = new String[randomWord.Length];

            for (int i = 0; i < randomWord.Length; i++)
            {
                randomWordArray[i] = "_";
            }
        }

        public override String ToString()
        {
            String formattedString = "";
            foreach (String letter in randomWordArray)
            {
                formattedString += letter + " ";
            }

            return formattedString.Trim();
        }
    }
}

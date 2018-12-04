using System;
using System.IO;

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
            
        }
    }

    class Board
    {
        String[] words;

        Random randomWordLocation = new Random();

        public Board()
        {

        }

        public void CreateBoard()
        {
            String formatted
        }

        public String[] GetWords()
        {
            String file = @"words_alpha.txt";
            words = File.ReadAllLines(file);

            return words;
        }
    }
}

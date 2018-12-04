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
        String[] words;

        public Game()
        {

        }

        public void StartGame()
        {
            String file = @"words_alpha.txt";
            words = File.ReadAllLines(file);

            int numberOfWords = words.Length;

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(words[i]);
            }
        }
    }

    class Word
    {

    }
}

using System;
using System.Collections.Generic;

namespace TowersOfHanoi
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
        Dictionary<Tower, Block> gameboard;

        

        public Game()
        {
            return;
        }

        public void StartGame()
        {
            bool won = false;

            while (!won)
            {
                DrawGameBoard();
                won = true;
            }
        }

        public void DrawGameBoard()
        {
            // Console.WriteLine("A: ");
            // Console.WriteLine("B: ");
            // Console.WriteLine("C: ");
            // foreach (Tower tower in gameboard.Keys)
            // {
            //     Console.WriteLine(tower + ": ");
            // }
        }
    }

    class Tower
    {
        Stack<Block> blocks;
        public Tower()
        {
            
        }
    }

    class Block
    {
        public Block()
        {

        }
    }
}
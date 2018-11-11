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

        }

        public void DrawGameBoard()
        {
            foreach (Tower tower in gameboard)
            {
                
            }
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
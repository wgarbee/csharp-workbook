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
        Dictionary<String, Tower> gameboard;

        public Game()
        {
            gameboard = new Dictionary<String, Tower>();
            return;
        }

        public void StartGame()
        {
            bool won = false;
            CreateGameBoard();

            while (!won)
            {
                DrawGameBoard();
                won = true;
            }
        }

        public String DrawGameBoard()
        {
            String formattedString = "";
            foreach (String tower in gameboard.Keys)
            {
                formattedString += tower + ": ";

                foreach (Tower row in gameboard.Values)
                {
                    formattedString += row + "\n";
                }
            }
            return formattedString;
        }

        public void CreateGameBoard()
        {
            gameboard = new Dictionary<String, Tower>();

            Tower towerA = new Tower();
        }
    }

    class Tower
    {
        Stack<Block> blocks;
        public Tower()
        {
            blocks = new Stack<Block>();
        }
    }

    class Block
    {
        public String block;
        public Block(String block)
        {
            this.block = block;
        }
    }
}
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

            gameboard.Add("A", new Tower(4));
            gameboard.Add("B", new Tower());
            gameboard.Add("C", new Tower());
        }

        public void StartGame()
        {
            // bool won = false;

            Console.WriteLine(DrawGameBoard());

            // while (!won)
            // {

            // }
        }

        // public String DrawGameBoard()
        // {
        //     Console.WriteLine("Is it working?");
        //     String formattedString = "";
        //     foreach (String tower in gameboard.Keys)
        //     {
        //         formattedString += tower + ": ";

        //         foreach (Tower column in gameboard.Values)
        //         {
        //             formattedString += column + "\n";
        //         }
        //     }
        //     return formattedString;
        // }

        public String DrawGameBoard()
        {
            String formattedString = "";

            foreach (String key in gameboard.Keys)
            {
                formattedString += key + ": " + gameboard[key].ToString() + "\n";
            }
            return formattedString;
        }
    }

    class Tower
    {
        Stack<Block> blocks;
        public Tower(int numberOfBlocks)
        {
            blocks = new Stack<Block>();
            for (int i = numberOfBlocks; i > 4; i--)
            {
                blocks.Push(new Block(i));
            }
        }

        public Tower()
        {
            blocks = new Stack<Block>();
        }

        public override String ToString()
        {
            String formattedString = "";
            foreach (Block block in blocks)
            {
                formattedString += block.block;
            }

            return formattedString;
        }
    }

    class Block
    {
        public int block;
        public Block(int block)
        {
            this.block = block;
        }

        public Block()
        {

        }
    }
}
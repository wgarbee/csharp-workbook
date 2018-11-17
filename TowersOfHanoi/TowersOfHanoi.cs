using System;
using System.Collections.Generic;
using System.Threading;

namespace TowersOfHanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiates a new game
            Game game = new Game();
            game.StartGame();
        }
    }

    class Game
    {
        // Declares a new dictionary that contains a String name for a tower in the key
        // and a Tower object that contains a Stack of Block objects
        Dictionary<String, Tower> gameboard;

        // A string that changes from "from" to "to" as the player moves blocks from one tower
        // to another tower.
        String towerMove = "from";

        int numberOfBlocks = 0;

        public Game()
        {
            // Instantiates gameboard
            gameboard = new Dictionary<String, Tower>();

            Console.Clear();
            numberOfBlocks = CreateGameBoard();

            // Commented out 
            // Populates the gameboard dictionary. Tower A having a Tower object with 4 Block objects
            // and tower B and C being populated with empty Tower objects
            // gameboard.Add("A", new Tower(4));
            // gameboard.Add("B", new Tower());
            // gameboard.Add("C", new Tower());
        }

        public void StartGame()
        {
            bool won = false;
            // int block = 0;  Was passed an int from PickBlock method (legacy) no longer used to show thought process

            Console.Clear();
            DrawGameBoard();

            while(!won)
            {
                String towerOrigin = "";
                String towerDestination = "";

                try
                {
                    towerOrigin = GetUserInput();
                    // block = PickBlock(towerOrigin);  Feel this is less effective and creates more code to manage
                    towerDestination = GetUserInput();
                    MoveBlock(/* block,  */towerOrigin, towerDestination);
                    Console.Clear();
                    DrawGameBoard();
                    won = CheckForWin();
                }
                catch
                {
                    Console.WriteLine("Invalid move.");
                }
            }

            Console.WriteLine("You win!");
        }

        // Builds the gameboard. Asks the user how may blocks they would like to play with and builds the block
        // objects in the first tower based on user input. There are a minimum of 4 blocks created.
        public int CreateGameBoard()
        {
            Console.WriteLine("Please enter the number of blocks you want to play with if more than 4: ");
            int numberOfBlocks = Convert.ToInt32(Console.ReadLine());

            // Creates block objects based on user input
            if (numberOfBlocks > 4)
            {
                gameboard.Add("A", new Tower(numberOfBlocks));
                gameboard.Add("B", new Tower());
                gameboard.Add("C", new Tower());

                Console.WriteLine($"You will play with {numberOfBlocks} blocks.");
                Thread.Sleep(2000);

                return numberOfBlocks;
            }
            // Builds the minimum number of block objects for the game
            else
            {
                Console.WriteLine("Game will with be built with the minimum 4 blocks.");
                gameboard.Add("A", new Tower(4));
                gameboard.Add("B", new Tower());
                gameboard.Add("C", new Tower());

                Thread.Sleep(1500);

                return 4;
            }
        }

        // Draws the game board
        public void DrawGameBoard()
        {
            String formattedString = "";

            foreach (String key in gameboard.Keys)
            {
                formattedString += key + ": " + gameboard[key] + "\n";
            }
            Console.WriteLine(formattedString);
        }

        // Asks the user to select a tower to or from
        public String GetUserInput()
        {
            String towerSelect;
            do
            {
                Console.WriteLine($"Please enter the tower letter (A / B / C) you would like to move {towerMove}: ");
                towerSelect = Console.ReadLine().ToUpper();

                if ((towerSelect == "A" || towerSelect == "B" || towerSelect == "C") && gameboard[towerSelect].blocks.Count != 0)
                {
                    // Changes the towerMove to "to" so it displays when this is called a second time in the StartGame while loop
                    towerMove = "to"; 
                }
                else if ((towerSelect == "A" || towerSelect == "B" || towerSelect == "C") && (gameboard[towerSelect].blocks.Count == 0 && towerMove == "to"))
                {
                    towerMove = "to";
                }
                else
                {
                    throw new Exception("Invalid input");
                }

            } while (towerSelect != "A" && towerSelect != "B" & towerSelect != "C");

            return towerSelect;

            // Threw this into the above do-while loop. Felt it handled user input errors better. Still exploring.
            /* Console.WriteLine("Please enter the tower letter (A / B / C) you would like to move {0}: ", towerMove);
            String towerSelect = Console.ReadLine().ToUpper();

            if (towerSelect == "A" || towerSelect == "B" || towerSelect == "C")
            {
                towerMove = "to";
                return towerSelect;
            }
            else
            {
                throw new Exception("Invalid entry");
            } */
        }

        // Commented out. I don't feel this is the most efficient way to do this. See MoveBlock method for my solution.
        // public int PickBlock(String towerOrigin)
        // {
        //     return gameboard[towerOrigin].blocks.Pop().block;
        // }

        // Takes in a block object
        public void MoveBlock(/* int block,  */String towerOrigin, String towerDestination)
        {
            int originBlock = gameboard[towerOrigin].blocks.Peek().block;

            if (gameboard[towerDestination].blocks.Count == 0)
            {
                Block block = gameboard[towerOrigin].blocks.Pop();
                gameboard[towerDestination].blocks.Push(block);
                towerMove = "from";
            }
            else if (gameboard[towerDestination].blocks.Count != 0)
            {
                int destinationBlock = gameboard[towerDestination].blocks.Peek().block;

                if (originBlock < destinationBlock)
                {
                    Block block = gameboard[towerOrigin].blocks.Pop();
                    gameboard[towerDestination].blocks.Push(block);
                    towerMove = "from"; // Changes the towerMove back to "from"
                }
                else
                {
                    Console.WriteLine("Cannot place on a smaller block");
                }
            }
        }

        // Check that tower C is 4 or mor blocks tall
        public bool CheckForWin()
        {
            if (gameboard["C"].blocks.Count == numberOfBlocks)
            {
                return true;
            }
            return false;
        }
    }

    class Tower
    {
        public Stack<Block> blocks { get; private set; }

        // Constructor when 
        public Tower(int numberOfBlocks)
        {
            blocks = new Stack<Block>();
            for (int i = numberOfBlocks; i > 0; i--)
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
                formattedString = block.block + " " + formattedString;
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

        public override String ToString()
        {
            return block.ToString();
        }
    }
}
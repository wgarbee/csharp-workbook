using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkers
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.StartGame();
        }
    }

    public class Checker
    {
        public String Symbol
        {
            get
            {
                if (Color == "black")
                {
                    int openCircleID = int.Parse("25CB", System.Globalization.NumberStyles.HexNumber);
                    String openCircle = char.ConvertFromUtf32(openCircleID);

                    return openCircle;
                }
                else if (Color == "white")
                {
                    int closedCircleID = int.Parse("25CF", System.Globalization.NumberStyles.HexNumber);
                    String closedCircle = char.ConvertFromUtf32(closedCircleID);

                    return closedCircle;
                }
                else
                {
                    return "";
                }
            }
        }

        // Not used as the Checkers are dumb
        // public int[] Position { get; set; }

        public String Color { get; set; }
        
        public Checker()
        {
            
        }

        public Checker(String color)
        {
            this.Color = color;
        }

        public override String ToString()
        {
            return Symbol;
        }
    }

    public class Board
    {
        public Checker[][] Grid { get; set; }

        public List<Checker> Checkers { get; set; }
        
        public Board()
        {
            
        }
        
        // Creates the board and the Checkers, laying the Checkers in their starting locations
        public void CreateBoard()
        {
            Checker checker;
            Checkers = new List<Checker>();
            Grid = new Checker[8][]
            {
                new Checker[8],
                new Checker[8],
                new Checker[8],
                new Checker[8],
                new Checker[8],
                new Checker[8],
                new Checker[8],
                new Checker[8]
            };

            // Generates the white checkers and places them in the Grid
            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 8; column++)
                {
                    if ((row == 0 || row == 2) && (column % 2 != 0))
                    {
                        checker = new Checker("white");
                        Checkers.Add(checker);
                        Grid[row][column] = checker;
                    }
                    else if ((row == 1) && (column % 2 == 0))
                    {
                        checker = new Checker("white");
                        Checkers.Add(checker);
                        Grid[row][column] = checker;
                    }
                }
            }

            // Generates the black checkers and places them in the Grid
            for (int row = 5; row < 8; row++)
            {
                for (int column = 0; column < 8; column++)
                {
                    if ((row == 5 || row == 7) && (column % 2 == 0))
                    {
                        checker = new Checker("black");
                        Checkers.Add(checker);
                        Grid[row][column] = checker;
                    }
                    else if ((row == 6) && (column % 2 != 0))
                    {
                        checker = new Checker("black");
                        Checkers.Add(checker);
                        Grid[row][column] = checker;
                    }
                }
            }
        }
        
        /* public void GenerateCheckers()
        {
            Checkers = new List<Checker>();

            for (int i = 0; i < 12; i++)
            {
                Checker checker = new Checker("white");
                Checkers.Add(checker);
            }
            
            for (int i = 0; i < 12; i++)
            {
                Checker checker = new Checker("black");
                Checkers.Add(checker);
            }
        } */
        
        /* public void PlaceCheckers()
        {
            
        } */
        
        public void DrawBoard()
        {
            String formattedBoard = "  0 1 2 3 4 5 6 7" + "\n";

            for (int row = 0; row < 8; row++)
            {
                formattedBoard += Convert.ToString(row) + " ";

                for (int column = 0; column < 8; column++)
                {
                    if (Grid[row][column] != null)
                    {
                        if (Grid[row][column].Symbol != "")
                        {
                            formattedBoard += Grid[row][column] + " ";
                        }
                        else
                        {
                            formattedBoard += "  ";
                        }
                    }
                    else
                    {
                        formattedBoard += "  ";
                    }

                    if (column % 7 == 0 && column != 0)
                    {
                        formattedBoard += "\n";
                    }
                }
            }
            Console.WriteLine(formattedBoard);
        }
        
        public Checker SelectChecker()
        {
            Console.WriteLine("Please enter the row to move from: ");
            int row = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the column to move from: ");
            int column = Convert.ToInt32(Console.ReadLine());

            Checker returnedChecker = Grid[row][column];
            Checkers.Remove(Grid[row][column]);  // Removes this specific Checker from the list of Checkers
            Grid[row][column] = null;
            
            return returnedChecker;
            // return Checkers.Find(x => x.Position.SequenceEqual(new List<int> { row, column }));
        }
        
        public void PlaceChecker(Checker checker)
        {
            Console.WriteLine("Please enter the row to move to: ");
            int row = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the column to move to: ");
            int column = Convert.ToInt32(Console.ReadLine());

            Grid[row][column] = checker;
        }
        
        public bool CheckForWin()
        {
            return Checkers.All(x => x.Color == "white") || !Checkers.Exists(x => x.Color == "white");
        }
    }

    class Game
    {
        public Game()
        {
            
        }

        public void StartGame()
        {
            Board boardgame = new Board();

            boardgame.CreateBoard();
            boardgame.DrawBoard();

            do
            {
                Checker checker = boardgame.SelectChecker();
                // Console.Clear();
                boardgame.DrawBoard();
                boardgame.PlaceChecker(checker);
                boardgame.DrawBoard();
            }while(!boardgame.CheckForWin());
        }
    }
}

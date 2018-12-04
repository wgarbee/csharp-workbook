using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkers
{
    class Program
    {

        static void Main(String[] args)
        {
            Game game = new Game();
            game.StartGame();
        }
    }

    // Checker class
    public class Checker
    {
        // Gets the Open or Closed circle value based on the checker's color
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

        public String Color { get; set; }

        // Checker constructor
        public Checker(String color)
        {
            this.Color = color;
        }

        // ToString override
        public override String ToString()
        {
            return Symbol;
        }
    }

    public class Board
    {
        // Array of Checkers that holds the Checker object
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
        
        // Draws the gameboard
        public String DrawBoard()
        {
            // Header
            String formattedBoard = "  0 1 2 3 4 5 6 7" + "\n";

            // Loops through drawinng the gameboard from the Grid array of Checkers
            for (int row = 0; row < 8; row++)
            {
                formattedBoard += Convert.ToString(row) + " ";

                for (int column = 0; column < 8; column++)
                {
                    // Error catching. Runs as long as the location has a Checker object
                    if (Grid[row][column] != null)
                    {
                        // Places a Checker in the space on the grid
                        if (Grid[row][column].Symbol != "")
                        {
                            formattedBoard += Grid[row][column] + " ";
                        }
                    }
                    else
                    {
                        // If the grid space is empty, inserts an empty space in the grid.
                        formattedBoard += "  ";
                    }

                    // Adds a new line if the loop is iterating on the the 7th column
                    if (column == 7)
                    {
                        formattedBoard += "\n";
                    }
                }
            }

            return formattedBoard;
        }
        
        public Checker SelectChecker(int row, int column, String color)
        {
            // Returns the Checker object to the Game class
            if (Grid[row][column].Color == color)
            {
                return Grid[row][column];
            }
            else
            {
                // Throws is the player is not selecting a space in the array that is out of turn
                String invalidPiece = Grid[row][column].Color;
                throw new Exception($"It is not {invalidPiece}'s turn");
            }
        }
        
        // Places the checker based on validation
        public void PlaceChecker(int originRow, int originColumn, int destinationRow, int destinationColumn, Checker checker)
        {
            // Makes sure the destination is empty
            if (Grid[destinationRow][destinationColumn] == null)
            {
                // If the turn is white
                if (checker.Color == "white")
                {
                    // If the user only moved one row, make sure that it isn't more than on column from origin
                    if ((destinationRow == originRow + 1) && (destinationColumn == originColumn - 1 || destinationColumn == originColumn + 1))
                    {
                        Grid[destinationRow][destinationColumn] = checker;
                    }
                    // Checks to make sure the user isn't trying to jump a white checker
                    else if ((destinationRow == originRow + 2) && (destinationColumn == originColumn - 2 || destinationColumn == originColumn + 2))
                    {
                        // If moving right, checks that the jumped checker isn't white
                        if ((destinationColumn > originColumn) && (Grid[destinationRow - 1][destinationColumn - 1].Color != "white"))
                        {
                            Grid[destinationRow][destinationColumn] = checker;
                        }
                        // If moving left, checks that the jumped checker isn't white
                        else if ((destinationColumn < originColumn) && (Grid[destinationRow - 1][destinationColumn + 1].Color != "white"))
                        {
                            Grid[destinationRow][destinationColumn] = checker;
                        }
                        else
                        {
                            throw new Exception("invalid move");  // If the user is trying to jump a white Checker
                        }
                    }
                    else
                    {
                        // User is trying to move more than two columns forward or move backwards
                        // or more than two columns left or right on the board.
                        throw new Exception("Cannot move here");
                    }
                }

                // If the turn is black
                if (checker.Color == "black")
                {
                    // If the user only moved one row, make sure that it isn't more than on column from origin
                    if ((destinationRow == originRow - 1) && (destinationColumn == originColumn - 1 || destinationColumn == originColumn + 1))
                    {
                        Grid[destinationRow][destinationColumn] = checker;
                    }
                    // Checks to make sure the user isn't trying to jump a black checker
                    else if ((destinationRow == originRow - 2) && (destinationColumn == originColumn - 2 || destinationColumn == originColumn + 2))
                    {
                        if ((destinationColumn > originColumn) && (Grid[destinationRow + 1][destinationColumn - 1].Color != "black"))
                        {
                            Grid[destinationRow][destinationColumn] = checker;
                        }
                        else if ((destinationColumn < originColumn) && (Grid[destinationRow + 1][destinationColumn + 1].Color != "black"))
                        {
                            Grid[destinationRow][destinationColumn] = checker;
                        }
                        else
                        {
                            throw new Exception("invalid move");  // If the user is trying to jump a white Checker
                        }
                    }
                    else
                    {
                        // User is trying to move more than two columns forward or move backwards
                        // or more than two columns left or right on the board.
                        throw new Exception("Cannot move here");
                    }
                }
            }
            else
            {
                // If there is a Checker in the users destination selection
                throw new Exception("There is a checker there.");
            }
        }

        // Removes the played checker from the board. If the player jumped a checker, remove the jumped checker.
        public bool RemoveChecker(int originRow, int originColumn, int destinationRow, int destinationColumn, Checker checker)
        {
            if (checker.Color == "white")
            {
                // If the player jumped a Checker
                if (destinationRow == originRow + 2)
                {
                    if (destinationColumn == originColumn + 2)
                    {
                        Checkers.Remove(Grid[destinationRow - 1][destinationColumn - 1]);  // Removes the jumped Checker from Checkers list
                        Grid[originRow][originColumn] = null;  // Removes the Checker the player moved from it's origin
                        Grid[destinationRow - 1][destinationColumn - 1] = null;  // Removes the jumped Checker
                        return true;  // Returns true becuase a Checker was jumped
                    }
                    else if (destinationColumn == originColumn - 2)
                    {
                        Checkers.Remove(Grid[destinationRow - 1][destinationColumn + 1]);  // Removes the jumped Checker from Checkers list
                        Grid[originRow][originColumn] = null;  // Removes the Checker the player moved from it's origin
                        Grid[destinationRow - 1][destinationColumn + 1] = null;  // Removes the jumped Checker
                        return true;  // Returns true becuase a Checker was jumped
                    }
                }
            }

            if (checker.Color == "black")
            {
                // If the player jumped a checker
                if (destinationRow == originRow - 2)
                {
                    if (destinationColumn == originColumn + 2)  // If the player moves left
                    {
                        Checkers.Remove(Grid[destinationRow + 1][destinationColumn - 1]);  // Removes the jumped Checker from Checkers list
                        Grid[originRow][originColumn] = null;  // Removes the Checker the player moved from it's origin
                        Grid[destinationRow + 1][destinationColumn - 1] = null;  // Removes the jumped Checker
                        return true;  // Returns true becuase a Checker was jumped
                    }
                    else if (destinationColumn == originColumn - 2)  // If the player moves right
                    {
                        Checkers.Remove(Grid[destinationRow + 1][destinationColumn + 1]);  // Removes the jumped Checker from Checkers list
                        Grid[originRow][originColumn] = null;  // Removes the Checker the player moved from it's origin
                        Grid[destinationRow + 1][destinationColumn + 1] = null;  // Removes the jumped Checker
                        return true;  // Returns true becuase a Checker was jumped
                    }
                }
            }

            // Removes the Checker the player moved from it's origin
            Grid[originRow][originColumn] = null;
            return false;
        }
        
        // Checks if all chckers in Checkers list are white or no white at all
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
            Board boardgame = new Board();  // New board instance
            String color = "white";  // Starting color
            bool removedChecker;

            boardgame.CreateBoard();

            do
            {
                Console.Clear();
                Console.WriteLine(boardgame.DrawBoard());

                try
                {
                    // Selects a checker
                    Console.WriteLine($"{color}, please enter a row to move from:");
                    int originRow = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine($"{color}, please enter a column to move from:");
                    int originColumn = Convert.ToInt32(Console.ReadLine());
                    Checker checker = boardgame.SelectChecker(originRow, originColumn, color);

                    Console.Clear();
                    Console.WriteLine(boardgame.DrawBoard());

                    // Places the checker based on user input
                    Console.WriteLine("Please enter the row to move to: ");
                    int destinationRow = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please enter the column to move to: ");
                    int destinationColumn = Convert.ToInt32(Console.ReadLine());
                    boardgame.PlaceChecker(originRow, originColumn, destinationRow, destinationColumn, checker);

                    Console.Clear();
                    Console.WriteLine(boardgame.DrawBoard());

                    // Removes jumped checkers and the checker from the old location.
                    removedChecker = boardgame.RemoveChecker(originRow, originColumn, destinationRow, destinationColumn, checker);

                    Console.Clear();
                    Console.WriteLine(boardgame.DrawBoard());

                    // Checks if a Checker was removed in the turn. If there was and player hasn't won
                    // asks the player if they can make a move by jumping another opponents Checker with
                    // the same Checker they just played with. Then changes the player turn if they say no.
                    if (removedChecker && !boardgame.CheckForWin())
                    {
                        String userInput = "";
                        do
                        {
                            Console.WriteLine("Do you have another move you can make with the same checker? [Y/N]");
                            userInput = Console.ReadLine().ToLower();
                        }while (userInput != "y" && userInput != "n");

                        if (userInput == "n")
                        {
                            if (color == "white")
                            {
                                color = "black";
                            }
                            else
                            {
                                color = "white";
                            }
                        }
                    }  // Changes the player turn
                    else if (!removedChecker)
                    {
                        if (color == "white")
                        {
                            color = "black";
                        }
                        else
                        {
                            color = "white";
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid selection.");
                }

            }while(!boardgame.CheckForWin());

            Console.WriteLine($"{color} wins!");
        }
    }
}

using System;

namespace TicTacToe
{
    class Program
    {
        public static string playerTurn = "X";
        public static string[][] board = new string[][]
        {
            new string[] {" ", " ", " "},
            new string[] {" ", " ", " "},
            new string[] {" ", " ", " "}
        };
        public static int totalTurns = 0;

        public static void Main()
        {
            do
            {
                Console.Clear();
                DrawBoard();
                GetInput();

            } while (!CheckForWin() && !CheckForTie());

            // leave this command at the end so your program does not close automatically
            Console.ReadLine();
            Console.Clear();
        }

        public static void GetInput()
        {
            Console.WriteLine("Player " + playerTurn);
            Console.WriteLine("Enter Row:");
            int row = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Column:");
            int column = Convert.ToInt32(Console.ReadLine());

            PlaceMark(row, column);
        }

        public static void PlaceMark(int row, int column)
        {
            if (board[row][column] == " ")
            {
                totalTurns++;
                if (playerTurn == "X")
                {
                    board[row][column] = playerTurn;
                    playerTurn = "O";
                }
                else
                {
                    board[row][column] = playerTurn;
                    playerTurn = "X";
                }
            }
            else
            {
                Console.WriteLine("Space taken. Please select another.");
                GetInput();
            }
        }

        public static bool CheckForWin()
        {
            // your code goes here
            if (HorizontalWin() || VerticalWin() || DiagonalWin())
            {
                if (playerTurn == "X")
                {
                    Console.Clear();
                    DrawBoard();
                    playerTurn = "O";
                    Console.WriteLine("{0} wins!", playerTurn);
                }
                else
                {
                    Console.Clear();
                    DrawBoard();
                    playerTurn = "X";
                    Console.WriteLine("{0} wins!", playerTurn);
                }
                return true;
            }
            return false;
        }

        public static bool CheckForTie()
        {
            // your code goes here
            if (!CheckForWin() && totalTurns == 9)
            {
                DrawBoard();
                Console.WriteLine("It's a tie!");
                return true;
            }
            return false;
        }
        
        public static bool HorizontalWin()
        {
            // your code goes here
            if (board[0][0] != " " && board[0][0] == board[0][1] && board[0][1] == board [0][2])
            {
                return true;
            }
            else if (board[1][0] != " " && board[1][0] == board[1][1] && board[1][1] == board [1][2])
            {
                return true;
            }
            else if (board[2][0] != " " && board[2][0] == board[2][1] && board[2][1] == board [2][2])
            {
                return true;
            }

            return false;
        }

        public static bool VerticalWin()
        {
            // your code goes here
            if (board[0][0] != " " && board[0][0] == board[1][0] && board[1][0] == board [2][0])
            {
                return true;
            }
            else if (board[0][1] != " " && board[0][1] == board[1][1] && board[1][1] == board [2][1])
            {
                return true;
            }
            else if (board[0][2] != " " && board[0][2] == board[1][2] && board[1][2] == board [2][2])
            {
                return true;
            }

            return false;
        }

        public static bool DiagonalWin()
        {
            // your code goes here
            if (board[0][0] != " " && board[0][0] == board[1][1] && board[1][1] == board [2][2])
            {
                return true;
            }
            else if (board[0][2] != " " && board[0][2] == board[1][1] && board[1][1] == board [2][0])
            {
                return true;
            }

            return false;
        }

        public static void DrawBoard()
        {
            Console.WriteLine("  0 1 2");
            Console.WriteLine("0 " + String.Join("|", board[0]));
            Console.WriteLine("  -----");
            Console.WriteLine("1 " + String.Join("|", board[1]));
            Console.WriteLine("  -----");
            Console.WriteLine("2 " + String.Join("|", board[2]));
        }
    }
}

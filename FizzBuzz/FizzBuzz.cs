using System;

namespace FizzBuzz
{
    class Program
    {
        public static int userInput;
        static void Main(string[] args)
        {
            int loop;
            do
            {
                Console.WriteLine("Please enter an integer: ");
                userInput = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("What loop do you want to use? Enter 1, 2, or 3. Type 0 to quit");
                Console.WriteLine("1. For Loop");
                Console.WriteLine("2. While Loop");
                Console.WriteLine("3. Do While Loop");
                Console.WriteLine("4. Run all three loops");
                loop = Convert.ToInt32(Console.ReadLine());

                WhichLoop(loop);
            } while(loop != 0); // As long as the user does not enter '0', continues to run
        }

        // Method to check which loop the user would like to run
        public static void WhichLoop(int loop)
        {
            if (loop == 1)
            {
                UseForLoop();
            }
            else if (loop == 2)
            {
                UseWhileLoop();
            }
            else if (loop == 3)
            {
                UseDoWhileLoop();
            }
            else if (loop == 4) // Runs if user would like to confirm output from all three loops
            {
                UseForLoop();
                UseWhileLoop();
                UseDoWhileLoop();
            }
        }

        // Runs a 'for loop' to find all numbers divisible by three, five, or both three and five
        // and changes to 'fizz' - three (3), 'buzz' - five (5), or three and five - 'fizz buzz'
        public static void UseForLoop()
        {
            String output = "";
            for (int i = 1; i <= userInput; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    output = output + "fizz buzz, ";
                }
                else if (i % 3 == 0)
                {
                    output = output + "fizz, ";
                }
                else if (i % 5 == 0)
                {
                    output = output + "buzz, ";
                }
                else
                {
                    output = output + Convert.ToString(i) + ", ";
                }
            }

            Console.WriteLine(output);

            return;
        }

        // Runs a 'while loop' to find all numbers divisible by three, five, or both three and five
        // and changes to 'fizz' - three (3), 'buzz' - five (5), or three and five - 'fizz buzz'
        public static void UseWhileLoop()
        {
            String output = "";
            int i = 1;

            while (i <= userInput)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    output = output + "fizz buzz, ";
                }
                else if (i % 3 == 0)
                {
                    output = output + "fizz, ";
                }
                else if (i % 5 == 0)
                {
                    output = output + "buzz, ";
                }
                else
                {
                    output = output + Convert.ToString(i) + ", ";
                }

                i++;
            }

            Console.WriteLine(output);

            return;
        }

        // Runs a 'do while loop' to find all numbers divisible by three, five, or both three and five
        // and changes to 'fizz' - three (3), 'buzz' - five (5), or three and five - 'fizz buzz'
        public static void UseDoWhileLoop()
        {
            String output = "";
            int i = 1;

            do
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    output = output + "fizz buzz, ";
                }
                else if (i % 3 == 0)
                {
                    output = output + "fizz, ";
                }
                else if (i % 5 == 0)
                {
                    output = output + "buzz, ";
                }
                else
                {
                    output = output + Convert.ToString(i) + ", ";
                }

                i++;
            } while (i <= userInput);

            Console.WriteLine(output);

            return;
        }
    }
}

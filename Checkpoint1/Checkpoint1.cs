using System;
using System.Collections.Generic;

namespace Checkpoint1
{
    class Program
    {
        static void Main(string[] args)
        {
            NumbersDivisibleByThree();
            AddUserNumbersTogether();
            FactorialMethod();
            RandomNumberGame();
            FindLargestNumber();
        }

        public static void NumbersDivisibleByThree()
        {
            int numDivThree = 0;

            for (int i = 1; i < 101; i++)
            {
                if (i %3 == 0)
                {
                    numDivThree++;
                }
            }

            Console.WriteLine("There are {0} numbers divisible by three (3) between one (1) and one hundred (100).", numDivThree);
            Console.WriteLine("Press return to run the next method.");
            Console.ReadLine();
            Console.Clear();

            return;
        }

        public static void AddUserNumbersTogether()
        {
            String userInput;
            int sum = 0;

            Console.WriteLine("Please enter an integer. Type 'ok' to end entry and return the sum.");
            userInput = Console.ReadLine();

            while (userInput.ToUpper() != "OK")
            {
                sum += Convert.ToInt32(userInput);
                
                Console.WriteLine("Please enter an integer");
                userInput = Console.ReadLine();
            }

            Console.WriteLine("The sum of the numbers you entered is {0}", sum);
            Console.WriteLine("Press return to run the next method.");
            Console.ReadLine();
            Console.Clear();

            return;
        }

        public static void FactorialMethod()
        {
            int userInput;
            int product = 1;

            Console.WriteLine("Please enter an integer. The method will return it's factorial");
            userInput = Convert.ToInt32(Console.ReadLine());

            for (int i = 2; i <= userInput; i++)
            {
                product *= i;
            }

            Console.WriteLine("The product of {0}! is {1}.",userInput, product);
            Console.WriteLine("Press return to run the next method.");
            Console.ReadLine();
            Console.Clear();
        }

        public static void RandomNumberGame()
        {
            int userInput;
            Random rand = new Random();
            int computerNum = rand.Next(1, 11);
            int attemptsLeft = 1;

            do
            {
                Console.WriteLine("Please enter an integer:");
                userInput = Convert.ToInt32(Console.ReadLine());

                if (userInput == computerNum)
                {
                    Console.WriteLine("Great! You win!");
                    break;
                }
                else
                {
                    Console.WriteLine("Please try again! You have {0} attempts left!", 4 - attemptsLeft);
                }

                attemptsLeft++;

            }while (attemptsLeft <= 4);

            Console.WriteLine("Press return to run the next method.");
            Console.ReadLine();
            Console.Clear();
        }

        public static void FindLargestNumber()
        {
            String userInput;

            Console.WriteLine("Enter a series of integers separated by a comma.");
            userInput = Console.ReadLine();

            String[] arrayOfNumbers = userInput.Split(",");
            
            int largestNumber = Convert.ToInt32(arrayOfNumbers[0]);

            for (int i = 0; i < arrayOfNumbers.Length; i++)
            {
                if (largestNumber < Convert.ToInt32(arrayOfNumbers[i]))
                {
                    largestNumber = Convert.ToInt32(arrayOfNumbers[i]);
                }
            }

            Console.WriteLine("The largest number you entered is {0}.", largestNumber);

            Console.WriteLine("Press return to run the next method.");
            Console.ReadLine();
            Console.Clear();
        }
    }
}

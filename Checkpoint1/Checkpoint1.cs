using System;
using System.Collections.Generic;

namespace Checkpoint1
{
    class Program
    {
        static void Main(string[] args)
        {
            // NumbersDivisibleByThree();
            AddUserNumbersTogether();
            // FactorialMethod();
            // RandomNumberGame();
            // FindLargestNumber();
        }

        public static void NumbersDivisibleByThree()
        {
            Console.Clear();

            int numDivThree = 0;
            int maxNumber = 100;

            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1: Display total number of numbers 1-100 divisible by three");
            Console.WriteLine("2: Display total number of numbers 1 to number provided by user");
            int userInput = Convert.ToInt32(Console.ReadLine());

            if (userInput == 1)
            {
                for (int i = 1; i < 101; i++)
                {
                    if (i %3 == 0)
                    {
                        numDivThree++;
                    }
                }
            }
            else
            {
                Console.WriteLine("Enter an integer.");
                userInput = Convert.ToInt32(Console.ReadLine());

                for (int i = 1; i < userInput + 1; i++)
                {
                    if (i %3 == 0)
                    {
                        numDivThree++;
                    }
                }

                maxNumber = userInput;
            }

            Console.WriteLine("There are {0} numbers divisible by 3 between 1 and {1}.", numDivThree, maxNumber);
            
            NextMethod();
        }

        /*public static void AddUserNumbersTogether()
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
            
            NextMethod();
        }*/

        public static void AddUserNumbersTogether()
        {
            List<int> userInputArray = new List<int>();
            String userInput;
            String sumString = "";
            int sum = 0;

            Console.WriteLine("Please enter an integer. Type 'ok' to end entry and return the sum.");
            userInput = Console.ReadLine();

            while (userInput.ToUpper() != "OK")
            {
                userInputArray.Add(Convert.ToInt32(userInput));
                sum += Convert.ToInt32(userInput);

                Console.WriteLine("Please enter an integer. Type 'ok' to end entry and return the sum.");
                userInput = Console.ReadLine();
            }

            // foreach (int num in userInputArray)
            // {
            //     sumString = sumString + (num + " + ");
            // }

            for (int i = 0; i < userInputArray.Count; i++)
            {
                if (i < userInputArray.Count)
                {
                    sumString = sumString + (userInputArray[i] + " + ");
                }
                else
                {
                    sumString = sumString + userInput[i];
                }
            }

            Console.WriteLine("{0} is {1}.", sumString, sum);
            
            NextMethod();
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
            
            NextMethod();
        }

        public static void RandomNumberGame()
        {
            int userInput;
            Random rand = new Random();
            int computerNum = rand.Next(1, 11);
            int attemptsLeft = 4;

            do
            {
                Console.WriteLine("Please enter an integer between 1 and 10 to guess.");
                userInput = Convert.ToInt32(Console.ReadLine());

                if (userInput == computerNum)
                {
                    Console.WriteLine("Great! You win!");
                    break;
                }
                else if (attemptsLeft > 1)
                {
                    Console.WriteLine("Please try again! You have {0} attempts left!", attemptsLeft - 1);
                }
                else
                {
                    Console.WriteLine("Sorry, better luck next time!");
                }

                attemptsLeft--;

            }while (attemptsLeft > 0);

            NextMethod();
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
        }

        public static void NextMethod()
        {
            Console.WriteLine("Press return to run the next method.");
            Console.ReadLine();
            Console.Clear();
        }
    }
}

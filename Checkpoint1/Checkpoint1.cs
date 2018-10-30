﻿using System;
using System.Collections.Generic;

namespace Checkpoint1
{
    class Program
    {
        public static bool returnToMenu = false;
        public static bool runAllMethods = false;
        public static bool rerunUserMethodSelection = false;

        static void Main(string[] args)
        {
            UserMethodSelection();
        }

        public static void UserMethodSelection()
        {
            do // Runs userMethodSelection as long as rerunUserMethodSelection returns true
            {
                int? userInput;

                Console.Clear();

                Console.WriteLine("Which method do you wish to run?");
                Console.WriteLine("1: Numbers Divisible By Three");
                Console.WriteLine("2: Add User Numbers Together");
                Console.WriteLine("3: Factorial Method");
                Console.WriteLine("4: Random Number Game");
                Console.WriteLine("5: Find Largest Number");
                Console.WriteLine("6: Run all 5");
                Console.WriteLine("7: Quit");
                userInput = Convert.ToInt32(Console.ReadLine());

                if (userInput == 6)
                {
                    runAllMethods = true;
                }

                if (userInput == 1 || userInput == 6 && !returnToMenu)
                {
                    NumbersDivisibleByThree();
                }
                
                if (userInput == 2 || userInput == 6 && !returnToMenu)
                {
                    AddUserNumbersTogether();
                }
                
                if (userInput == 3 || userInput == 6 && !returnToMenu)
                {
                    FactorialMethod();
                }
                
                if (userInput == 4 || userInput == 6 && !returnToMenu)
                {
                    RandomNumberGame();
                }
                
                if (userInput == 5 || userInput == 6 && !returnToMenu)
                {
                    FindLargestNumber();
                }
                
                if (userInput == 7/*  || userInput == null */)
                {
                    rerunUserMethodSelection = false;
                    Console.Clear();
                }
            }while (rerunUserMethodSelection);

            return;
        }

        // Checks for all numbers divisible by three if user selects option 1
        // If the user selects option 2, returns total possible numbers divisible by three 
        // between 1 and the number entered by the user.
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

        // This was the first iteration of AddUserNumbersTogether. It has been commented out but left to show thought process.
        // The operating version adds everything into a string for greater readability and practice.
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

        // Adds all integers entered by user together together. Includes lines of code to add these into a string
        // with logic that determines if it is the last integer entered by the user. If so, instead of a '+' added
        // to the string after the integer, it adds a '=' instead. It then adds the sum to the end of the srting and displays.
        public static void AddUserNumbersTogether()
        {
            Console.Clear();

            List<int> userInputArray = new List<int>();
            String userInput;
            String sumString = "";
            int sum = 0;

            Console.WriteLine("Please enter an integer. Type 'ok' to end entry and return the sum.");
            userInput = Console.ReadLine();

            if (userInput.ToUpper() != "OK")
            {
                while (userInput.ToUpper() != "OK")
                {
                    userInputArray.Add(Convert.ToInt32(userInput));
                    sum += Convert.ToInt32(userInput);

                    Console.WriteLine("Please enter an integer. Type 'ok' to end entry and return the sum.");
                    userInput = Console.ReadLine();
                }

                for (int i = 0; i < userInputArray.Count; i++)
                {
                    if (i < userInputArray.Count)
                    {
                        sumString = sumString + userInputArray[i];
                    }

                    if (i < userInputArray.Count - 1)
                    {
                        sumString += " + ";
                    }
                }

                Console.WriteLine("{0} = {1}.", sumString, sum);
            }
            else
            {
                Console.WriteLine("No integers were provided.");
            }

            NextMethod();
        }

        // Nothing fancy, returns the factorial of an integer entered by the user.
        public static void FactorialMethod()
        {
            Console.Clear();

            uint userInput;
            uint product = 1;

            Console.WriteLine("Please enter an integer. The method will return it's factorial");
            userInput = Convert.ToUInt32(Console.ReadLine());

            for (uint i = 2; i <= userInput; i++)
            {
                product *= i;
            }

            Console.WriteLine("The product of {0}! is {1}.",userInput, product);
            
            NextMethod();
        }

        // Asks the user to enter a number between 1 and 10, inclusive of 1 and 10. They have 4 chances.
        // The computer randomly generates a number between 1 and 10, inclusive of 1 and 10. If the user guesses correctly
        // within 4 attempts, they win. The user can cheat entering 0 as their guess to display the number generated
        // randomly by the computer.
        public static void RandomNumberGame()
        {
            Console.Clear();

            int userInput;
            Random rand = new Random();
            int computerNum = rand.Next(1, 11);
            int attemptsLeft = 4;

            do
            {
                Console.WriteLine("Please enter an integer between 1 and 10 to guess.");
                userInput = Convert.ToInt32(Console.ReadLine());

                if (userInput == 0)
                {
                    Console.WriteLine("Debug mode. Computer number is {0}.", computerNum);
                    attemptsLeft++;
                }

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
                    Console.WriteLine("The secret number was {0}.", computerNum);
                    Console.WriteLine("Sorry, better luck next time!");
                }

                attemptsLeft--;

            }while (attemptsLeft > 0);

            NextMethod();
        }

        // This method asks the user to enter integers seaprated by a comma and returns the largest integer.
        public static void FindLargestNumber()
        {
            Console.Clear();

            String userInput;

            Console.WriteLine("Enter a series of integers separated by a comma.");
            userInput = Console.ReadLine();

            String[] arrayOfNumbers = userInput.Split(",");
            
            float largestNumber = Convert.ToInt32(arrayOfNumbers[0]);

            for (int i = 1; i < arrayOfNumbers.Length; i++)
            {
                if (largestNumber < Convert.ToInt32(arrayOfNumbers[i]))
                {
                    largestNumber = Convert.ToInt32(arrayOfNumbers[i]);
                }
            }

            Console.WriteLine("{0} is the largest number you entered.", largestNumber);

            NextMethod();
        }

        // Depening on what the user selected in UserMethodSelection, this will run certain components.
        public static void NextMethod()
        {
            String userInput;

            // Prompts the user to press enter to return to UserMethodSelection
            if (!runAllMethods)
            {
                Console.WriteLine("Press enter to return to the main menu.");
                Console.ReadLine();
                UserMethodSelection();
            }
            else  // Runs if user selected '6' in UserMethodSelection
            {
                Console.WriteLine("Press return to run the next method. Type 'N' to return to the main menu.");
                userInput = Console.ReadLine();

                if (userInput.ToUpper() == "N")  // If the user enters 'N' returns them to UserMethodSelection
                {
                    rerunUserMethodSelection = true;
                    returnToMenu = true;
                }
            }

            return;
        }
    }
}

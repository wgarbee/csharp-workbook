using System;
using System.Threading;

namespace TextAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            int stick = 0;
            int complete;
            Random randNum = new Random();
            String playAgain;
            Boolean alive = true;

            while (alive)
            {
                Console.Clear();
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("Welcome to the cavern of secrets!");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

                Thread.Sleep(3000);

                Console.WriteLine("You enter a dark cavern out of curiosity. It is dark and you can only make out a small stick on the floor.");
                Console.WriteLine("Do you take it? [Y/N]");
                String ch1 = Console.ReadLine();
                Console.Clear();

                if (ch1.ToUpper() == "Y" || ch1.ToUpper() == "YES")
                {
                    Console.WriteLine("You take the stick!");
                    Thread.Sleep(2000);
                    stick = 1;
                }
                else
                {
                    Console.WriteLine("You did not take the stick.");
                    Thread.Sleep(2000);
                    stick = 0;
                }

                Console.WriteLine("As you proceed further into the cave, you see a small glowing object...");
                Console.WriteLine("Do you approach the object? [Y/N]");
                String ch2 = Console.ReadLine();
                Console.Clear();

                if (ch2.ToUpper() == "Y" || ch2.ToUpper() == "YES")
                {
                    Console.WriteLine("You approach the object...");
                    Thread.Sleep(2000);
                    Console.WriteLine("As you draw closer, you begin to make out the object as an eye!");
                    Thread.Sleep(1000);
                    Console.WriteLine("The eye belongs to a giant spider!");
                    Console.WriteLine("Do you try to fight it? [Y/N]");
                    String ch3 = Console.ReadLine();
                    Console.Clear();

                    if (ch3.ToUpper() == "Y" || ch3.ToUpper() == "YES")
                    {
                        if (stick == 1)
                        {
                            Console.WriteLine("You only have a stick to fight with.");
                            Console.WriteLine("You quickly jab the spider in it's eye and gain an advantage");
                            Thread.Sleep(2000);
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            Console.WriteLine("                  Fighting...                   ");
                            Console.WriteLine("   YOU MUST HIT ABOVE A 5 TO KILL THE SPIDER    ");
                            Console.WriteLine("IF THE SPIDER HITS HIGHER THAN YOU, YOU WILL DIE");
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            Thread.Sleep(2000);
                            int fdmg1 = randNum.Next(1, 10);
                            int edmg1 = randNum.Next(1, 5);
                            Console.WriteLine("You hit the spider for {0}", fdmg1);
                            Console.WriteLine("The spider hits you for {0}", edmg1);
                            Thread.Sleep(2000);

                            if (edmg1 > fdmg1)
                            {
                                Console.WriteLine("The spider has dealt more damage than you!");
                                complete = 0;
                            }
                            else if (fdmg1 < 5)
                            {
                                Console.WriteLine("You didn't do enough damage to kill the spider, but you manage to escape!");
                                complete = 1;
                            }
                            else
                            {
                                Console.WriteLine("You killed the spider!");
                                complete = 1;
                            }
                        }
                        else
                        {
                            Console.WriteLine("You don't have anything to fight with!");
                            Thread.Sleep(2000);
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            Console.WriteLine("                  Fighting...                   ");
                            Console.WriteLine("   YOU MUST HIT ABOVE A 5 TO KILL THE SPIDER    ");
                            Console.WriteLine("IF THE SPIDER HITS HIGHER THAN YOU, YOU WILL DIE");
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            Thread.Sleep(2000);
                            int fdmg1 = randNum.Next(1, 8);
                            int edmg1 = randNum.Next(1, 5);
                            Console.WriteLine("You hit the spider for {0}", fdmg1);
                            Console.WriteLine("The spider hits you for {0}", edmg1);
                            Thread.Sleep(2000);

                            if (edmg1 > fdmg1)
                            {
                                Console.WriteLine("The spider has dealt more damage than you!");
                                complete = 0;
                            }
                            else if (fdmg1 < 5)
                            {
                                Console.WriteLine("You didn't do enough damage to kill the spider, but you manage to escape!");
                                complete = 1;
                            }
                            else
                            {
                                Console.WriteLine("You killed the spider!");
                                complete = 1;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("You choose not to fight the spider.");
                        Thread.Sleep(1000);
                        Console.WriteLine("As you turn away, it ambushes you and impales you with it's fangs!");
                        complete = 0;
                    }
                }
                else
                {
                    Console.WriteLine("You turn away from the glowing object, and attempt to leave the cave...");
                    Thread.Sleep(1000);
                    Console.WriteLine("But something won't let you...");
                    Thread.Sleep(2000);
                    complete = 0;
                }

                // Allows for a rerun of the program
                // If complete is '1', then notes success in the game
                // If complete is '0', then failure
                // Either route gives player an option to play again
                if (complete == 1)
                {
                    // Runs if you lived
                    Console.WriteLine("You managed to escape the cavern alive! Would you like to play again? [Y/N]");
                    playAgain = Console.ReadLine();
                    
                    if(playAgain.ToUpper() == "Y" || playAgain.ToUpper() == "YES")
                    {
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Thanks for playing!");
                        alive = false;
                        Thread.Sleep(1500);
                        Console.Clear();
                    }
                }
                else
                {
                    // Runs if you are dead
                    Console.WriteLine("You have died! Would you like to play again? [Y/N]");
                    playAgain = Console.ReadLine();
                    
                    if(playAgain.ToUpper() == "Y" || playAgain.ToUpper() == "YES")
                    {
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Thanks for playing!");
                        alive = false;
                        Thread.Sleep(1500);
                        Console.Clear();
                    }
                }
            }
        }
    }
}

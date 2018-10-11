using System;

namespace week2_practice2
{
    class Program
    {
        static void Main(string[] args)
        {
            int num;

            Console.WriteLine("Enter your grade: [must be an integer]");
            num = Convert.ToInt32(Console.ReadLine());

            if (num >= 90)
            {
                Console.WriteLine("You made an A");
            }
            else if (num >= 80)
            {
                Console.WriteLine("You made an B");
            }
            else if (num >= 70)
            {
                Console.WriteLine("You made an C");
            }
            else
            {
                Console.WriteLine("You did not pass");
            }
        }
    }
}

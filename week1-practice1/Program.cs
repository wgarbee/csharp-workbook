using System;
using System.Threading;

namespace week1_practice1
{
    class Program
    {
        static void Main(string[] args)
        {
            int numA;
            int numB;
            int total;

            Console.WriteLine("Enter an integer value for 'a'");
            numA = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter an integer value for 'b'");
            numB = Convert.ToInt32(Console.ReadLine());
            total = numA + numB;
            Console.WriteLine("{0} plus {1} equals {2}", numA, numB, total);
            Console.ReadKey();
            Console.Clear();

            double yards = 0.0d;
            double inches = 0.0d;

            Console.WriteLine("To convert yards, please enter the number of yards");
            yards = Convert.ToDouble(Console.ReadLine());
            inches = yards * 12;
            Console.WriteLine("There are {0} inches in {1} yard(s)", inches, yards);
            Console.ReadKey();
            Console.Clear();
            
            decimal num = 0.0M;
            decimal prod = 0.0M;

            Console.WriteLine("Enter a number to be multiplied by iteself");
            num = Convert.ToDecimal(Console.ReadLine());
            prod = num * num;
            Console.WriteLine("The product of {0} multiplied by {0} is {1}", num, prod);
            Console.Clear();

            String firstName = "Wes";
            String lastName = "Garbee";
            int age = 34;
            String job = "Sales";
            String favoriteBand = "Alpha Rev";
            String favoriteSportsTeam = "Astros";

            Console.WriteLine("Hi! My name is {0} {1} and I am {2} years old.", firstName, lastName, age);
            Console.WriteLine("My job is {0}. My favorite band is {1}. My favorite sports team are the {2}.", job, favoriteBand, favoriteSportsTeam);
            Console.WriteLine("Press any key to end...");
            Console.ReadKey();
        }
    }
}

using System;

namespace week3_practice3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool allTestsPassed = tests();

            if (allTestsPassed)
            {
                Console.WriteLine("Your tests passed!");
            }
            else
            {
                Console.WriteLine("Your tests failed!");
            }

            int num1;
            int num2;
            int newNum = 0;

            Console.WriteLine("Enter an integer: ");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter another integer: ");
            num2 = Convert.ToInt32(Console.ReadLine());

            newNum = AddNumbers(num1, num2);

            Console.WriteLine("Your sum is " + newNum);

            
        }

        public static int AddNumbers(int num1, int num2)
        {
            return num1 + num2;
        }

        public static bool tests()
        {
            if (!test1())
            {
                return false;
            }
            if (!test2())
            {
                return false;
            }
            if (!test3())
            {
                return false;
            }
            if (!test4())
            {
                return false;
            }
            return true;
        }

        public static bool test1()
        {
            return 10 == AddNumbers(3, 7);
        }

        public static bool test2()
        {
            return 18 == AddNumbers(21, -3);
        }

        public static bool test3()
        {
            return -1 == AddNumbers(-5, 4);
        }

        public static bool test4()
        {
            return -24 == AddNumbers(-10, -14);
        }
    }
}

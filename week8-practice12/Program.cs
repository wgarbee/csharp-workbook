using System;

namespace week8_practice12
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[20];
            Random randomGenerator = new Random();
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = randomGenerator.Next(0, 100000);
            }

            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}

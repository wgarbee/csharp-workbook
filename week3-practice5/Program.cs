using System;

namespace week3_practice5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] x = {9, 13, 4, 12, 3};
            int comp1 = 0;
            int comp2 = 0;
            int num = 0;
            int i = 0;

            while (i < x.Length)
            {
                comp1 = x[i];
                comp2 = x[i+1];

                if (comp1 >= comp2)
                {
                    num = comp1;
                }

                i++;
            }

            Console.WriteLine("Largest number is {0}", num);

        }
    }
}

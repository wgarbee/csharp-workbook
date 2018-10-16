using System;
using System.Collections.Generic;

namespace week3_practice4
{
    class Program
    {
        // static void Main(string[] args)
        // {
        //     String[] names = new String[4];

        //     names[0] = "James";
        //     names[1] = "Mike";
        //     names[2] = "Adam";
        //     names[3] = "Jane";

        //     String[] pets = {"Rocky", "Walter", "Bailey"};

        //     String[] cities;
        //     cities = new String[] {"Austin", "Dallas", "Houston"};

        //     Console.WriteLine("Names: {0}, {1}, {2}, {3}.", names);
        //     Console.WriteLine("Pets: {0}, {1}, {2}.", pets);
        //     Console.WriteLine("Cities: {0}, {1}, {2}.", cities);

        //     String last = names[names.Length-1];

        //     Console.WriteLine("Last name in the names array is {0}.", last);
        // }

        static void Main(string[] args)
        {
            List<String> names = new List<String>();

            names.Add("John");
            names.Add("Mike");
            names.Add("Mark");

            Console.WriteLine("The list contains {0} elements.", names.Count);
            Console.WriteLine("The first element in the list is {0}.", names[0]);
        }
    }
}

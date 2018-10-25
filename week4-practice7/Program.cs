using System;
using System.Collections;
using System.Collections.Generic;

namespace week4_practice7
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<String> myStack = new Stack<String>();
            myStack.Push("Mike");
            myStack.Push("John");
            myStack.Push("Jane");
            myStack.Push("Mary");
            myStack.Push("Pat");

            while (myStack.Count >0)
            {
                String name = myStack.Pop();
                Console.WriteLine("Processing " + name);
            }

            Console.WriteLine(myStack.Count);

            Dictionary<String, int> grades = new Dictionary<string, int>();
            grades.Add("Mike", 75);
            grades.Add("John", 33);
            grades.Add("Jane", 45);
            grades.Add("Mary", 87);
            grades.Add("Pat", 100);

            Dictionary<int, String> items = new Dictionary<int, String>();
            grades.Add("Computer", 1234);
            grades.Add("Cereal", 5678);
            grades.Add("Beer", 3456);
            grades.Add("Milk", 7890);
            grades.Add("Pat", 100);
        }
    }
}

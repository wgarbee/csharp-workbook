using System;
using System.Collections.Generic;

namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentEntry();
        }

        public static void StudentEntry()
        {
            Dictionary<String, int> student = new Dictionary<string, int>();
            Stack<String> name = new Stack<String>();
            int grade;
            String userInput;

            Console.WriteLine("Please enter the students first name: ");
            name = Console.ReadLine();
            
            do
            {
                Console.WriteLine("Please enter the students grade. Type Q to quit.");
                grade = Convert.ToInt32(Console.ReadLine());
            }while (userInput != "Q");
        }
    }
}

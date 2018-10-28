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
            Dictionary<String, List<int>> gradebook = new Dictionary<String, List<int>>();
            String student = "";
            List<int> grades;
            String userInput = "";

            do
            {
                grades = new List<int>();
                Console.WriteLine("Please enter the student's name. Enter 'N' to stop.");
                student = Console.ReadLine();

                while (student.ToUpper() != "N" && userInput.ToUpper() != "N")
                {
                    int value;
                    Console.WriteLine("Enter the student's grades. Enter 'N' to stop:");
                    userInput = Console.ReadLine();
                    if (int.TryParse(userInput, out value))
                    {
                        grades.Add(Convert.ToInt32(userInput));
                    }
                }

                userInput = "";

                if (student.ToUpper() != "N")
                {
                    gradebook.Add(student, grades);
                }

            }while (student.ToUpper() != "N");
            
            Console.Clear();
            DisplayGradebook(gradebook);

        }

        public static void DisplayGradebook(Dictionary<String, List<int>> gradebook)
        {
            foreach (String key in gradebook.Keys)
            {
                Console.WriteLine(key);
                List<int> studentGrades = gradebook[key];
                
                try
                {
                CalculateAverage(studentGrades, key);
                CalculateMinimum(studentGrades, key);
                CalculateMaximum(studentGrades, key);
                }
                catch
                {
                    Console.WriteLine("No grades were entered for {0}.", key);
                }

                Console.WriteLine("Press enter to display the next student.");
                Console.ReadLine();
            }
        }

        public static void CalculateAverage(List<int> studentGrades, String key)
        {
            if (studentGrades.Count > 0)
            {
                int sum = 0;
                int totalGrades = 0;
                double average = 0.0D;
                foreach (int num in studentGrades)
                {
                    sum += num;
                    totalGrades++;
                }

                try
                {
                    average = Convert.ToDouble(sum) / totalGrades;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                finally
                {
                    Console.WriteLine("The average for {0} is {1}.", key, average);
                }
            }
            else
            {
                throw new Exception("No grades.");
            }
        }

        public static void CalculateMinimum(List<int> studentGrades, String key)
        {
            if (studentGrades.Count > 0)
            {
                int smallest = studentGrades[0];

                for (int i = 0; i < studentGrades.Count; i++)
                {
                    if (studentGrades[i] < smallest)
                    {
                        smallest = studentGrades[i];
                    }
                }

                Console.WriteLine("The lowest grade for {0} is {1}.", key, smallest);
            }
            else
            {
                throw new Exception("No grades.");
            }
        }

        public static void CalculateMaximum(List<int> studentGrades, String key)
        {
            int largest = studentGrades[0];

            for (int i = 0; i < studentGrades.Count; i++)
            {
                if (studentGrades[i] > largest)
                {
                    largest = studentGrades[i];
                }
            }

            Console.WriteLine("The lowest grade for {0} is {1}.", key, largest);
        }
    }
}

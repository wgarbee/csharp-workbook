using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentEntry();
        }

        // Takes in the users input for a student, their grades, and add them to the gradebook Dictionary.
        // This method includes a call to check user input for student name to validate. User must enter a name or
        // 'N' to proceed to either grade entry or exiting to either display the gradebook contents or proceed to exit the program
        public static void StudentEntry()
        {
            Dictionary<String, List<double>> gradebook = new Dictionary<String, List<double>>(); // Declares and inits the Dict for gradebook
            String student = "";
            List<double> grades;  // Declares but does not init the grades variable
            // double highestPossibleGrade;
            Console.Clear();

            do
            {
                String userInput = "";
                grades = new List<double>();  // Reinit the grades list var to clear the previously entered grades for prev student
                Console.WriteLine("Please enter the student's name. Enter 'N' to stop.");
                student = Console.ReadLine();

                if (!CheckStudentName(student))
                {
                    Console.WriteLine("Invalid entry. Student name must be in for form of an alpha string (sorry, Tech N9ne) and cannot be empty.");
                }

                while (student.ToUpper() != "N" && userInput.ToUpper() != "N" && CheckStudentName(student))
                {
                    double value;
                    Console.WriteLine("Enter the student's grades. Enter 'N' to stop:");
                    userInput = Console.ReadLine();
                    if (double.TryParse(userInput, out value))
                    {
                        grades.Add(value);
                    }
                    if (!double.TryParse(userInput, out value) && userInput.ToUpper() != "N")
                    {
                        Console.WriteLine("Invalid format. Number must be an integer.");
                    }
                }                
                
                if (student.ToUpper() != "N" && CheckStudentName(student))
                {
                    gradebook.Add(student, grades);
                }

            }while (student.ToUpper() != "N");

            Console.Clear();
            DisplayGradebook(gradebook);

        }

        public static bool CheckStudentName(String student)
        {
            Regex regexItem = new Regex("^[a-zA-Z ]*$");
            
            if (regexItem.IsMatch(student) && student.Length > 0)
            {
                return true;
            }
            return false;
        }

        public static void DisplayGradebook(Dictionary<String, List<double>> gradebook)
        {
            foreach (String key in gradebook.Keys)
            {
                Console.WriteLine(key);
                
                try
                {
                    Console.WriteLine(DisplayEnteredGrades(gradebook[key], key));
                    Console.WriteLine(CalculateAverage(gradebook[key], key));
                    Console.WriteLine(CalculateMinimum(gradebook[key], key));
                    Console.WriteLine(CalculateMaximum(gradebook[key], key));
                }
                catch
                {
                    Console.WriteLine("No grades were entered for {0}.", key);
                }

                Console.WriteLine("Press enter to display the next student.");
                Console.ReadLine();
            }
        }

        public static String DisplayEnteredGrades(List<double> studentGrades, String key)
        {
            if (studentGrades.Count > 0)
            {
                String gradeString = "";
                for (int i = 0; i < studentGrades.Count; i++)
                {
                    if (i + 1 == studentGrades.Count)
                    {
                        gradeString = gradeString + "and " + studentGrades[i].ToString();
                    }
                    else if (i < studentGrades.Count)
                    {
                        gradeString = gradeString + studentGrades[i].ToString() + ", ";
                    }
                }

                return $"Grades entered for {key}: {gradeString}";
            }
            else
            {
                throw new Exception("No grades.");
            }
        }

        public static String CalculateAverage(List<double> studentGrades, String key)
        {
            if (studentGrades.Count > 0)
            {
                double sum = 0.0;
                double totalGrades = 0.0D;
                double average = 0.0D;
                foreach (double num in studentGrades)
                {
                    sum += num;
                    totalGrades++;
                }

                average = sum / totalGrades;

                return $"The average grade for {key} is {average}.";
            }
            else
            {
                throw new Exception("No grades.");
            }
        }

        public static String CalculateMinimum(List<double> studentGrades, String key)
        {
            if (studentGrades.Count > 0)
            {
                double smallest = studentGrades[0];

                for (int i = 0; i < studentGrades.Count; i++)
                {
                    if (studentGrades[i] < smallest)
                    {
                        smallest = studentGrades[i];
                    }
                }

                return $"The lowest grade for {key} is {smallest}.";
            }
            else
            {
                throw new Exception("No grades.");
            }
        }

        public static String CalculateMaximum(List<double> studentGrades, String key)
        {
            if (studentGrades.Count > 0)
            {
                double largest = studentGrades[0];

                for (int i = 0; i < studentGrades.Count; i++)
                {
                    if (studentGrades[i] > largest)
                    {
                        largest = studentGrades[i];
                    }
                }

                return $"The largest grade for {key} is {largest}.";
            }
            else
            {
                throw new Exception("No grades.");
            }
        }
    }
}

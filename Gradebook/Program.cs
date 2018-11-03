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
            Console.Clear();

            do
            {
                String userInput = "";
                grades = new List<double>();  // Reinit the grades list var to clear the previously entered grades for prev student
                Console.WriteLine("Please enter the student's name. Enter 'N' to stop.");
                student = Console.ReadLine();

                // Passes the user input to CheckStudentName
                if (!CheckStudentName(student))
                {
                    Console.WriteLine("Invalid entry. Student name must be in for form of an alpha string (sorry, Tech N9ne) and cannot be empty.");
                }

                // Allows for continuous input of the students grades until user enters N
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
                
                // As long as the student entry isn't N and is valid, passes the entered grades to 
                if (student.ToUpper() != "N" && CheckStudentName(student))
                {
                    gradebook.Add(student, grades);
                }

            }while (student.ToUpper() != "N");  // If user enters N, ends loop and moves to displaying the gradebook

            Console.Clear();
            DisplayGradebook(gradebook);

        }

        // Makes sure the user enters an alpha string. Makes sure there are no numbers or special characters.
        public static bool CheckStudentName(String student)
        {
            Regex regexItem = new Regex("^[a-zA-Z]*$");
            
            if (regexItem.IsMatch(student) && student.Length > 0)
            {
                return true;
            }
            return false;
        }

        // Runs the DisplayGradebook method that calls the calculation methods
        public static void DisplayGradebook(Dictionary<String, List<double>> gradebook)
        {
            foreach (String key in gradebook.Keys)
            {
                Console.WriteLine(key);  // Displays the students name that is being run for the next method calls
                
                try
                {
                    Console.WriteLine($"The grades entered for {key}: {DisplayEnteredGrades(gradebook[key])}.");
                    Console.WriteLine($"The average grade for {key} is {CalculateAverage(gradebook[key])}.");
                    Console.WriteLine($"The lowest grade for {key} is {CalculateMinimum(gradebook[key])}.");
                    Console.WriteLine($"The highest grade for {key} is {CalculateMaximum(gradebook[key])}.");
                }
                catch
                {   // If the user did not enter any grades for the current student, catches exception and dumps out 
                    // to display the next student, if applicable.
                    Console.WriteLine("No grades were entered for {0}.", key);
                }

                Console.WriteLine("Press enter to display the next student.");
                Console.ReadLine();
            }
        }

        // Checks if grades were entered. If grades were entered, builds a string of those entered grades and passes them back.
        public static String DisplayEnteredGrades(List<double> studentGrades)
        {
            if (studentGrades.Count > 0)
            {
                String gradeString = "";
                for (int i = 0; i < studentGrades.Count; i++)
                {
                    if (i + 1 == studentGrades.Count)  // If we're at the end of the grades entered. #grammar
                    {
                        gradeString = gradeString + "and " + studentGrades[i].ToString();
                    }
                    else if (i < studentGrades.Count)  // If not at the end of the list of grades.
                    {
                        gradeString = gradeString + studentGrades[i].ToString() + ", ";
                    }
                }

                return gradeString;
            }
            else
            {   // If the user did not enter any grades for the student, returns an exception
                throw new Exception("No grades.");
            }
        }

        // Calculates the average of the grades for the current student
        public static double CalculateAverage(List<double> studentGrades)
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

            return average;
        }

        // Finds the lowest of entered grades for the current student
        public static double CalculateMinimum(List<double> studentGrades)
        {
            double smallest = studentGrades[0];

            for (int i = 0; i < studentGrades.Count; i++)
            {
                if (studentGrades[i] < smallest)
                {
                    smallest = studentGrades[i];
                }
            }

            return smallest;
        }

        // Finds the highest of entered grades for the current student
        public static double CalculateMaximum(List<double> studentGrades)
        {
            double largest = studentGrades[0];

            for (int i = 0; i < studentGrades.Count; i++)
            {
                if (studentGrades[i] > largest)
                {
                    largest = studentGrades[i];
                }
            }

            return largest;
        }
    }
}

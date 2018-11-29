using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creates a list of students
            List<Student> students = new List<Student>();

            // Adds 10 students to the list of students
            for (int i = 0; i < 10; i++)
            {
                students.Add(Student.RandomStudent());
            }

            // Lists all students in the list
            Console.WriteLine("List of all students: ");
            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }

            // Lists all the students in the list with balance over $500
            Console.WriteLine("\nList of students with balance over $500");
            IEnumerable<Student> balanceOver500 = from student in students
                where student.balance >= 500
                select student;
            foreach (Student student in balanceOver500)
            {
                Console.WriteLine(student);
            }
        }

        // Student class
        public class Student
        {
            public String name;

            public String phoneNumber;

            public String streetAddress;

            public int balance;

            static Random randomNumGen = new Random();

            // Freebie, didn't even need to type but practice is practice
            public Student()
            {

            }

            // Override to convert the string values for the class
            public override String ToString()
            {
                return "Name: " + name + "  Phone: " + phoneNumber + "  Address: " + streetAddress + "  Balance: $" + balance;
            }

            // Static method that builds a random student with random values
            public static Student RandomStudent()
            {
                // Creates a random name
                String randomName = "";
                int randomNameSize = randomNumGen.Next(4, 20); // Random number to determine name length
                for (int i = 0; i < randomNameSize; i++)
                {
                    // If i is equal to 0, first letter is capitalized
                    if (i == 0)
                    {
                        char randomLetter = (char)('A' + randomNumGen.Next(0,26));
                        randomName += randomLetter;
                    } // If i is greater than 0, letter is lower-case
                    else
                    {
                        char randomLetter = (char)('a' + randomNumGen.Next(0,26));
                        randomName += randomLetter;
                    }
                }

                // Generates a random phone number, 10 digits in length
                String randomPhoneNumber = "";
                for (int i = 1; i <= 10; i ++)
                {
                    int randomNum = randomNumGen.Next(1, 10);
                    // If i is less than 4, equal to 5 or 6, or greater than 7, add to the phone number string variable after converting i int
                    if ((i < 4) || (i > 4 && i < 7) || (i > 7))
                    {
                        randomPhoneNumber += randomNum.ToString();
                    } // If i is equal to 4 or 7, add a hypphen before converting i int to string and adding to phone number string
                    else if (i == 4 || i == 7)
                    {
                        randomPhoneNumber += "-" + randomNum.ToString();
                    }
                }

                // The following creates a random street address
                String randomStreetAddress = "";
                // Created a random street number
                randomStreetAddress += randomNumGen.Next(1,6).ToString() + " ";

                // Generates a random number to determine a random street name length
                randomNameSize = randomNumGen.Next(4, 10);

                // Builds the random street name
                for (int i = 0; i < randomNameSize; i++)
                {
                    // If i is equal to 0, first letter is capitalized
                    if (i == 0)
                    {
                        char randomLetter = (char)('A' + randomNumGen.Next(0,26));
                        randomStreetAddress += randomLetter;
                    } // If i is greater than 0, letter is lower-case
                    else
                    {
                        char randomLetter = (char)('a' + randomNumGen.Next(0,26));
                        randomStreetAddress += randomLetter;
                    }
                }

                // Generates random number 0-3, based on output, tacks on a street suffix to the random street name
                int randStreetSuffix = randomNumGen.Next(4);

                if (randStreetSuffix == 0)
                {
                    randomStreetAddress += " St";
                }
                else if (randStreetSuffix == 1)
                {
                    randomStreetAddress += " Dr";
                }
                else if (randStreetSuffix == 2)
                {
                    randomStreetAddress += " Blvd";
                }
                else if (randStreetSuffix == 3)
                {
                    randomStreetAddress += " Way";
                }

                // Generates a random number 0-2500 for the student balance
                int randomBalance = randomNumGen.Next(0, 2501);

                // Creates a new Student object
                Student randomStudent = new Student();
                randomStudent.name = randomName;
                randomStudent.phoneNumber = randomPhoneNumber;
                randomStudent.streetAddress = randomStreetAddress;
                randomStudent.balance = randomBalance;

                return randomStudent;
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace week5_practice8
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person("Mike", "Doe");
            person1.yearOfBirth = 1973;
            person1.gender = 'M';
            person1.hairColor = "Brown";
         
            Person person2 = new Person("John", "Smith");

            Person person3 = new Person();

            Console.WriteLine("First persons name is {0}", person1.fullName());
            Console.WriteLine("Second persons name is {0}", person2.fullName());
            Console.WriteLine("Third persons name is {0}", person3.fullName());

            Console.WriteLine("I have created {0} person instances.", Person.counter);
        }
    }

    class Person
    {
        public String firstName {get; private set;}
        public String lastName {get; private set;}
        public int yearOfBirth;
        public char gender;
        public String hairColor;
        public static int counter;

        // Constructor, any code put here will be run when you instantiate in another place of your
        public Person(String firstName, String lastName)
        {
            if (firstName == null || lastName == null)
            {
                throw new Exception("Everyone must have a first and last name.");
            }
            counter++;

            this.firstName = firstName;
            this.lastName = lastName;
        }

        public Person()
        {
            counter++;
            firstName = "Jane";
            lastName = "Doe";
        }

        public String fullName()
        {
            return firstName + " " + lastName;
        }

        public static String genericHello()
        {
            return "Hi, how are you?";
        }

        public String hello()
        {
            return $"Hi, {fullName()}, how are you?";
        }
    }
}

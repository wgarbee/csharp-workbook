using System;

public class Questions
{
    public static void Main(string[] args)
    {
        string name = "";
        int age = 0;
        int currentYear = DateTime.Now.Year;
        string favoriteAnimal = "";
        string havePets = "";
        string pet = "";
        int numberOfPets = 0;

        Console.WriteLine("Please enter your name: ");
        name = Console.ReadLine();
        Console.WriteLine("Please enter your age: ");
        age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("What is your favorite animal?");
        favoriteAnimal = Console.ReadLine().ToLower();
        Console.WriteLine("Do you have any pets? Enter Y for Yes and N for No");
        havePets = Console.ReadLine().ToUpper();
        if (havePets == "Y" || havePets == "YES")
        {
            Console.WriteLine("Please enter one type of pet you have: ");
            pet = Console.ReadLine().ToLower();
            Console.WriteLine("Please enter number of {0}(s) you have: ", pet);
            numberOfPets = Convert.ToInt32(Console.ReadLine());
        }

        Console.WriteLine("Hello! My name is {0} and I am {1} years old. I was born in {2}.", name, age, currentYear-age);
        if (havePets == "Y" || havePets == "YES")
        {
            Console.WriteLine("My favorite type of animal is a {0}. I have {1} {2}(s).",favoriteAnimal, numberOfPets, pet);
        }
        else 
        {
            Console.WriteLine("My favorite type of animal is a {0}. I do not have any pets.",favoriteAnimal);
        }
    }
}
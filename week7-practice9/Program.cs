using System;

namespace week7_practice9
{
    class Program
    {
        static void Main(string[] args)
        {
            Human wes = new Human("Wes", "Male");
            Human clark = new SuperHuman("Clark", "male", "x-ray vision");
            SuperHuman superman = new SuperHuman("Superman", "male", "super human strength");
            SuperHuman superwoman = new SuperHuman("Superwoman", "female", "super human strength");

            Console.WriteLine(wes.Greetings());
            Console.WriteLine(clark.Greetings());
            Console.WriteLine(superman.Greetings());
            Console.WriteLine(superwoman.Greetings());
        }
    }

    class Human
    {
        public String name;

        public String gender;

        public Human(String name, String gender)
        {
            this.name = name;
            this.gender = gender;
        }

        public virtual String Greetings()
        {
            return String.Format("Hi, my name is {0}. I am a {1}.", name, gender);
        }
    }

    class SuperHuman : Human
    {
        public String superPower;

        public SuperHuman(String name, String gender, String superPower) : base (name, gender)
        {
            this.superPower = superPower;
        }

        public override String Greetings()
        {
            return String.Format("Hi, my name is {0}. I am a {1}. My super power is {2}.", name, gender, superPower);
        }
    }
}

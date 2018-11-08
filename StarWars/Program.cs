using System;

public class Program
{
	public static void Main()
	{
        Person luke = new Person("Luke", "Skywalker", "Rebel");
		Person leia = new Person("Leia", "Organa", "Rebel");
        Person han = new Person("Han", "Solo", "Rebel");
		Person darth = new Person("Darth", "Vader", "Imperial");
        Person emperor = new Person("Emperor", "Palpatine", "Imperial");
        Ship xWing = new Ship("Rebel", "Fighter", 1);
		Ship falcon = new Ship("Rebel", "Smuggler", 2);
		Ship tie = new Ship("Imperial", "Fighter", 1);
        Station yavin = new Station("Yavin 4", "Rebel", 2);
        Station deathStar = new Station("Death Star", "Imperial", 1);

		Console.WriteLine("A long time ago in a galaxy far far away...");
        
        // Updates Leias name
        leia.FullName = "Leia Solo";

        // Han and Leia enter Millenium Falcon
        Console.WriteLine("Han and Leia enter the Falcon...");
        falcon.EnterShip(han, 0);
        falcon.EnterShip(leia, 1);
        Console.ReadLine();

        // Darth enters the tie fighter
        Console.WriteLine("Darth Vader enters the Tie Fighter...");
        tie.EnterShip(darth, 0);
        Console.ReadLine();

        // Shows who is in each ship
        Console.WriteLine(falcon.Passengers);
        Console.WriteLine(tie.Passengers);
        Console.ReadLine();

        // Yavin is captured by Imperial forces
        yavin.Affiliation = "Imperial";
        Console.WriteLine(yavin.Affiliation);
	}
}

class Person
{
	private string firstName;
	private string lastName;
	private string alliance;
	public Person(string firstName, string lastName, string alliance)
	{
		this.firstName = firstName;
		this.lastName = lastName;
		this.alliance = alliance;
	}

	public string FullName
	{
		get
		{
			return this.firstName + " " + this.lastName;
		}

		set
		{
			string[] names = value.Split(' ');
			this.firstName = names[0];
			this.lastName = names[1];
		}
	}
}

class Ship
{
	private Person[] passengers;
	public Ship(string alliance, string type, int size)
	{
		this.Type = type;
		this.Alliance = alliance;
		this.passengers = new Person[size];
	}

	public string Type
	{
		get;
		set;
	}

	public string Alliance
	{
		get;
		set;
	}

	public string Passengers
	{
		get
		{
            String formattedString = "";

			foreach (var person in passengers)
			{
                if (person != null)
                {
                    formattedString += person.FullName + "\n";
                }
                else
                {
                    return formattedString + "That's Everybody!";
                }
				// Console.WriteLine(String.Format("{0}", person.FullName));
			}

			return formattedString + "That's Everybody!";
		}
	}

	public void EnterShip(Person person, int seat)
	{
        if (passengers[seat] == null)
        {
            this.passengers[seat] = person;
        }
        else
        {
            throw new Exception("Someone is already in that seat.");
        }
	}

	public void ExitShip(int seat)
	{
        if (passengers[seat] != null)
        {
            this.passengers[seat] = null;
        }
		else
        {
            throw new Exception("No one is in that seat.");
        }
	}
}

class Station
{
    private String StationName;

    String Affiliation { public get; public set; }

    private int Size;

    private Ship[] ships;

    public Station(String stationName, String type, int size)
    {
        this.StationName = stationName;
        this.Affiliation = type;
        this.Size = size;
    }

    /* public String affiliation
    {
        get
        {
            return Affiliation;
        }

        set
        {
            this.Affiliation = affiliation;
        }
    } */
}
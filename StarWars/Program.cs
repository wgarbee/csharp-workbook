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
        Ship xWing = new Ship("X-Wing", "Rebel", "Fighter", 1);
		Ship falcon = new Ship("Millenium Falcon", "Rebel", "Smuggler", 2);
		Ship tie = new Ship("Tie-Fighter", "Imperial", "Fighter", 1);
        Station yavin = new Station("Yavin 4", "Rebel", 2);
        Station deathStar = new Station("Death Star", "Imperial", 1);

		Console.WriteLine("A long time ago in a galaxy far far away...");
        
        // Updates Leias name
        Console.WriteLine("Leia's name used to be " + leia.FullName);
        leia.FullName = "Leia Solo";
        Console.WriteLine("It is is now " + leia.FullName);

        // Han and Leia enter Millenium Falcon
        yavin.EnterTheStation(falcon, 0);
        Console.WriteLine(han.FullName + " and " +leia.FullName + " enter the " + falcon.ShipName + " on " + yavin.StationName + "...");
        falcon.EnterShip(han, 0);
        falcon.EnterShip(leia, 1);
        Console.ReadLine();

        // Darth enters the tie fighter
        deathStar.EnterTheStation(tie, 0);
        Console.WriteLine(darth.FullName + " enters the " + tie.ShipName + " on the " + deathStar.StationName + "...");
        tie.EnterShip(darth, 0);
        Console.ReadLine();

        // Shows who is in each ship
        Console.WriteLine("Current " + falcon.ShipName + " passengers: ");
        Console.WriteLine(falcon.Passengers);
        Console.WriteLine("\n" + "Current " + tie.ShipName + " passenger:");
        Console.WriteLine(tie.Passengers);
        Console.ReadLine();

        // Darth Vader goes to Yavin 4
        yavin.EnterTheStation(tie, 1);
        Console.WriteLine(yavin.StationName + " currently has: ");
        Console.WriteLine(yavin.stationOccupants);
        Console.ReadLine();

        // Flacon leaves
        yavin.ExitTheStation(0);
        Console.WriteLine(yavin.stationOccupants);
        Console.ReadLine();

        // Darth Vader exits his ship
        tie.ExitShip(0);
        Console.WriteLine(darth.FullName + " exits the tie...");
        Console.WriteLine(tie.Passengers);

        // Yavin is captured by Imperial forces
        Console.WriteLine("Yavin 4 used to be a " + yavin.affiliation + " base...");
        yavin.affiliation = "Imperial";
        Console.WriteLine("It now belongs to the " + yavin.affiliation + " forces...");
	}
}

class Person
{
	private string firstName;
	private string lastName;
	private string alliance;

    // Constructor for the person class, first and last name and their alliance
	public Person(string firstName, string lastName, string alliance)
	{
		this.firstName = firstName;
		this.lastName = lastName;
		this.alliance = alliance;
	}

    // attribute that returns the full name by returning the first and last name in string
	public string FullName
	{
		get
		{
			return this.firstName + " " + this.lastName;
		}

		set
		{   // In order to set the private first and last name, allows user to deconstruct string of first and last name
			string[] names = value.Split(' ');
			this.firstName = names[0];
			this.lastName = names[1];
		}
	}
}

class Ship
{
    // Array of persons in a ship
	private Person[] passengers;

    // Ship constructor for name, if reb or imp, and num passengers
	public Ship(String shipName, String alliance, String type, int size)
	{
        this.ShipName = shipName;
		this.Type = type;
		this.Alliance = alliance;
		this.passengers = new Person[size];
	}

    public String ShipName
    {
        get;
        set;
    }

	public String Type
	{
		get;
		set;
	}

	public String Alliance
	{
		get;
		set;
	}

    // When called, builds the passengers in the ship
	public string Passengers
	{
		get
		{
            String formattedString = "";

			foreach (Person person in passengers)
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

    // Adds a person to a seat in a vehicle
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

    // Removes a person from a seat in the vehicle
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
    // Names the station
    public String StationName { get; private set; }

    // the affiliation of the base
    private String Affiliation;

    // Sets the size of the array of ships
    private int Size;

    // Aray of ships
    private Ship[] Ships;

    public Station(String stationName, String affiliation, int size)
    {
        this.StationName = stationName;
        this.Affiliation = affiliation;
        this.Size = size;
        this.Ships = new Ship[size];
    }

    public String affiliation
    {
        get
        {
            return Affiliation;
        }
        set
        {
            Affiliation = value;
        }
    }

    public String stationOccupants
	{
		get
		{
            String formattedString = "";

			foreach (Ship ship in Ships)
			{
                if (ship != null)
                {
                    formattedString += ship.ShipName + " \n" + ship.Passengers + "\n";
                }
			}
			return formattedString;
		}
	}

    // Dock a ship in the base
    public void EnterTheStation(Ship ship, int location)
	{
        if (Ships[location] == null)
        {
            this.Ships[location] = ship;
        }
        else
        {
            throw new Exception("There is already a ship there.");
        }
	}

    // Embark from base
    public void ExitTheStation(int location)
    {
        if (Ships[location] != null)
        {
            this.Ships[location] = null;
        }
        else
        {
            throw new Exception ("There is no ship in that slot.");
        }
    }
}
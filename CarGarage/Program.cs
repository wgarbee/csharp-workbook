using System;


public class Program
{

	public static void Main()
	{
        Person Claire = new Person("Claire");
        Person John = new Person("John");
        Person Mike = new Person("Mike");

        // instantiating a new instance of car, and  passing "blue" to the constructor;
		Car blueCar = new Car("blue", 4);
        Car redCar = new Car("red", 5);

        Claire.changePassenger("Mary");

        blueCar.SeatPassengers(new String[] {Mike.name, John.name});
        redCar.SeatPassengers(new String[] {Claire.name});
        
        // instantiating a new instaice of Garage class, and passing in 2 to the constructor;
		Garage smallGarage = new Garage(2);
		
        // calling a method ParkCar of the smallGarage instance, with inputs of blueCar and 0
        try
        {
		smallGarage.ParkCar(blueCar, 0);
        smallGarage.ParkCar(redCar, 1);
        }
        catch
        {
            Console.WriteLine("Cannot park here.");
        }

        // printing out the cars attribute of the small garage
		Console.WriteLine(smallGarage.Cars);
	}
}
class Person
{
    public Person(String firstName)
    {
        name = firstName;
    }

    public void changePassenger(String newPassengerName)
    {
        name = newPassengerName;
    }

    public String name { get; private set; }
}

class Car
{
    // Array for passengers in the car
    private String[] passengers;
    public String passengerString;
    // constructor
    // takes in a string that is the intial string
    public Car(string initialColor, int passengerQty)
    {
        // setting the color of the car to be the string passed into the constructor
    	Color = initialColor;
        this.passengers = new String[passengerQty];
    }

    public void SeatPassengers(String[] passengers)
    {
        /* foreach (String person in passengers)
        {
            if (passengers.Length < 2)
            {
                passengerString += person + " ";
            }
            else
            {
                passengerString += person + " and ";
            }
        } */

        for (int i = 0; i < passengers.Length; i++)
        {
            passengerString += passengers[i] + " ";

            if (i != passengers.Length - 1)
            {
                passengerString += "and ";
            }
        }
    }
    
    // changes the color of the car, even though it is a private attribute/variable
    public void paintTheCar(String newColor){
        Color = newColor;
    }

    // once the color is set I cannot change it outisde of this class
    public string Color { get; private set; }
}



class Garage
{
    // an array of cars? what does this do? why is it here?
    private Car[] cars;
    
    // constructor , int of initial size
    public Garage(int initialSize)
    {
        // setting the size of this garage
    	Size = initialSize;
        // instantiating an array of Cars, of size initialsize
	    this.cars = new Car[initialSize];
    }

    //attribute, private for number of slots in the garage.
    public int Size { get; private set; }
    
    // a method that adds a car to the spot in the cars array
    public void ParkCar(Car car, int spot)
    {
        if (cars[spot] == null)
        {
            cars[spot] = car;
        }
        else
        {
            throw new Exception($"Cannot park the {car}.");
        }
    }
    
    
    public string Cars {
		get 
        {
            String carsString = "";
			for (int i = 0; i < cars.Length; i++)
			{
				if (cars[i] != null) {
					carsString += String.Format("The {0} car is in spot {1}.", cars[i].Color, i+1);
                    carsString += "\n";
                    carsString += String.Format("The {0} car has {1}in it.", cars[i].Color, cars[i].passengerString);
                    carsString += "\n";
				}
			}
			return carsString;
		}
	}
}


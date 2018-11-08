using System;
using System.Collections.Generic;

namespace CarLot
{
    class Program
    {
        static void Main(string[] args)
        {
            // Vehicle fordF150 = new Vehicle("Ford", "F150", "Black");
            Lot MacHaik = new Lot("MacHaik");

            // Console.WriteLine(MacHaik.dealerName);
            // Console.WriteLine(fordF150.ToString());

            // MacHaik.parkVehicle(fordF150);

            // Console.WriteLine(MacHaik.showInventory());

            bool done = false;

            while (!done)
            {
                String userInput = UserSelection().ToLower();

                if (userInput == "list")
                {
                    Console.WriteLine(MacHaik.showInventory());
                }
                else if (userInput == "add")
                {
                    MacHaik.parkVehicle(AddToInventory());
                }
                else if (userInput == "remove")
                {
                    int location = DeleteFromInventory();
                    if (location >= 0 && location < MacHaik.numberOfVehicles)
                    {
                        MacHaik.removeVehicle(location);
                        Console.WriteLine(MacHaik.showInventory());
                    }
                    else
                    {
                        Console.WriteLine("Invlaid entry.");
                    }
                }
                else if (userInput == "quit")
                {
                    done = true;
                }

                Console.WriteLine();
            }
        }

        public static String UserSelection()
        {
            Console.WriteLine("What would you like to do with the inventory? list / add / remove?");
            return Console.ReadLine();
        }

        public static Vehicle AddToInventory()
        {
            Console.WriteLine("Please enter the make of the vehicle: ");
            String make = Console.ReadLine();

            Console.WriteLine("Please enter the model of the vehicle: ");
            String model = Console.ReadLine();

            Console.WriteLine("Please enter the color of the vehicle: ");
            String color = Console.ReadLine();

            Vehicle newVehicle = new Vehicle(make, model, color);
            return newVehicle;
        }

        public static int DeleteFromInventory()
        {
            Console.WriteLine("Enter the number location you would like to delete:");
            int location = Convert.ToInt32(Console.ReadLine());

            try
            {
                return location - 1;
            }
            catch
            {
                return -1;
            }
        }
    }

    class Lot
    {
        public String dealerName { get; private set; }

        public int numberOfVehicles;

        private List<Vehicle> vehicles = new List<Vehicle>();

        public Lot(String dealerName)
        {
            this.dealerName = dealerName;
        }

        public void parkVehicle(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
            numberOfVehicles++;
        }

        public void removeVehicle(int spot)
        {
            vehicles.RemoveAt(spot);
            numberOfVehicles--;
        }

        public String showInventory()
        {
            String formattedString = "";
            int placeInInventory = 1;

            if (vehicles.Count > 0)
            {
                foreach (Vehicle vehicle in vehicles)
                {
                    formattedString += placeInInventory + " -- " + vehicle.ToString() + "\n";
                    placeInInventory++;
                }
                return formattedString.Trim();
            }
            else
            {
                return "There are currently no cars in inventory";
            }
        }
    }

    // Superclass for Vehicle
    public class Vehicle
    {
        String make;

        String model;

        String color;

        // int numberOfWheels;

        public Vehicle(String make, String model, String color/* , int numberOfWheels */)
        {
            this.make = make;
            this.model = model;
            this.color = color;
            // this.numberOfWheels = numberOfWheels;
        }

        override
        public String ToString()
        {
            String formattedString = "Make: " + make + "   Model: " + model + "   Color: " + color;

            return formattedString;
        }
    }

    // sub-class for Car - vehicle
    /* public class Car : Vehicle
    {
        bool isHatchBack;
        public Car(String make, String model, String color, bool isHatchBack):base(make, model, color, 4)
        {
            this.isHatchBack = isHatchBack;
        }
    }

    // sub-class for Truck - vehicle
    public class Truck : Vehicle
    {
        public Truck(String make, String model, String color)
        {

        }
    }

    // sub-class for Motorcycle - vehicle
    public class Motorcycle : Vehicle
    {
        public Motorcycle(String make, String model, String color)
        {

        }
    } */
}

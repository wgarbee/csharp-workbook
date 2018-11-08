using System;
using System.Collections.Generic;

namespace CarLot
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle fordF150 = new Vehicle("Ford", "F150", "Black");
            Lot MacHaik = new Lot("MacHaik");

            // Console.WriteLine(MacHaik.dealerName);
            // Console.WriteLine(fordF150.ToString());

            MacHaik.parkVehicle(fordF150);

            // Console.WriteLine(MacHaik.showInventory());

            bool done = false;

            while (!done)
            {
                String userInput = UserSelection();

                if (userInput == "list")
                {
                    Console.WriteLine(MacHaik.showInventory());
                }
                else if (userInput == "add")
                {
                    MacHaik.parkVehicle(AddToInventory());
                }
                else if (userInput == "delete")
                {
                    MacHaik.removeVehicle(DeleteFromInventory());
                }
                else if (userInput == "quit")
                {
                    done = true;
                }
            }
        }

        public static String UserSelection()
        {
            Console.WriteLine("Would you like to do with the inventory? list / add / delete?");
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
            
            return location - 1;
        }
    }

    class Lot
    {
        public String dealerName { get; private set; }

        private List<Vehicle> vehicles = new List<Vehicle>();

        public Lot(String dealerName)
        {
            this.dealerName = dealerName;
        }

        public void parkVehicle(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
        }

        public void removeVehicle(int spot)
        {
            vehicles.RemoveAt(spot);
        }

        public String showInventory()
        {
            String formattedString = "";
            int placeInInventory = 1;
            foreach (Vehicle vehicle in vehicles)
            {
                formattedString += placeInInventory + " -- " + vehicle.ToString() + "\n";
                placeInInventory++;
            }
            return formattedString.Trim();
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

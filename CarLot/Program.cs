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

                    if (/* location > 0 && location < MacHaik.numberOfVehicles &&  */MacHaik.getVehiclesCount.Count > 0)
                    {
                        int location = DeleteFromInventory();
                        MacHaik.removeVehicle(location);
                        if (MacHaik.getVehiclesCount.Count > 0)
                        {
                            Console.WriteLine("Remaining in inventory:");
                            Console.WriteLine(MacHaik.showInventory());
                        }
                    }
                    else
                    {
                        Console.WriteLine("There are no vehicles currently in inventory.");
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
            Console.WriteLine("What would you like to do with the inventory? list / add / remove / quit?");
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

            bool valid = false;
            
            do
            {
                Console.WriteLine("What type of vehicle is this? Car[C] / Truck[T] / Motorcycle[M]");
                String type = Console.ReadLine().ToLower();
            
                if (type == "c" || type == "car")
                {
                    String carType;
                    do
                    {
                        Console.WriteLine("Is this a sedan[S], coupe[C], or hatchback[H]?");
                        carType = Console.ReadLine().ToLower();
                        valid = (carType == "s" || carType == "sedan" || carType == "c" || carType == "coupe" || carType == "h" || carType == "hatchback");
                        if (!valid)
                        {
                            Console.WriteLine("Invalid entry.");
                        }
                        else
                        {
                            Console.WriteLine("Vehicle added to inventory!");
                        }
                    }while (!valid);

                    Vehicle newVehicle = new Car(make, model, color, carType);
                    return newVehicle;
                }
                else if (type == "t" || type == "truck")
                {
                    String truckType;
                    do
                    {
                        Console.WriteLine("Is this a light[L] or heavy[H] duty truck?");
                        truckType = Console.ReadLine().ToLower();
                        valid = (truckType == "l" || truckType == "light" || truckType == "h" || truckType == "heavy");

                        if (!valid)
                        {
                            Console.WriteLine("Invalid entry.");
                        }
                        else
                        {
                            Console.WriteLine("Vehicle added to inventory!");
                        }
                    }while (!valid);
                    
                    Vehicle newVehicle = new Truck(make, model, color, truckType);
                    return newVehicle;
                }
                else if (type == "m" || type == "motorcycle")
                {
                    String motorcycleType;
                    do
                    {
                        Console.WriteLine("Is this a cruiser[C] or sport[S] motorcycle?");
                        motorcycleType = Console.ReadLine().ToLower();
                        valid = (motorcycleType == "c" || motorcycleType == "cruiser" || motorcycleType == "s" || motorcycleType == "sport");
                        
                        if (!valid)
                        {
                            Console.WriteLine("Invalid entry.");
                        }
                        else
                        {
                            Console.WriteLine("Vehicle added to inventory!");
                        }
                    } while (!valid);

                    Vehicle newVehicle = new Motorcycle(make, model, color, motorcycleType);
                    return newVehicle;
                }
                else if (!valid)
                {
                    Console.WriteLine("You must make a valid entry");
                }
            } while (!valid);

            return null;
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

        private List<Vehicle> vehicles = new List<Vehicle>();

        public List<Vehicle> getVehiclesCount
        {
            get
            {
                return this.vehicles;
            }
        }

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
            int locationInInventory = 1;

            if (vehicles.Count > 0)
            {
                foreach (Vehicle vehicle in vehicles)
                {
                    String vehicleClass = vehicle.GetType().Name;
                    formattedString += locationInInventory + " -- " + vehicleClass + " -- " + vehicle.VehicleData() + "\n";
                    locationInInventory++;
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
    public abstract class Vehicle
    {
        String make;

        String model;

        String color;

        int numberOfWheels;

        public Vehicle(String make, String model, String color, int numberOfWheels)
        {
            this.make = make;
            this.model = model;
            this.color = color;
            this.numberOfWheels = numberOfWheels;
        }

        public override String VehicleData()
        {
            return formattedString = $"Make: {make}   Model: {model}   Color: {color}   Number of wheels: {numberOfWheels}";
        }
    }

    // sub-class for Car - vehicle
    public class Car : Vehicle
    {
        public String carType { get; private set; }

        public String vehicleType { get; private set; }

        public Car(String make, String model, String color, String carType) : base(make, model, color, 4)
        {
            if (carType == "s")
            {
                this.carType = "sedan";
            }
            else if (carType == "c")
            {
                this.carType = "coupe";
            }
            else if (carType == "h")
            {
                this.carType = "hatchback";
            }
            else
            {
                this.carType = carType;
            }
        }

        public override String VehicleData()
        {
            return base.VehicleData() + $"   Car type: {carType}";
        }
    }

    // sub-class for Truck - vehicle
    public class Truck : Vehicle
    {
        private String truckType;

        public Truck(String make, String model, String color, String truckType) : base (make, model, color, 4)
        {
            if (truckType == "l")
            {
                this.truckType = "light";
            }
            else if (truckType == "h")
            {
                this.truckType = "heavy";
            }
            else
            {
                this.truckType = truckType;
            }
        }

        public override String VehicleData()
        {
            return base.VehicleData() + $"   Truck type: {truckType}";
        }
    }

    // sub-class for Motorcycle - vehicle
    public class Motorcycle : Vehicle
    {
        private String motorcycleType;

        public Motorcycle(String make, String model, String color, String motorcycleType) : base (make, model, color, 2)
        {
            if (motorcycleType == "c")
            {
                this.motorcycleType = "cruiser";
            }
            else if (motorcycleType == "s")
            {
                this.motorcycleType = "sport";
            }
            else
            {
                this.motorcycleType = motorcycleType;
            }
        }

        public override String VehicleData()
        {
            return base.VehicleData() + $"   Motorcycle type: {motorcycleType}";
        }
    }
}

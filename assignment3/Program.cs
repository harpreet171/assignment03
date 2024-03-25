using System;

public class Vehicle
{
    // Properties
    public string Model { get; private set; }
    public string Manufacturer { get; private set; }
    public int Year { get; private set; }
    public decimal RentalPrice { get; private set; }

    // Constructor
    public Vehicle(string model, string manufacturer, int year, decimal rentalPrice)
    {
        Model = model;
        Manufacturer = manufacturer;
        Year = year;
        RentalPrice = rentalPrice;
    }

    // Method to display vehicle details
    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Model: {Model}");
        Console.WriteLine($"Manufacturer: {Manufacturer}");
        Console.WriteLine($"Year: {Year}");
        Console.WriteLine($"Rental Price: {RentalPrice:C}");
    }
}

public class Car : Vehicle
{
    // Additional properties specific to cars
    public int Seats { get; private set; }
    public string EngineType { get; private set; }
    public string Transmission { get; private set; }
    public bool Convertible { get; private set; }

    // Constructor
    public Car(string model, string manufacturer, int year, decimal rentalPrice, int seats, string engineType, string transmission, bool convertible)
        : base(model, manufacturer, year, rentalPrice)
    {
        Seats = seats;
        EngineType = engineType;
        Transmission = transmission;
        Convertible = convertible;
    }

    // Override method to display car details
    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Seats: {Seats}");
        Console.WriteLine($"Engine Type: {EngineType}");
        Console.WriteLine($"Transmission: {Transmission}");
        Console.WriteLine($"Convertible: {(Convertible ? "Yes" : "No")}");
    }
}

public class Truck : Vehicle
{
    // Additional properties specific to trucks
    public int Capacity { get; private set; }
    public string TruckType { get; private set; }
    public bool FourWheelDrive { get; private set; }

    // Constructor
    public Truck(string model, string manufacturer, int year, decimal rentalPrice, int capacity, string truckType, bool fourWheelDrive)
        : base(model, manufacturer, year, rentalPrice)
    {
        Capacity = capacity;
        TruckType = truckType;
        FourWheelDrive = fourWheelDrive;
    }

    // Override method to display truck details
    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Capacity: {Capacity} tons");
        Console.WriteLine($"Truck Type: {TruckType}");
        Console.WriteLine($"Four-Wheel Drive: {(FourWheelDrive ? "Yes" : "No")}");
    }
}

public class Motorcycle : Vehicle
{
    // Additional properties specific to motorcycles
    public int EngineCapacity { get; private set; }
    public string FuelType { get; private set; }
    public bool HasFairing { get; private set; }

    // Constructor
    public Motorcycle(string model, string manufacturer, int year, decimal rentalPrice, int engineCapacity, string fuelType, bool hasFairing)
        : base(model, manufacturer, year, rentalPrice)
    {
        EngineCapacity = engineCapacity;
        FuelType = fuelType;
        HasFairing = hasFairing;
    }

    // Override method to display motorcycle details
    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Engine Capacity: {EngineCapacity} cc");
        Console.WriteLine($"Fuel Type: {FuelType}");
        Console.WriteLine($"Fairing: {(HasFairing ? "Yes" : "No")}");
    }
}

public class RentalAgency
{

    public Vehicle[] Fleet { get; private set; }
    public decimal TotalRevenue { get; private set; }

    // Constructor
    public RentalAgency(int capacity)
    {
        Fleet = new Vehicle[capacity];
        TotalRevenue = 0;
    }

    // Method to add vehicles to the fleet
    public void AddVehicle(Vehicle vehicle, int index)
    {
        Fleet[index] = vehicle;
    }

    // Method to remove vehicles from the fleet
    public void RemoveVehicle(int index)
    {
        Fleet[index] = null;
    }

    // Method to rent a vehicle
    public void RentVehicle(int index)
    {
        if (Fleet[index] != null)
        {
            TotalRevenue += Fleet[index].RentalPrice;
            Console.WriteLine($"Vehicle {Fleet[index].Model} rented successfully.");
            RemoveVehicle(index);
        }
        else
        {
            Console.WriteLine("No vehicle available at this index.");
        }
    }
}

// Public method to access the fleet program

class Program
{
    static void Main(string[] args)
    {
        // Example usage
        RentalAgency agency = new RentalAgency(10);

        Car car = new Car("Toyota Camry", "Toyota", 2020, 50.00m, 5, "V6", "Automatic", true);
        Truck truck = new Truck("Ford F150", "Ford", 2019, 70.00m, 2, "Pickup", true);
        Motorcycle motorcycle = new Motorcycle("Harley Davidson Sportster", "Harley Davidson", 2021, 80.00m, 1200, "Gasoline", true);

        agency.AddVehicle(car, 0);
        agency.AddVehicle(truck, 1);
        agency.AddVehicle(motorcycle, 2);

        Console.WriteLine("Vehicles available for rent:");
        for (int i = 0; i < 3; i++)
        {
            if (agency.Fleet[i] != null)
            {
                Console.WriteLine($"Index {i}: {agency.Fleet[i].Model}");
            }
        }

        Console.WriteLine($"Total Revenue: {agency.TotalRevenue:C}");
    }
}
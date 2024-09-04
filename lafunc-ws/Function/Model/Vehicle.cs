// Class that can represent a vehicle that has a Brand, Model, Year, Type(Car, Truck, Motorcycle)

/// <summary>
/// Possible types of vehicle
/// </summary>
public enum VehicleType
{
    Car,
    Truck,
    Motorcycle
}

/// <summary>
/// Represents a vehicle of types Car, Truck or Motorcycle.
/// </summary>
public class Vehicle
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public VehicleType Type { get; set; }
}

/*
// Example json representation

{
    "Brand": "Toyota",
    "Model": "Camry",
    "Year": 2022,
    "Type": "Car"
}

*/
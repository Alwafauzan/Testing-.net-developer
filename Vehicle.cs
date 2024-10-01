using System;

public class Vehicle
{
    public Vehicle(string licensePlate, string vehicleType, string vehicleColor)
    {
        LicensePlate = licensePlate;
        VehicleType = vehicleType;
        Color = vehicleColor;
    }

    public string LicensePlate { get; }
    public string VehicleType { get; }
    public string Color { get; set; }
}
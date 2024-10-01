using System;
using System.Collections.Generic;

public class ParkingLot
{
    public ParkingLot(int totalSlots)
    {
        TotalSlots = totalSlots;
        AvailableSlots = totalSlots;
        Vehicles = new List<Vehicle>();
    }

    public int TotalSlots { get; }
    public int AvailableSlots { get; private set; }
    public List<Vehicle> Vehicles { get; }

    public void Park(Vehicle vehicle)
    {
        if (AvailableSlots > 0)
        {
            Vehicles.Add(vehicle);
            AvailableSlots--;
            FilledSlots++;
        }
    }

    public void Unpark(Vehicle vehicle)
    {
        if (Vehicles.Contains(vehicle))
        {
            Vehicles.Remove(vehicle);
            AvailableSlots++;
            FilledSlots--;
        }
    }

    public int FilledSlots { get; private set; }
}
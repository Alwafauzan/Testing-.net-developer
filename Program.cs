using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<ParkingLot> parkingLots = new List<ParkingLot>();
        Console.WriteLine("Input lot:");
        int jumlahLot;
        jumlahLot = Convert.ToInt32(Console.ReadLine());
        parkingLots.Add(new ParkingLot(jumlahLot));

        while (true)
        {
            Console.WriteLine("1. Check-In\n2. Check-Out\n3. Report\n4. Exit");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CheckIn(parkingLots);
                    break;
                case 2:
                    CheckOut(parkingLots);
                    break;
                case 3:
                    Report(parkingLots);
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Pilih angka yang tertera");
                    break;
            }
        }
    }

    static void CheckIn(List<ParkingLot> parkingLots)
    {
        Console.WriteLine("Input tipe kendaraan (Mobil Kecil/Motor):");
        string vehicleType = Console.ReadLine();

        Console.WriteLine("Input plat nomor:");
        string licensePlate = Console.ReadLine();

        Console.WriteLine("Input warna:");
        string vehicleColor = Console.ReadLine();

        if (parkingLots.Any(p => p.Vehicles.Any(v => v.LicensePlate == licensePlate)))
        {
            Console.WriteLine("plat nomor sudah ada");
            return;
        }

        ParkingLot parkingLot = parkingLots.FirstOrDefault(p => p.AvailableSlots > 0);
        if (parkingLot != null)
        {
            Vehicle vehicle = new Vehicle(licensePlate, vehicleType, vehicleColor);
            parkingLot.Park(vehicle);
            Console.WriteLine("Berhasil parkir");
        }
        else
        {
            Console.WriteLine("Slot abis");
        }
    }

    static void CheckOut(List<ParkingLot> parkingLots)
    {
        Console.WriteLine("Input plat nomor: (contoh XX-1234-xx)");
        string licensePlate = Console.ReadLine();

        ParkingLot parkingLot = parkingLots.FirstOrDefault(p => p.Vehicles.Any(v => v.LicensePlate == licensePlate));
        if (parkingLot != null)
        {
            Vehicle vehicle = parkingLot.Vehicles.FirstOrDefault(v => v.LicensePlate == licensePlate);
            if (vehicle != null)
            {
                parkingLot.Unpark(vehicle);
                Console.WriteLine("Berhasil keluar");
            }
            else
            {
                Console.WriteLine("Kendaraan tidak ditemukan");
            }
        }
        else
        {
            Console.WriteLine("Kendaraan tidak ditemukan");
        }
    }

    static void Report(List<ParkingLot> parkingLots)
    {
        Console.WriteLine("Report Parkir");
        Console.WriteLine("----------------");
        Console.WriteLine("Slot terisi:\t" + parkingLots.Sum(p => p.FilledSlots));
        Console.WriteLine("Slot tersedia:\t" + parkingLots.Sum(p => p.AvailableSlots));
        Console.WriteLine();
        Console.WriteLine("Plat Nomor\tTipe\tWarna");
        foreach (ParkingLot parkingLot in parkingLots)
        {
            foreach (Vehicle vehicle in parkingLot.Vehicles)
            {
                Console.WriteLine($"{vehicle.LicensePlate}\t{vehicle.VehicleType}\t{vehicle.Color}");
            }
        }
        Console.WriteLine();
        Console.WriteLine("Jumlah Kendaraan");
        Console.WriteLine("Tipe\tJumlah");
        int totalMobilKecil = 0;
        int totalMotor = 0;
        foreach (ParkingLot parkingLot in parkingLots)
        {
            foreach (Vehicle vehicle in parkingLot.Vehicles)
            {
                if (string.Equals(vehicle.VehicleType, "Mobil Kecil", StringComparison.OrdinalIgnoreCase))
                {
                    totalMobilKecil++;
                }
                else if (string.Equals(vehicle.VehicleType, "Motor", StringComparison.OrdinalIgnoreCase))
                {
                    totalMotor++;
                }
            }
        }
        Console.WriteLine($"Mobil Kecil\t{totalMobilKecil}");
        Console.WriteLine($"Motor\t{totalMotor}");
    }

    static string GetLicensePlateType(string licensePlate)
    {
        string[] parts = licensePlate.Split('-');
        int number = int.Parse(parts[1]);
        if (number % 2 == 0)
        {
            return "genap";
        }
        else
        {
            return "ganjil";
        }
    }
}

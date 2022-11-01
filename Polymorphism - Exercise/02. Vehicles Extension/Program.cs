﻿using System;

namespace VehiclesExtension
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Vehicle car = new Car(double.Parse(carInfo[1]),
                                  double.Parse(carInfo[2]),
                                  double.Parse(carInfo[3]));

            string[] truckInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Vehicle truck = new Truck(double.Parse(truckInfo[1]),
                                      double.Parse(truckInfo[2]),
                                      double.Parse(truckInfo[3]));

            string[] busInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Vehicle bus = new Bus(double.Parse(busInfo[1]),
                                  double.Parse(busInfo[2]),
                                  double.Parse(busInfo[3]));
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();
                string action = command[0];
                string vehicle = command[1];
                double value = double.Parse(command[2]);
                switch (vehicle)
                {
                    case "Car": CompleteCommand(car, action, value); break;
                    case "Truck": CompleteCommand(truck, action, value); break;
                    case "Bus": CompleteCommand(bus, action, value); break;
                    
                }

            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);

        }
        public static void CompleteCommand(Vehicle vehicle, string action, double value)
        {
            switch (action)
            {
                case "Drive":
                    Console.WriteLine(vehicle.Drive(value));
                    break;
                case "DriveEmpty": ((Bus)vehicle).SwitchACOff();
                    Console.WriteLine(vehicle.Drive(value));
                    ((Bus)vehicle).SwitchACon();
                    break;
                case "Refuel":
                    try
                    {
                        vehicle.Refuel(value);
                    }
                    catch ( Exception e)
                    {
                        Console.WriteLine(e.Message);
                        
                    }
                    break;
            }
        }
    }
}

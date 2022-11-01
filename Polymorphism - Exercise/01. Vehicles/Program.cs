using System;
using System.Reflection.PortableExecutable;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            string[] carinfo = Console.ReadLine().Split();
            Vehicle car = new Car(double.Parse(carinfo[1]), double.Parse(carinfo[2]));
            string[] truckinfo = Console.ReadLine().Split();
            Vehicle truck = new Truck(double.Parse(truckinfo[1]), double.Parse(truckinfo[2]));
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split();
                string action = commands[0];
                string typeofVehicle = commands[1];
                double value = double.Parse(commands[2]);
                switch (typeofVehicle)
                {
                    case "Car": CompleteCommand(car, action, value); break;
                    case "Truck": CompleteCommand(truck, action, value); break;
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);

        }
        public static void CompleteCommand(Vehicle vehicle, string action, double value)
        {
            switch (action)
            {
                case "Drive": Console.WriteLine(vehicle.Drive(value));
                    break;
                case "Refuel": vehicle.Refuel(value);
                    break;
            }
        }
    }
}

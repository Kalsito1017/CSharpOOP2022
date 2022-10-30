using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    internal class Tesla : IElectricCar, ICar
    {
        public string Model { get; }
        public string Color { get; }
        public string Start() => "Engine start";
        public string Stop() => "Breaaak!";

        public int Battery { get; }

        public Tesla(string model, string color, int battery)
        {
            Model = model;
            Color = color;
            Battery = battery;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Color} {nameof(Cars.Tesla)} {Model} with {Battery} Batteries");
            sb.AppendLine(this.Start());
            sb.AppendLine(this.Stop());

            return sb.ToString().TrimEnd();
        }
    }
}

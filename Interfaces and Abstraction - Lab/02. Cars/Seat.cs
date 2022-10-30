using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    internal class Seat : ICar
    {
        public string Model { get; }
        public string Color { get; }
        public string Start() => "Engine start";

        public string Stop() => "Breaaak!";

        public Seat(string model, string color)
        {
            Model = model;
            Color = color;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Color} {nameof(Cars.Seat)} {Model}");
            sb.AppendLine(this.Start());
            sb.AppendLine(this.Stop());

            return sb.ToString().TrimEnd();
        }
    }
}

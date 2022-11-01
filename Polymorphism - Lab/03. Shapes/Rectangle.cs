using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        public double Height { get; }
        public double Width { get; }

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }
        public override double CalculatePerimeter() => 2 * (Height + Width);

        public override double CalculateArea() => Height * Width;

        public override string Draw() => base.Draw() + this.GetType().Name;
    }
}

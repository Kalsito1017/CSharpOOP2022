using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : IDrawable
    {
        private int radius;
        public Circle(int radius)
        {
            this.radius = radius;
        }
        public void Draw()
        {
            double rIn = this.radius - 0.4;
            double rOut = this.radius + 0.4;

            for (double i = this.radius; i >= -this.radius; --i)
            {
                for (double j = -this.radius; j < rOut; j += 0.5)
                {
                    double value = Math.Pow(i, 2) + Math.Pow(j, 2);

                    if (value >= Math.Pow(rIn, 2) && value <= Math.Pow(rOut, 2))
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine();
            }
        }

    }
}

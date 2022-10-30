using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    internal interface ICar
    {
        string Model { get; }
        string Color { get; }

        string Start();

        string Stop();
    }
}

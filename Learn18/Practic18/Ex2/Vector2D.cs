using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2
{
    class Vector2D : AbstractNumber
    {
        public double X { get; }
        public double Y { get; }

        public Vector2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override void Print()
        {
            Console.WriteLine($"Вектор: ({X}, {Y})");
        }
    }
}

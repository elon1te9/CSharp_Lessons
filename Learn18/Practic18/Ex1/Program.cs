using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shape circle = new Circle(5);
            Shape rectangle = new Rectangle(4, 6);

            Console.WriteLine(circle);
            Console.WriteLine(rectangle);

            Console.WriteLine($"Сумма площадей: {circle + rectangle:F2}");
            Console.WriteLine($"Круг больше прямоугольника? {circle > rectangle}");
            Console.WriteLine($"Круг меньше прямоугольника? {circle < rectangle}");
        }
    }
}

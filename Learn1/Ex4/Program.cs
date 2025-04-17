using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите значение катета: ");
            double k1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите значение гипотенуза: ");
            double g = Convert.ToDouble(Console.ReadLine());
            double k2 = Math.Sqrt(Math.Pow(g,2) - Math.Pow(k1,2));

            double p = k1 + k2 + g;
            double s = (k1 * k2) / 2;
            Console.WriteLine("Периметр:" + p);
            Console.WriteLine("Площадь: " + s);
        }
    }
}

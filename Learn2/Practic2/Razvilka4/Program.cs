using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Razvilka4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите x");
            double x = Convert.ToDouble(Console.ReadLine());
            double y = 0;
            if (x > 0)
            {
                y = Math.Sin(x);
            }
            else
            {
                y = Math.Cos(x);
            }
            Console.WriteLine("Функция равна= " + y);
        }
    }
}

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
            Console.WriteLine("Введите значение X");
            double x = Convert.ToDouble(Console.ReadLine());
            double n = 0;
            if (x < 3.5 )
            {
                n = (2 * x )/ (-4 * x + 1);
            }
            else if (x >= 3.5)
            {
                n = 4 * Math.Pow(x, 2) + 2 * x - 19;
            }
            Console.WriteLine("Функция равна= " + n);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Practic5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите радиус окружности: ");
            double r1 = Convert.ToDouble(Console.ReadLine());
            int i = 0;
            int j = 0;

            do
            {
                i++;
                Console.WriteLine($"Введите координаты выстрела {i} : ");
                Console.WriteLine("x = ");
                double x = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("y = ");
                double y = Convert.ToDouble(Console.ReadLine());

                if ((Math.Pow((x - r1), 2) + (Math.Pow((y - r1), 2))) <= r1 * r1)
                {
                    Console.WriteLine("Попадание");
                    j++;
                }
                else
                {
                    Console.WriteLine("Промох");
                }

            } while (i < 10);

            Console.WriteLine($"Вы попали {j} раз");

        }
    }
}

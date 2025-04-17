using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число а");
            double a = Convert.ToDouble(Console.ReadLine());
            double S1 = 0;
            double S2 = 1;
            if (a < 0)
            {
                for (int i = 3; i <= 9; i += 2)
                {
                    S1 += i - 2;
                }
                Console.WriteLine($"S = {S1}");
            }
            else
            {
                for (int i = 2; i <= 8; i += 2)
                {
                    S2 *= Math.Pow(i, 2) - a;
                }
                Console.WriteLine($"S = {S2}");
            }

        }
    }
}

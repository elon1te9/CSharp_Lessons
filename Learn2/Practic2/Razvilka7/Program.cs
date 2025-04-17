using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Razvilka7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите x");
            double x = Convert.ToDouble(Console.ReadLine());
            if (x < 0)
            {
                Console.WriteLine("отрицательное число");
            }
            else if (x > 0)
            {
                Console.WriteLine("положительное число");
            }
            else
            {
                Console.WriteLine("нулик");
            }
        }
    }
}

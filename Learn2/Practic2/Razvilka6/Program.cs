using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Razvilka6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x = Convert.ToDouble(Console.ReadLine());
            if (x >= 18)
            {
                Console.WriteLine("можно учавствовать");
            }
            else
            {
                Console.WriteLine("нельзя учавствовать");
            }
        }
    }
}

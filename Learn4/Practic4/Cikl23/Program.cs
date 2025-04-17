using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cikl23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число: ");
            int a = Convert.ToInt32(Console.ReadLine());
            int i = 0;

            do
            {
                if (a % 10 == 7) 
                i++;
                a /= 10;
            } while (a > 0);
            Console.WriteLine(($"В введенном числе {i} семерок"));
            
            
        }
    }
}

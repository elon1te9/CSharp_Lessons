using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Razvilka3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите значение A");
                double a = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите значение B");
                double b = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите значение X");
                double x = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите значение Y");
                double y = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите значение Z");
                double z = Convert.ToDouble(Console.ReadLine());
                if (a <= 0 || b <= 0)
                {
                    Console.WriteLine("дырки нету");
                    if (x <= 0 || y <= 0 || z <= 0)
                    {
                        Console.WriteLine("кирпича нету");
                    }
                }
                else if (x <= 0 || y <= 0 || z <= 0)
                {
                    Console.WriteLine("кирпича нету");
                    if (a <= 0 || b <= 0)
                    {
                        Console.WriteLine("дырки нету");
                    }
                }

                else if ((x <= a && y <= b) || (x <= b && y <= a) ||
             (x <= a && z <= b) || (x <= b && z <= a) ||
             (y <= a && z <= b) || (y <= b && z <= a))
                {
                    Console.WriteLine("о да прошло");
                }

                else
                {
                    Console.WriteLine("косяк, не прошло");
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cikl4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите значение a (1, 2 или 3): ");
            int a = Convert.ToInt32(Console.ReadLine());
            int s = 0;

            switch (a)
            {
                case 1:
                    for (int i = 5; i <= 100; i += 5)
                        s += i;
                    break;

                case 2:
                    for (int i = 5; i <= 20; i += 5)
                        s += i;
                    break;

                case 3:
                    for (int i = 5; i <= 10; i += 5)
                        s += i;
                    break;

                default:
                    s = 100;
                    break;
            }

            Console.WriteLine("Сумма= " + s);
        }
    }
}

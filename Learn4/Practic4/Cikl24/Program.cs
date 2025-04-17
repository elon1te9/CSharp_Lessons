using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cikl24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число: ");
            int a = Convert.ToInt32(Console.ReadLine());
            int i;
            int n = 1;
            if (a % 2 == 1)
            {
                i = 1;
                do
                {
                    n *= i;
                    i += 2;
                } while (i <= a);
            }
            else
            {
                i = 2;
                do
                {
                    n *= i;
                    i += 2;
                } while (i <= a);
            }
            Console.WriteLine(n);

        }
    }
}

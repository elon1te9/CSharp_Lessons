using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string chislo;
            bool ysl;

            do
            {
                Console.Write("Введите число в двоичной системе: ");
                chislo = Console.ReadLine();
                ysl = true;

                for (int i = 0; i < chislo.Length; i++)
                {
                    if (chislo[i] != '0' && chislo[i] != '1')
                    {
                        ysl = false;
                        Console.WriteLine("Число должно содержать только 0 и 1");
                        break;
                    }
                }

            } while (!ysl);

            int res = Convert.ToInt32(chislo, 2);
            Console.WriteLine($"Десятичное число: {res}");
        }
    }
}

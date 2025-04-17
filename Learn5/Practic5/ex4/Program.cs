using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число n - основание");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите число к - показатель степени");
            int k = int.Parse(Console.ReadLine());
            double s = 0;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= k; j++)
                {
                    s += Math.Pow(i, j);
                }
            }
            Console.WriteLine($"сумма всех чисел в заданном диапазоне = {s}");

        }
    }
}

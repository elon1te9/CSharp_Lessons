using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 2, 5, 6, -3, 5, 7, 8, 2, 5, 9 };
            int p = 1;

            for (int i = 0; i < array.Length; i += 2)
            {
                p *= array[i];
            }
            Console.WriteLine($"Произведение элементов массива с четными индексами = {p}");

        }
    }
}

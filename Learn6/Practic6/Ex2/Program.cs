using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 2, 5, 6, -3, 5, 7, 8, 2, 5, 9 };
            int leneven = 0;
            int a = 0;
            int b = 0;
            for (int k = 0; k < array.Length; k++)
            {
                if (array[k] % 2 == 0)
                {
                    leneven++;
                }
            }

            int[] evenNumbers = new int[leneven];
            int[] oddNumbers = new int[array.Length - leneven];

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    evenNumbers[a] = array[i];
                    a++;
                }
                else
                {
                    oddNumbers[b] = array[i];
                    b++;
                }
            }

            Console.WriteLine("Четные числа: " + string.Join(", ", evenNumbers));
            Console.WriteLine("Нечетные числа: " + string.Join(", ", oddNumbers));
        }
    }
}

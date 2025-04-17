using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { -4, -3, 1, -6, -4, -3, -5, -8, 7 };
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] >= 0)
                {
                    for (int j = i + 1; array[j] <= 0; j++)
                    {
                        sum += array[j];
                    }
                    break;
                }

            }
            Console.WriteLine($"Cумма элементов массива, расположенных между первым и вторым положительными элементами = {sum}");
        }
    }
}

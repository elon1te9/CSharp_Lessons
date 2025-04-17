using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { -4, 5, -3, 7, -2 };
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    array[i] = array[i] * array[i];
                }
            }
            Array.Reverse(array);
            Console.WriteLine("Реверснутый массив: " + string.Join(", ", array));
        }
    }
}

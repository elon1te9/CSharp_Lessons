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
            try
            {
                Random random = new Random();
                int[] array = new int[5];
                for (int i = 0; i < 5; i++)
                {
                    int a = random.Next(0, 100);
                    array[i] = a;
                    //Console.WriteLine(a);
                }
                Console.WriteLine("Введите индекс массива: ");
                int n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(array[n]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("За границы ушел");
            }
        }
    }
}

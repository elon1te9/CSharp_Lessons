using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadachkiNaPare
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите 1 число: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите 2 число: ");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Сумма двух чисел: {a + b}");
        }  
    }
}

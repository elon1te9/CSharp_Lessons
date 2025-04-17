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
            Console.WriteLine("Введите значение x");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите значение a");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите значение y");
            int y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите значение b");
            int b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine((a * x) + (y * b));
        }
    }
}

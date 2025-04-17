using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine("Введите значение X");
            int x = Convert.ToInt32(Console.ReadLine()); 
            double y = Math.Abs(x) + Math.Pow(x, 2);
            Console.WriteLine("Значение функции: ");
            Console.WriteLine(y);
        }

    }
}

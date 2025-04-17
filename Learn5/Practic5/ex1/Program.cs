using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число n");

            int n = int.Parse(Console.ReadLine());
            double y = 0;

            for (int i = n * 2 + 1; i >= 0; i -= 2) 
            {
                y = Math.Sqrt(y + i);
            }
            
            Console.WriteLine(y);
        }
    }
}

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
            int n; Console.WriteLine("Введите значение n");
            n = Convert.ToInt32(Console.ReadLine());
            int a = n * n;
            int b = a * a;
            int c = b * b;
            Console.WriteLine("n в восьмой: " + c);       
        }
    }
}

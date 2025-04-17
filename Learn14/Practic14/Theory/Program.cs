using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hello();
            HelloName("Владимир");// "Владмир" фактический параметр
            HelloNameAge("Вова");
            HelloNameAge("Вова", 43);

            Console.WriteLine(Sum());
        }
        static void Hello()
        {
            //метод просто чтото выполняет
            Console.WriteLine("Привет");
        }
        static void HelloName(string name)//name - формальный параметр
        {
            Console.WriteLine($"Привет, {name}");
        }
        static void HelloNameAge(string name, int age=52)
        {
            Console.WriteLine($"Привет, {name}, возраст {age}");
        }
        static double Sum()
        {
            double a = double.Parse(Console.ReadLine() );
            double b = double.Parse(Console.ReadLine());
            return a + b;
        }
    }
}

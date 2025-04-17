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
            Console.WriteLine("Введите первое число: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите второе число: ");
            int b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Сложение: " + MathOperations.Add(a, b));
            Console.WriteLine("Вычитание: " + MathOperations.Subtract(a, b));
            Console.WriteLine("Умножение: " + MathOperations.Multiply(a, b));
            Console.WriteLine("Деление: " + MathOperations.Divide(a, b));
            Console.WriteLine("Остаток от деления: " + MathOperations.Modulus(a, b));
            Console.WriteLine("Возведение в степень: " + MathOperations.Power(a, b));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ооыаоп
{
    internal class Program
    {
        static void Main(string[] args)
        { // Ввод данных
            Console.Write("Введите положительное целое число N: ");
            int N = Convert.ToInt32(Console.ReadLine());

            int sum = 0;

            // Цикл для вычисления суммы чисел от 1 до N
            for (int i = 0; i < N; i++)
            {
                sum += i;
            }

            // Вывод результата
            Console.WriteLine("Сумма чисел от 1 до " + N + " равна " + sum);
        }
    }
}

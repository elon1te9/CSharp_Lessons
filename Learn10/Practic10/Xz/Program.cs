using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Xz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool Koko = true;

            // Одномерный с температурами________________________________________________________________________________________
            Random random = new Random();
            int[] temp = new int[7];
            int sum = 0;
            for (int i = 0; i < 7; i++)
            {
                int a = random.Next(-100, 100);
                temp[i] = a;
                sum += a;
                //Console.WriteLine(a);
            }
            int srz = sum / 5;




            // Двумерный с горами________________________________________________________________________________________________
            int[,] heights = new int[5, 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    heights[i, j] = random.Next(0, 1001);
                }
            }

            // Макс мин высота___________________________________________________________________________________________________
            int min = heights[0, 0], max = heights[0, 0];
            int minRow = 0, minCol = 0, maxRow = 0, maxCol = 0;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (heights[i, j] < min)
                    {
                        min = heights[i, j];
                        minRow = i + 1;
                        minCol = j + 1;
                    }

                    if (heights[i, j] > max)
                    {
                        max = heights[i, j];
                        maxRow = i + 1;
                        maxCol = j + 1;
                    }
                }
            }
            //____________________________________________________________________________________________________________________
            do
            {
                Console.WriteLine("Добро пожаловать в сисмулятор исследовательской миссии на планету!");
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Показать температуру за последние 7 дней");
                Console.WriteLine("2. Найти среднюю температуру за неделю");
                Console.WriteLine("3. Анализировать карту рельефа планеты");
                Console.WriteLine("4. Завершить работу");
                int b = int.Parse(Console.ReadLine());

                switch (b)
                {
                    case 1:
                        Console.WriteLine("Массив температур: " + String.Join(" ", temp));
                        break;
                    case 2:
                        Console.WriteLine($"Среднее значение температуры: {srz}");
                        break;
                    case 3:
                        Console.WriteLine("Карта высот:");
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                Console.Write(heights[i, j].ToString().PadLeft(5));
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine($"Самый низкий участок: {min} метров, координаты: ({minRow}, {minCol})");
                        Console.WriteLine($"Самый высокий участок: {max} метров, координаты: ({maxRow}, {maxCol})");
                        break;
                    case 4:
                        Koko = false;
                        break;

                }
            }
            while (Koko);



        }
    }
}

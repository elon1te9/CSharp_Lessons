using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                Random rand = new Random();
                int[,] array = new int[3, 3];

                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        array[i, j] = rand.Next(0, 5);
                        Console.Write(array[i, j] + " ");
                    }
                    Console.WriteLine();
                }


                for (int i = 0; i < array.GetLength(0); i++)
                {
                    // Находим минимальное значение в текущей строке
                    int minRow = array[i, 0];
                    int minRowColumn = 0;

                    // Проверяем все элементы в строке, чтобы найти все минимальные
                    for (int j = 1; j < array.GetLength(1); j++)
                    {
                        if (array[i, j] < minRow)
                        {
                            minRow = array[i, j];
                            minRowColumn = j; // Обновляем индекс столбца
                        }
                        else if (array[i, j] == minRow)
                        {
                            // Если элемент равен минимальному, то добавляем его индекс в список
                            minRowColumn = j; // Обновляем индекс столбца
                        }
                    }

                    // Проверяем, является ли минимальный элемент в текущей строке седловой точкой
                    bool isSaddlePoint = true;
                    for (int row = 0; row < array.GetLength(0); row++)
                    {
                        if (array[row, minRowColumn] > minRow)
                        {
                            isSaddlePoint = false;
                            break;
                        }
                    }

                    if (isSaddlePoint)
                    {
                        Console.WriteLine($"Седловая точка: {minRow}[{i},{minRowColumn}]");
                    }
                }
            }
        }
    }
}

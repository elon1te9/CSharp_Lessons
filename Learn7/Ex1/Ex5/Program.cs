using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            int firstArrayRow = rnd.Next(2, 4);
            int firstArrayColumn = rnd.Next(2, 4);

            int secondArrayRow = rnd.Next(2, 4);
            int secondArrayColumn = rnd.Next(2, 4);

            int[,] firstArray = new int[firstArrayRow, firstArrayColumn];
            int[,] secondArray = new int[secondArrayRow, secondArrayColumn];

            Console.WriteLine("Первая матрица:");

            for (int i = 0; i < firstArray.GetLength(0); i++)
            {
                for (int j = 0; j < firstArray.GetLength(1); j++)
                {
                    firstArray[i, j] = rnd.Next(1, 9);
                    Console.Write(firstArray[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Вторая матрица:");

            for (int i = 0; i < secondArray.GetLength(0); i++)
            {
                for (int j = 0; j < secondArray.GetLength(1); j++)
                {
                    secondArray[i, j] = rnd.Next(1, 9);
                    Console.Write(secondArray[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Матрица результата");

            if (firstArrayColumn == secondArrayRow)
            {
                int[,] resultArray = new int[firstArrayRow, secondArrayColumn];

                for (int i = 0; i < resultArray.GetLength(0); i++)
                {
                    for (int j = 0; j < resultArray.GetLength(1); j++)
                    {
                        for (int k = 0; k < firstArrayColumn; k++)
                        {
                            resultArray[i, j] += firstArray[i, k] * secondArray[k, j];

                        }
                        Console.Write(resultArray[i, j] + " ");

                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Умножение невозможно");
            }

        }
    }
}

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

            int rows = 4;
            int cols = 6;

            Random rand = new Random();

            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = rand.Next(1, 10);
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            int[] rowSums = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                int sum = 0;
                for (int j = 0; j < cols; j++)
                {
                    sum += matrix[i, j];
                }
                rowSums[i] = sum;
            }


            Console.WriteLine("Суммы строк:");
            for (int i = 0; i < rows; i++)
            {
                Console.Write(rowSums[i] + " ");
            }
            Console.WriteLine();


            int maxSum = rowSums[0];
            for (int i = 1; i < rows; i++)
            {
                if (rowSums[i] > maxSum)
                {
                    maxSum = rowSums[i];
                }
            }

            Console.WriteLine("Максимальная сумма среди строк: " + maxSum);

        }
    }
}

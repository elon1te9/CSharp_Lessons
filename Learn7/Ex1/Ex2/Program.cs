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
            int[,] array = new int[5, 4];

            int maxNumber = 0;
            int numberOccurrences = 1;

            Random rnd = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rnd.Next(1, 9);
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }

            for (int k = 8; k >= 1; k--)
            {
                int counter = 0;

                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        if (array[i, j] == k)
                        {
                            counter++;
                        }
                    }

                }
                if (counter > numberOccurrences)
                {
                    numberOccurrences = counter;
                    maxNumber = k;
                    break;
                }
                
            }
            Console.WriteLine($"Максимальное число, которое встречается в массиве больше одного раза: {maxNumber}; Число вхождений: {numberOccurrences}");
        }
    }
}

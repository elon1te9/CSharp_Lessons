using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите колличество строк: ");
            int st = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите колличество столбцов: ");
            int cl = int.Parse(Console.ReadLine()); 

            Random rand = new Random();

            int[,] matrix = new int[st, cl];

            for (int i = 0; i < st; i++)
            {
                for (int j = 0; j < cl; j++)
                {
                    matrix[i, j] = rand.Next(0, 6);  
                    Console.Write(matrix[i, j] + " ");  
                }
                Console.WriteLine();  
            }

            int noZerost = 0;

            for (int i = 0; i < st; i++)
            {
                bool hasZero = false;  

                for (int j = 0; j < cl; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        hasZero = true; 
                        break;  
                    }
                }

                if (!hasZero)
                {
                    noZerost++;
                }
            }
            Console.WriteLine("Количество строк без нулей: " + noZerost);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exx3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool a = true;
            do
            {
                try
                {
                    Console.Write("Введите положительное число: ");
                    int number = int.Parse(Console.ReadLine());

                    if (number < 0)
                    {
                        throw new ArgumentException("Введено отрицательное число");
                    }
                    if (number > 0)
                    {
                        Console.WriteLine("GOOD JOB!!!!!!!!");
                        for (int i = 0; i < 10000; i++)
                        {
                            Console.Write("<3");
                            i++;
                        }
                        a = false;
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine($"Вы ввели отрицательное число");
                   
                }
            }
            while (a);
           
        }
    }
}

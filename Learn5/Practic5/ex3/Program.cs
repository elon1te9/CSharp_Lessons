using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random(); 
            int randomnumber = rnd.Next(1,10);
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{i+1} попытка");
                int usernumber = int.Parse(Console.ReadLine());
                if (usernumber == randomnumber)
                {
                    Console.WriteLine("угадаллллл");
                    Console.WriteLine($"загаданное число было {randomnumber}");
                    return;
                }
                else
                {
                    Console.WriteLine("не угадал((((");
                }
            }


        }
    }
}

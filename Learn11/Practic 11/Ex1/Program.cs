using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите первое число: ");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите первое число: ");
                int b = Convert.ToInt32(Console.ReadLine());
                int c;
                Console.WriteLine(c = a / b);
            }
            catch (DivideByZeroException) 
            {
                Console.WriteLine("На 0 не дели");
            }
            catch (FormatException)
            {
                Console.WriteLine("Не то ввел");
            }
        }
    }
}

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
            Console.WriteLine("Скоко рублей разменять: ");
            double n = Convert.ToDouble(Console.ReadLine());

            int coins = Convert.ToInt32( n / 5);
            double necoins = n % 5;
            Console.WriteLine("Размененные: " + coins);
            Console.WriteLine("Осталось: " + necoins);

        }
    }
}

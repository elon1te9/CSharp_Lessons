using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Razvilka5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Привет! Как тебя зовут?");
            string x = (Console.ReadLine());
            Console.WriteLine("Привет, Макс. Какая температура на улице?" + " " + x);
            double y = Convert.ToDouble(Console.ReadLine());
            if (y > 20)
            {
                Console.WriteLine("Сегодня хорошая погода. Сейчас бы погулять");
            }
            else
            {
                Console.WriteLine("Хм… А я думал сегодня теплее. Останусь-ка я дома:)");
            }
        }
    }
}

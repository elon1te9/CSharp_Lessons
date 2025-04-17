using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cikl22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("введите а");
            int a = Convert.ToInt16(Console.ReadLine());
            if (a < 0)
            {
                int S = 0;
                int i = 3;
                do
                {
                    S = (i - 2) + S;
                    i = i + 2;
                } while (i <= 9);
                Console.WriteLine(S);
            }
            else
            {
                int S = 1;
                int i = 2;
                do
                {
                    S = (i * i - a) * S;
                    i = i + 2;
                } while (i <= 8);
                Console.WriteLine(S);
            }
        }
    }
}

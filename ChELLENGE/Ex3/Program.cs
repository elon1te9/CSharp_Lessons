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
            int proizv = 0;
            for (int i = 100; i < 1000; i++)
            {
                for (int j = 100;j < 1000; j++)
                {
                    proizv = i * j;
                    int a = 0;
                    while (proizv > 0)
                    {
                        a = a * 10 + a % 10;
                        proizv /= 10;
                        
                    }
                    Console.WriteLine(a);
                    if (a == proizv)
                    {
                        Console.WriteLine(proizv);
                    }
                }
            }
        }
    }
}

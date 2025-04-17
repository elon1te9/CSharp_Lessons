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
            int sum = 0;
            int a = 1;

            while (a*5 != sum)
            {
                sum+=a;
                a++;
            }
            Console.WriteLine(a);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    internal class Program
    {
        static void Main()
        {
            Zdanie building1 = new Zdanie(50, 10, 100, 2);
            building1.PrintInfo();
            Console.WriteLine(); 
            Zdanie building2 = new Zdanie(60, 12, 144, 3);
            building2.PrintInfo(); 
        }
    }
}

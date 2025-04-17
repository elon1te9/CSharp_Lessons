using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int tc = -50; tc <= 50; tc++)
            {
                double tf = tc * (9/5) + 32;
                Console.WriteLine($"{tc} C = {tf} F");
            }

        }
    }
}

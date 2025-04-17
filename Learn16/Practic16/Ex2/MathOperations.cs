using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2
{
    static class MathOperations
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int Subtract(int a, int b)
        {
            return a - b;
        }

        public static int Multiply(int a, int b)
        {
            return a * b;
        }

        public static int Divide(int a, int b)
        {
            if (b == 0)
            {
                Console.WriteLine("Ошибка! На 0 делить нельзя!");
            }
            return a / b;
        }

        public static int Modulus(int a, int b)
        {
            if (b == 0)
            {
                Console.WriteLine("Ошибка! На 0 делить нельзя!");
            }
            return a % b;
        }

        public static int Power(int a, int b)
        {
            return (int)Math.Pow(a, b);
        }
    }
}

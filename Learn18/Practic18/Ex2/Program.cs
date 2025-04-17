using System;
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
            Vector2D v = new Vector2D(3, 4);
            v.Print(); 

            ComplexNumber c1 = new ComplexNumber(2, 3);
            ComplexNumber c2 = new ComplexNumber(1, -4);

            c1.Print();  
            c2.Print(); 

            ComplexNumber sum = c1 + c2;
            ComplexNumber min = c1 - c2;
            ComplexNumber um = c1 * c2;
            ComplexNumber del = c1 / c2;

            Console.WriteLine("Операции с комплексными числами (+ - * /):");
            sum.Print();  
            min.Print(); 
            um.Print(); 
            del.Print(); 
        }
    }
}

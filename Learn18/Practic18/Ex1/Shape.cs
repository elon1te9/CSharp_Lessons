using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    abstract class Shape
    {
        public abstract double GetArea(); 
        public abstract double GetPerimeter(); 

        public static double operator +(Shape a, Shape b)
        {
            return a.GetArea() + b.GetArea();
        }

        public static string operator >(Shape a, Shape b)
        {
            return $"{(a.GetArea() > b.GetArea() ? "a" : "b")}" ;
        }
        public static string operator <(Shape a, Shape b)
        {
            return $"{(a.GetArea() > b.GetArea() ? "b" : "a")}";
        }
        //public static bool operator <(Shape a, Shape b)
        //{
        //    return a.GetArea() < b.GetArea();
        //}
    }
}

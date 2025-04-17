using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theory
{
    class Student
    {
        int Number {  get; set; }
        public string FIO { get; set; }
        static int number = 0;
        public Student(string FIO)
        {
            this.Number = GetNumber;
            this.FIO = FIO;
        }
        public static int GetNumber => number;
        public void Info()
        {
            Console.WriteLine($"Студент {FIO} - {GetNumber} ;");
        }

        public static void GetTex()
        {
            Console.WriteLine("МЦК-КТИТС");
        }
    }
}

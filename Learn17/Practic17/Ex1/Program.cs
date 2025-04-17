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
            Employee emp = new Employee("Алексей Смирнов", 40, 50000);
            emp.ShowInfo();
            Console.WriteLine();

            Manager mgr = new Manager("Ирина Петрова", 40, 50000, 5);
            mgr.ShowInfo();
            Console.WriteLine();

            Developer dev = new Developer("Дмитрий Иванов", 40, 50000, "C#");
            dev.ShowInfo();
            Console.WriteLine();

            Intern intern = new Intern("Анна Сидорова", 40, 500000, "МЦК-КТИТС");
            intern.ShowInfo();
        }
    }
}

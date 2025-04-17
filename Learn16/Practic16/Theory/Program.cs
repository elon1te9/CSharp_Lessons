using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theory
{
    //private
    //класс internal - доступ в пределах одного проекта
    //protected
    //protected internal
    //класс public - общеоступный
    //private protected

    //ключевое слово static - исп для обьявления статического элемента принадлежащего собственному типу, а не конкретному обьекту





    class Program
    {
        static void Main()
        {
            Student student = new Student("Кокоджамбо");
            Student student1 = new Student("Гомо");
            Student student2 = new Student("Мого");
            Student student3 = new Student("Города");
            student.Info();
            student1.Info();
            student2.Info();
            student3.Info();
            Student.GetTex();
        }
    }
}

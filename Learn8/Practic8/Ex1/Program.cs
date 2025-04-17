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
            string[] students = { "Иванов И.И.", "Петров П.П.", "Иванов А.А.", "Сидоров С.С.", "Иванов И.И.", "Иванов И.И.", "Смирнов В.В."};

            for (int i = 0; i < students.Length; i++)
            {
                string surname = students[i].Split(' ')[0];
                int count = 0; 

                for (int j = 0; j < students.Length; j++)
                {
                    if (i != j && students[j].Split(' ')[0] == surname)
                    {
                        count++;
                    }
                }

                Console.WriteLine($"{students[i]} - однофамильцев: {count}");
            }
        }
    }
}

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
            List<string> employees = new List<string>()
            {
            "Габитов Амир Ирекович",
            "Смирнов Владимир Викторович",
            "Иванов Иван Иванович"
            };

            while (true)
            {
                Console.WriteLine("Введите команду (Add, Delete, Viewing, End):");
                string command = Console.ReadLine();

                if (command == "End")
                {
                    Console.WriteLine("Программа завершена");
                    break;
                }

                switch (command)
                {
                    case "Add":
                        Console.WriteLine("Введите ФИО сотрудника для добавления:");
                        string newEmployee = Console.ReadLine();
                        employees.Add(newEmployee);
                        Console.WriteLine("Сотрудник добавлен.");
                        break;

                    case "Delete":
                        try
                        {
                            Console.WriteLine("Введите номер или имя сотрудника для удаления:");
                            string a = Console.ReadLine();
                            if (int.TryParse(a, out int index))
                            {
                                Console.WriteLine($"Сотрудник {employees[index - 1]} удалён.");
                                employees.RemoveAt(index - 1);
                            }
                            else
                            {
                                bool flag = true;
                               
                                for (int i = 0; i < employees.Count; i++)
                                {
                                    if (employees[i] == a)
                                    {
                                        Console.WriteLine($"Сотрудник {employees[i]} удалён.");
                                        employees.RemoveAt(i);
                                        flag = false;
                                        break;
                                    }
                                    
                                }
                                if (flag)
                                {
                                    Console.WriteLine("Сотрудник не найден");
                                }
                            }
                        }
                        catch 
                        {
                            Console.WriteLine("НЕ ВЕРНО ВВЕЛИ НОМЕР");
                        }
                        break;

                    case "Viewing":
                        Console.WriteLine("Список сотрудников:");
                        for (int i = 0; i < employees.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {employees[i]}");
                        }
                        break;

                    default:
                        Console.WriteLine("Неизвестная команда. Попробуйте снова.");
                        break;
                }

                Console.WriteLine("________________________________________________________________________________________________________________________");
            }
        }
    }
}

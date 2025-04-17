using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> students = new Dictionary<string, int>();

            while (true)
            {
                Console.WriteLine("________________________________________________________________________________________________________________________");
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Добавить или обновить оценку студента");
                Console.WriteLine("2. Вывести список студентов и их оценок");
                Console.WriteLine("3. Подсчитать и вывести средний балл");
                Console.WriteLine("4. Подсчитать абсолютную и качественную успеваемость");
                Console.WriteLine("5. Выйти");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();
                Console.WriteLine("________________________________________________________________________________________________________________________");

                switch (choice)
                {
                    case "1":
                        Console.Write("Введите имя студента: ");
                        string name = Console.ReadLine();
                        Console.Write("Введите оценку: ");
                        if (int.TryParse(Console.ReadLine(), out int grade) && grade >= 2 && grade <= 5)
                        {
                            students[name] = grade;
                            Console.WriteLine("Оценка добавлена или обновлена.");
                        }
                        else
                        {
                            Console.WriteLine("Некорректная оценка. Попробуйте снова.");
                        }
                        break;

                    case "2":
                        Console.WriteLine("Список студентов и их оценок:");
                        foreach (var student in students)
                        {
                            Console.WriteLine($"{student.Key}: {student.Value}");
                        }
                        break;

                    case "3":
                        if (students.Count > 0)
                        {
                            double average = students.Values.Average();
                            Console.WriteLine($"Средний балл: {average}");
                        }
                        else
                        {
                            Console.WriteLine("Список студентов пуст.");
                        }
                        break;

                    case "4":
                        if (students.Count > 0)
                        {
                            int totalStudents = students.Count;

                            int with3 = 0;
                            int without3 = 0;
                            foreach (var student in students)
                            {
                                if (student.Value != 2)
                                {
                                    with3++;
                                }

                                if (student.Value != 3 && student.Value != 2)
                                {
                                    without3++;
                                }
                            }
                            double absolute = with3 * 100 / totalStudents; 
                            double quality = without3 * 100 / totalStudents;

                            Console.WriteLine($"Абсолютная успеваемость: {absolute}%");
                            Console.WriteLine($"Качественная успеваемость: {quality}%");
                        }
                        else
                        {
                            Console.WriteLine("Список студентов пуст.");
                        }
                        break;

                    case "5":
                        Console.WriteLine("Выход из программы.");
                        return;

                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }

            }
        }
    }
}

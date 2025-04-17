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
            Dictionary<string, string> contacts = new Dictionary<string, string>();

            while (true)
            {
                Console.WriteLine("________________________________________________________________________________________________________________________");
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Добавить контакт");
                Console.WriteLine("2. Удалить контакт");
                Console.WriteLine("3. Изменить номер контакта");
                Console.WriteLine("4. Искать контакт по имени");
                Console.WriteLine("5. Искать контакт по номеру");
                Console.WriteLine("6. Просмотреть все контакты");
                Console.WriteLine("7. Выйти");
                Console.Write("Выберите действие: ");
                string choice = Console.ReadLine();
                Console.WriteLine("________________________________________________________________________________________________________________________");


                switch (choice)
                {
                    case "1":
                        Console.Write("Введите имя: ");
                        string nameToAdd = Console.ReadLine();
                        Console.Write("Введите номер телефона: ");
                        string phoneToAdd = Console.ReadLine();

                        if (contacts.ContainsKey(nameToAdd))
                        {
                            Console.WriteLine("Контакт с таким именем уже существует.");
                        }
                        else if (!long.TryParse(phoneToAdd, out long a))
                        {
                            Console.WriteLine("Это не номер.");
                        }
                        else
                        {
                            contacts.Add(nameToAdd, phoneToAdd);
                            Console.WriteLine("Контакт добавлен.");
                        }
                        break;

                    case "2":
                        Console.Write("Введите имя для удаления: ");
                        string nameToRemove = Console.ReadLine();

                        if (contacts.Remove(nameToRemove))
                        {
                            Console.WriteLine("Контакт удалён.");
                        }
                        else
                        {
                            Console.WriteLine("Контакт с таким именем не найден.");
                        }
                        break;

                    case "3":
                        Console.Write("Введите имя для изменения номера: ");
                        string nameToUpdate = Console.ReadLine();

                        if (contacts.ContainsKey(nameToUpdate))
                        {
                            Console.Write("Введите новый номер телефона: ");
                            string newPhone = Console.ReadLine();
                            contacts[nameToUpdate] = newPhone;
                            Console.WriteLine("Номер обновлён.");
                        }
                        else
                        {
                            Console.WriteLine("Контакт с таким именем не найден.");
                        }
                        break;

                    case "4":
                        Console.Write("Введите имя для поиска: ");
                        string nameToFind = Console.ReadLine();

                        if (contacts.TryGetValue(nameToFind, out string phoneFound))
                        {
                            Console.WriteLine($"Имя: {nameToFind}, Телефон: {phoneFound}");
                        }
                        else
                        {
                            Console.WriteLine("Контакт с таким именем не найден.");
                        }
                        break;

                    case "5":
                        Console.Write("Введите номер телефона для поиска: ");
                        string phoneToFind = Console.ReadLine();

                        bool found = false;
                        foreach (var contact in contacts)
                        {
                            if (contact.Value == phoneToFind)
                            {
                                Console.WriteLine($"Имя: {contact.Key}, Телефон: {contact.Value}");
                                found = true;
                                break;
                            }
                        }

                        if (!found)
                        {
                            Console.WriteLine("Контакт с таким номером не найден.");
                        }
                        break;

                    case "6":
                        Console.WriteLine("Все контакты:");
                        foreach (var contact in contacts)
                        {
                            Console.WriteLine($"Имя: {contact.Key}, Телефон: {contact.Value}");
                        }
                        break;

                    case "7":
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

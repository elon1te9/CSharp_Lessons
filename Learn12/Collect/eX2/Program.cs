using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eX2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> defenseSpells = new List<string>()
            {
            "Магический Щит",
            "Молекулярная Завеса",
            "Мгновенная Неприкосновенность",
            "Мираж Обороны"
            };

            List<string> battleSpells = new List<string>()
            {
            "Буря Огня",
            "Бритва Ветра",
            "Базальтовая Угроза",
            "Блиц-Молния"
            };

            List<string> funSpells = new List<string>()
            {
            "Озвучивание Предметов",
            "Огненные Бабочки",
            "Обезвреживающий Смех",
            "Облачко Конфет"
            };

            List<string> spells = new List<string>()
            {
            "Морозный Барьер",
            "Озорной Звук",
            "Мерцающая Завеса",
            "Молния Отражения",
            "Бешеная Лавина",
            "Огуречное Превращение",
            "Буря Камней"
            };

            const int maxSpells = 10;

            while (true)
            {
                Console.WriteLine("Выберите команду:");
                Console.WriteLine("1. Добавить новое заклинание");
                Console.WriteLine("2. Добавить несколько заклинаний");
                Console.WriteLine("3. Удалить заклинание");
                Console.WriteLine("4. Изменить заклинание");
                Console.WriteLine("5. Показать все заклинания");
                Console.WriteLine("6. Найти заклинания на 'М'");
                Console.WriteLine("7. Использовать заклинание в бою");
                Console.WriteLine("8. Проверить количество заклинаний для защиты");
                Console.WriteLine("9. Удалить все заклинания на 'Б'");
                Console.WriteLine("0. Выйти");

                string command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        Console.WriteLine("________________________________________________________________________________________________________________________");
                        Console.WriteLine("Введите название нового заклинания:");
                        string newSpell = Console.ReadLine();
                        if ((defenseSpells.Contains(newSpell) || battleSpells.Contains(newSpell) || funSpells.Contains(newSpell)) && !spells.Contains(newSpell) && spells.Count < maxSpells)
                        {
                            spells.Add(newSpell);
                            Console.WriteLine("Заклинание добавлено.");
                        }
                        else
                        {
                            Console.WriteLine("Заклинание не существует, уже имеется или превышен лимит.");
                        }
                        break;

                    case "2":
                        Console.WriteLine("________________________________________________________________________________________________________________________");
                        Console.WriteLine("Сколько заклинаний хотите добавить? ");
                        int a = Convert.ToInt32(Console.ReadLine());
                        List<string> spelsslist = new List<string>() { };
                        for (int i = 0; i < a ; i++ )
                        {
                            Console.WriteLine($"Введите название {i+1} заклинания:");
                            string newSpel = Console.ReadLine();
                            if ((defenseSpells.Contains(newSpel) || battleSpells.Contains(newSpel) || funSpells.Contains(newSpel)) && !spells.Contains(newSpel) && spells.Count < maxSpells)
                            {
                                spelsslist.Add(newSpel);
                                Console.WriteLine("Заклинание добавлено.");
                            }
                            else
                            {
                                Console.WriteLine("Такого заклинания нет");
                            }
                        }
                        spells.AddRange(spelsslist);
                        for(int i = 0; i < spelsslist.Count; i++)
                        {
                                Console.Write(spelsslist[i]+"/");
                        }
                        Console.WriteLine("");
                        Console.WriteLine("Эти заклинания добавлены.");
                        break;

                    case "3":
                        Console.WriteLine("________________________________________________________________________________________________________________________");
                        Console.WriteLine("Введите название заклинания для удаления:");
                        string spellToRemove = Console.ReadLine();
                        if (spells.Remove(spellToRemove))
                        {
                            Console.WriteLine("Заклинание удалено.");
                        }
                        else
                        {
                            Console.WriteLine("Заклинание не найдено.");
                        }
                        break;

                    case "4":
                        Console.WriteLine("________________________________________________________________________________________________________________________");
                        Console.WriteLine("Введите название заклинания для изменения:");
                        string oldSpell = Console.ReadLine();
                        if (spells.Contains(oldSpell))
                        {
                            Console.WriteLine("Введите новое название заклинания:");
                            string updatedSpell = Console.ReadLine();
                            if ((defenseSpells.Contains(updatedSpell) || battleSpells.Contains(updatedSpell) || funSpells.Contains(updatedSpell)) && !spells.Contains(updatedSpell))
                            {
                                spells[spells.IndexOf(oldSpell)] = updatedSpell;
                                Console.WriteLine("Заклинание обновлено.");
                            }
                            else
                            {
                                Console.WriteLine("Новое заклинание недоступно или уже существует.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Заклинание не найдено.");
                        }
                        break;

                    case "5":
                        Console.WriteLine("________________________________________________________________________________________________________________________");
                        Console.WriteLine("Список всех заклинаний:");
                        for(int i = 0; i < spells.Count; i++)
                        {
                          Console.WriteLine($"{i+1}.{spells[i]}");
                        }
                        //spells.ForEach(spell => Console.WriteLine(spell));
                        break;

                    case "6":
                        Console.WriteLine("________________________________________________________________________________________________________________________");
                        Console.WriteLine("Заклинания на 'М':");
                        for (int i = 0; i < spells.Count; i++)
                        {
                            var spellsOnM = spells[i].StartsWith("М");
                            if (spells[i].StartsWith("М"))
                            {
                                Console.WriteLine(spells[i]);
                            }
                        }
                        break;

                    case "7":
                        Console.WriteLine("________________________________________________________________________________________________________________________");
                        if (spells.Count > 0)
                        {
                            string usedSpell = spells[0];
                            spells.RemoveAt(0);
                            Console.WriteLine($"Вы использовали заклинание: {usedSpell}");
                        }
                        else
                        {
                            Console.WriteLine("Заклинаний больше нет.");
                        }
                        break;

                    case "8":
                        Console.WriteLine("________________________________________________________________________________________________________________________");
                        int defenseSpellsCount = 0;
                        for (int i = 0; i < spells.Count; i++)
                        {
                            if (spells[i].StartsWith("М"))
                            {
                                defenseSpellsCount++;
                            }
                        }
                        Console.WriteLine($"Осталось {defenseSpellsCount} заклинаний для защиты.");
                        break;

                    case "9":
                        Console.WriteLine("________________________________________________________________________________________________________________________");
                        spells.RemoveAll(del => del.StartsWith("Б"));
                        Console.WriteLine("Все заклинания на 'Б' удалены.");
                        break;

                    case "0":
                        Console.WriteLine("________________________________________________________________________________________________________________________");
                        Console.WriteLine("Выход из программы.");
                        return;

                    default:
                        Console.WriteLine("Неизвестная команда.");
                        break;
                }

                Console.WriteLine("________________________________________________________________________________________________________________________");
            }
        }
    }
}

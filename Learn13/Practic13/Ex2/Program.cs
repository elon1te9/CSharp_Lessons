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
            Dictionary<string, string> translations = new Dictionary<string, string>
            {
                { "hello", "привет" },
                { "world", "мир" },
                { "book", "книга" },
                { "computer", "компьютер" },
                { "programming", "программирование" }
            };

            while (true)
            {
                Console.Write("Введите слово на английском: ");
                string input = Console.ReadLine().ToLower();

                if (input == "exit")
                {
                    Console.WriteLine("Выход из программы.");
                    break;
                }

                if (translations.TryGetValue(input, out string translation))
                {
                    Console.WriteLine($"Перевод: {translation}");
                }
                else
                {
                    Console.WriteLine("Слово отсутствует в словаре.");
                }
            }
        }
    }
}

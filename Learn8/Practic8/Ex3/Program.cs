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
            Console.Write("Введите строку: ");
            string input = Console.ReadLine();

            string[] words = input.Split(' ');

            int count = words.Length;
            Console.WriteLine($"Количество слов: {count}");

            Console.WriteLine("Четные слова:");
            for (int i = 1; i < count; i += 2)
            {
                Console.WriteLine(words[i]);
            }
        }
    }
}

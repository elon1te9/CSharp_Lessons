using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex4
{
    internal class Program
    {
        static void Main(string[] args)
        {// Исходные данные
            string text = "ТВИ ЭО ДКП"; // Исходный текст
            string key = "ОАИП";        // Ключ
            string alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ"; // Алфавит

            // Убираем пробелы из текста
            text = text.Replace(" ", "");

            // Результат шифрования
            string encryptedText = "";

            // Шифруем текст
            for (int i = 0; i < text.Length; i++)
            {
                int textIndex = alphabet.IndexOf(text[i]); // Индекс буквы текста
                int keyIndex = alphabet.IndexOf(key[i % key.Length]); // Индекс буквы ключа
                int newIndex = (textIndex + keyIndex) % alphabet.Length; // Новый индекс
                encryptedText += alphabet[newIndex]; // Добавляем новую букву
            }

            // Добавляем пробелы для финального текста
            encryptedText = $"{encryptedText.Substring(0, 3)} {encryptedText.Substring(3, 2)} {encryptedText.Substring(5)}";

            // Выводим результат
            Console.WriteLine("Зашифрованный текст: " + encryptedText);
            Console.WriteLine("Четвертая буква: " + encryptedText[4]); // Четвёртая буква
        }
    }
    }



}

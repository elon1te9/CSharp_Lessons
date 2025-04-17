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

            bool flag = true;

            string[] drinks = { "Эспрессо", "Капучино", "Латте" };

            int[] stock = { 10, 10, 10 };

            int[] sales = { 0, 0, 0 };

            int[] price = { 100, 150, 200 };

            while (flag)
            {
                Console.WriteLine("Добро пожаловать в 'Кофейню мечты'!");
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Обработать заказ");
                Console.WriteLine("2. Просмотреть статистику продаж");
                Console.WriteLine("3. Проверить запасы на складе");
                Console.WriteLine("4. Завершить работу");

                Console.Write($"Ваш выбор: ");
                string operation = Console.ReadLine();
                Console.WriteLine();

                switch (operation)
                {
                    case "1":

                        Console.WriteLine("Меню напитков:");
                        Console.WriteLine("1. Эспрессо - 100 руб.");
                        Console.WriteLine("2. Капучино - 150 руб.");
                        Console.WriteLine("3. Латте - 200 руб.");
                        Console.Write("Введите номер напитка: ");
                        int numberOfDrink = int.Parse(Console.ReadLine());
                        if (stock[numberOfDrink - 1] > 0)
                        {
                            Console.WriteLine($"Вы заказали: {drinks[numberOfDrink - 1]}. Приятного аппетита!");
                            sales[numberOfDrink - 1] += 1;
                            stock[numberOfDrink - 1] -= 1;
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine($"Извините, {drinks[numberOfDrink - 1]} закончился.");
                            Console.WriteLine();
                            break;
                        }
                        break;


                    case "2":
                        Console.WriteLine("Статистика продаж: ");
                        for (int i = 0; i < sales.Length; i++)
                        {
                            Console.WriteLine($"{drinks[i]}: {sales[i]} продано. Сумма продаж напитка составила: {sales[i] * price[i]} руб.");
                        }
                        Console.WriteLine();
                        break;


                    case "3":
                        Console.WriteLine("Запасы на складе:");
                        for (int i = 0; i < stock.Length; i++)
                        {
                            Console.WriteLine($"{drinks[i]}: {stock[i]} в наличии");
                        }
                        Console.WriteLine();
                        break;


                    case "4":
                        flag = false;
                        break;


                    default:
                        Console.WriteLine("Неверное действие. Попробуйте снова :(");
                        Console.WriteLine();
                        break;


                }
            }
        }
    }
}

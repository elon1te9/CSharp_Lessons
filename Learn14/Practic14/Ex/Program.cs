using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex
{
    class FinanceAssistant
    {
        static void Main()
        {
            Run();   
        }
        static Dictionary<string, List<double>> transactions = new Dictionary<string, List<double>>();

        static void AddTransaction(string category, double amount)
        {
            if (!transactions.ContainsKey(category))
            {
                transactions[category] = new List<double>();
            }
            transactions[category].Add(amount);
            Console.WriteLine("Запись добавлена.");
        }

        static void PrintFinanceReport()
        {
            Console.WriteLine("Финансовый отчет:");
            foreach (var category in transactions)
            {
                double total = category.Value.Sum();
                Console.WriteLine($"{category.Key}: {total} руб. - {category.Value.Count} операций");
            }
        }

        static double CalculateBalance()
        {
            double doh = 0;
            double rash = 0;

            if (transactions.ContainsKey("Доход"))
            {
                doh = transactions["Доход"].Sum();
            }

            foreach (var category in transactions)
            {
                if (category.Key != "Доход")
                {
                    rash += category.Value.Sum();
                }
            }

            return doh - rash;
        }

        static double GetAverageExpense(string category)
        {
            if (transactions.ContainsKey(category))
            {
                return transactions[category].Average();
            }
            else
            {
                return 0;
            }
        }

        static double PredictNextMonthExpenses()
        {
            double totalAverage = 0;
            foreach (var category in transactions)
            {
                if (category.Key != "Доход")
                {
                    totalAverage += GetAverageExpense(category.Key);
                }
            }
            return totalAverage * 30;
        }

        static void PrintStatistics()
        {
            double totalExpenses = 0;
            string mostExpensiveCategory = "";
            string mostFrequentCategory = "";
            double maxExpense = 0;
            int maxCount = 0;

            Dictionary<string, double> expensePercentages = new Dictionary<string, double>();

            foreach (var category in transactions)
            {
                if (category.Key != "Доход")
                {
                    double categorySum = category.Value.Sum();
                    totalExpenses += categorySum;

                    if (categorySum > maxExpense)
                    {
                        maxExpense = categorySum;
                        mostExpensiveCategory = category.Key;
                    }

                    if (category.Value.Count > maxCount)
                    {
                        maxCount = category.Value.Count;
                        mostFrequentCategory = category.Key;
                    }

                    expensePercentages[category.Key] = categorySum;
                }
            }

            Console.WriteLine($"Общая сумма расходов: {totalExpenses} руб.");
            Console.WriteLine($"Самая затратная категория: {mostExpensiveCategory} ({maxExpense} руб.)");
            Console.WriteLine($"Самая частая категория: {mostFrequentCategory} ({maxCount} операций)");
            Console.WriteLine();

            Console.WriteLine("Процентное распределение расходов:");
            foreach (var i in expensePercentages)
            {
                double percentage = (i.Value / totalExpenses) * 100;
                Console.WriteLine($"{i.Key}: {i.Value} руб. ({percentage:F2}%)");
            }
        }

        static void Run()
        {
            while (true)
            {
                Console.WriteLine("\n1. Добавить доход/расход\n2. Показать отчет\n3. Рассчитать баланс\n4. Прогноз на следующий месяц\n5. Статистика\n6. Выход");
                Console.Write("Выберите действие: ");
                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (choice == 6) break;
                switch (choice)
                {
                    case 1:
                        Console.Write("Введите категорию: ");
                        string category = Console.ReadLine();
                        Console.Write("Введите сумму: ");
                        double amount = double.Parse(Console.ReadLine());
                        AddTransaction(category, amount);
                        break;
                    case 2:
                        PrintFinanceReport();
                        break;
                    case 3:
                        Console.WriteLine($"Текущий баланс: {CalculateBalance()} руб.");
                        break;
                    case 4:
                        Console.WriteLine($"Прогнозируемые расходы на следующий месяц: {PredictNextMonthExpenses()} руб.");
                        break;
                    case 5:
                        PrintStatistics();
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод.");
                        break;
                }
            }
        }
    }
}

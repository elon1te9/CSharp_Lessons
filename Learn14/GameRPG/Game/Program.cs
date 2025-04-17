using System;

namespace GameRPG
{
    class Program
    {
        static int playerHP = 100;
        static int maxHP = 100;
        static int gold = 10;
        static int potions = 2;
        static int arrows = 5;
        static int swordDamage = 10;
        static int bowMinDamage = 5;
        static int bowMaxDamage = 15;

        static Random random = new Random();

        static void Main(string[] args)
        {
            InitializeGame();
            StartGame();
        }

        static void InitializeGame()
        {
            Console.WriteLine("Добро пожаловать в Числовой квест ULTIMATE!");
            Console.WriteLine("Ваши начальные характеристики:");
            ShowStats();
        }

        static void StartGame()
        {
            for (int room = 1; room <= 15; room++)
            {
                Console.WriteLine($"\nВы входите в комнату {room}...");
                if (room == 15)
                {
                    FightBoss();
                }
                else
                {
                    ProcessRoom(room);
                }
                if (playerHP <= 0)
                {
                    EndGame(false);
                    return;
                }
            }
            EndGame(true);
        }

        static void ProcessRoom(int roomNumber)
        {
            int eventType = random.Next(1, 9);
            switch (eventType)
            {
                case 1: FightMonster(random.Next(20, 51), random.Next(5, 16)); break;
                case 2: TriggerTrap(); break;
                case 3: OpenChest(false); break;
                case 4: OpenChest(true); break;
                case 5: VisitMerchant(); break;
                case 6: VisitAltar(); break;
                case 7: MeetDarkMage(); break;
                case 8: SolveEvent(); break;
            }
        }

        static void FightMonster(int monsterHP, int monsterAttack)
        {
            Console.WriteLine($"Вы встретили монстра! HP: {monsterHP}, Урон: {monsterAttack}");
            while (monsterHP > 0 && playerHP > 0)
            {
                Console.WriteLine("Выберите оружие: 1 - меч, 2 - лук, 3 - использовать зелье");
                string choice = Console.ReadLine();
                int damage = 0;
                if (choice == "1")
                {
                    damage = random.Next(swordDamage, swordDamage + 10);
                    Console.WriteLine($"Вы ударили мечом на {damage} урона!");
                }
                else if (choice == "2" && arrows > 0)
                {
                    damage = random.Next(bowMinDamage, bowMaxDamage + 1);
                    arrows--;
                    Console.WriteLine($"Вы выстрелили из лука на {damage} урона! Осталось стрел: {arrows}");
                }
                else if (choice == "3" && potions > 0)
                {
                    UsePotion();
                }
                else
                {
                    Console.WriteLine("Неверный выбор!");
                    continue;
                }
                monsterHP -= damage;
                Console.WriteLine($"У монстра осталось {monsterHP} HP");
                Console.WriteLine();
                if (monsterHP > 0)
                {
                    playerHP -= monsterAttack;
                    Console.WriteLine($"Монстр атакует! Вы потеряли {monsterAttack} HP.");
                }
                ShowStats();
            }
            if (monsterHP <= 0)
            {
                Console.WriteLine("Монстр повержен!");
            }
            else
            {
                Console.WriteLine("Вы погибли от лап монстра.");
            }
        }



        static void FightBoss()
        {
            int bossHP = 100;
            Console.WriteLine($"Битва с финальным боссом началась! HP: {bossHP}, Урон: 15-25");
            while (bossHP > 0 && playerHP > 0)
            {
                Console.WriteLine("Выберите оружие: 1 - меч, 2 - лук, 3 - использовать зелье");
                string choice = Console.ReadLine();
                int damage = 0;
                int a = 0;
                if (choice == "1")
                {
                    damage = random.Next(swordDamage, swordDamage + 10);
                    Console.WriteLine($"Вы ударили мечом на {damage} урона!");
                }
                else if (choice == "2" && arrows > 0)
                {
                    damage = random.Next(bowMinDamage, bowMaxDamage + 1);
                    arrows--;
                    Console.WriteLine($"Вы выстрелили из лука на {damage} урона! Осталось стрел: {arrows}");
                }
                else if (choice == "3" && potions > 0)
                {
                    UsePotion();
                }
                else
                {
                    Console.WriteLine("Неверный выбор!");
                    continue;
                }
                bossHP -= damage;
                Console.WriteLine($"У босса осталось {bossHP} HP");
                Console.WriteLine();
                if (bossHP > 0)
                {
                    int bossAttack = random.Next(15, 26);
                    int rdr = random.Next(1, 3);
                    if (rdr == 1)
                    {
                        playerHP -= bossAttack * 2;
                        Console.WriteLine($"Монстр нанес критический удар! Вы потеряли {bossAttack*2} HP");
                        a++;
                    }
                    else
                    {
                        playerHP -= bossAttack;
                        Console.WriteLine($"Монстр атакует! Вы потеряли {bossAttack} HP");
                        a++;
                    }
                    if (a % 3 == 0)
                    {
                        int rdr1 = random.Next(1, 3);
                        if (rdr1 == 1)
                        {
                            bossHP += 10;
                            Console.WriteLine("Босс восстановил 10 HP");
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                ShowStats();
            }
            if (bossHP <= 0)
            {
                EndGame(true);
            }
            else if (playerHP <= 0)
            {
                EndGame(false);
            }
            else
            {
                Console.WriteLine("Ошибка");
            }
        }
        static void UsePotion()
        {
            if (potions > 0)
            {
                int healAmount = 30;
                playerHP += healAmount;

                if (playerHP > maxHP)
                {
                    playerHP = maxHP;
                }
                potions--;
                Console.WriteLine($"Вы выпили зелье и восстановили {healAmount} HP. Текущее здоровье: {playerHP}. Осталось зелий: {potions}.");
            }
            else
            {
                Console.WriteLine("У вас нет зелий!");
            }
        }
        static void EndGame(bool isWin)
        {
            if (isWin)
            {
                Console.WriteLine("Поздравляем! Вы выиграли!");
            }
            else
            {
                Console.WriteLine("К сожалению, вы проиграли.");
                Environment.Exit(0);
            }
        }

        static void TriggerTrap()
        {
            int damage = random.Next(5, 21);
            playerHP -= damage;
            Console.WriteLine($"Вы попали в ловушку! Потеряно {damage} HP.");
            ShowStats();
        }

        static void OpenChest(bool isCursed)
        {
            if (isCursed)
            {
                Console.WriteLine("Вы открыли проклятый сундук!");
                maxHP = Math.Max(10, maxHP - 10);
                gold += random.Next(5, 16);
                Console.WriteLine($"Ваше максимальное здоровье уменьшилось на 10, но вы нашли {gold} золота ");
            }
            else
            {
                Console.WriteLine("Вы открыли обычный сундук!");
                int rdr = random.Next(1, 4);
                if (rdr == 1)
                {
                    gold += random.Next(5, 16);
                    Console.WriteLine("Вы нашли немного золота!");
                }
                else if (rdr == 2)
                {
                    potions += random.Next(1, 4);
                    Console.WriteLine("Вы нашли немного зелий!");
                }
                else if (rdr == 3)
                {
                    arrows += random.Next(1, 16);
                    Console.WriteLine("Вы нашли немного стрел!");
                }
                ShowStats();
            }
        }

        static void VisitAltar()
        {
            if (gold >= 10)
            {
                Console.WriteLine("Вы жертвуете 10 золота алтарю. 1 - Увеличить урон меча, 2 - Восстановить 20 HP");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    swordDamage += 5;
                }
                else if (choice == "2")
                {
                    playerHP = Math.Min(playerHP + 20, maxHP);
                }
                gold -= 10;
            }
            else
            {
                Console.WriteLine("Недостаточно золота для алтаря.");
            }
            ShowStats();
        }

        static void ShowStats()
        {
            Console.WriteLine($"HP: {playerHP}/{maxHP}, Золото: {gold}, Зелья: {potions}, Стрелы: {arrows}, Стандартный урон меча: {swordDamage}");
        }


        static void VisitMerchant()
        {
            Console.WriteLine($"Вы встретили торговца. У вас {gold} золота.");
            Console.WriteLine("1. Купить зелье (10 золота)");
            Console.WriteLine("2. Купить 3 стрелы (5 золота)");
            Console.WriteLine("3. Ничего не покупать");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    if (gold >= 10)
                    {
                        gold -= 10;
                        potions++;
                        Console.WriteLine($"Вы купили зелье. Теперь у вас {potions} зелий.");
                    }
                    else
                    {
                        Console.WriteLine("Недостаточно золота.");
                    }
                    break;
                case "2":
                    if (gold >= 5)
                    {
                        gold -= 5;
                        arrows += 3;
                        Console.WriteLine($"Вы купили стрелы. Теперь у вас {arrows} стрел.");
                    }
                    else
                    {
                        Console.WriteLine("Недостаточно золота.");
                    }
                    break;
                default:
                    Console.WriteLine("Вы решили ничего не покупать.");
                    break;
            }
        }

        static void MeetDarkMage()
        {
            Console.WriteLine("Вы встретили темного мага. Он предлагает сделку:");
            Console.WriteLine("Пожертвовать 10 HP, чтобы получить 2 зелья и 5 стрел.");

            if (playerHP > 10)
            {
                Console.WriteLine("1. Согласиться");
                Console.WriteLine("2. Отказаться");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    playerHP -= 10;
                    potions += 2;
                    arrows += 5;
                    Console.WriteLine("Вы получили 2 зелья и 5 стрел, но потеряли 10 HP.");
                }
                else
                {
                    Console.WriteLine("Вы отказались от сделки с магом.");
                }
            }
            else
            {
                Console.WriteLine("У вас слишком мало здоровья для сделки. Маг исчезает.");
            }
        }

        static void SolveEvent()
        {
            Console.WriteLine("Вас ждёт неожиданное событие! Вот ваша задача:");
            Console.WriteLine("Решите пример: Сколько будет 7 + 5?");
            string answer = Console.ReadLine();

            if (answer == "12")
            {
                Console.WriteLine("Правильно! Вы получаете 10 золота.");
                gold += 10;
            }
            else
            {
                Console.WriteLine("Неправильно. Вы теряете 5 HP.");
                playerHP -= 5;
            }
        }

    }
}

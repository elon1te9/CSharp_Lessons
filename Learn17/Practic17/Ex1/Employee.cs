using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    internal class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }

        public Employee(string name, int age, double salary)
        {
            Name = name;
            Age = age;
            Salary = salary;
        }

        public virtual double CalculateBonus()
        {
            return Salary * 0.05;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Имя: {Name}, Возраст: {Age}, Зарплата: {Salary}, Премия: {CalculateBonus()}");
        }
    }

    class Manager : Employee
    {
        public int TeamSize { get; set; }

        public Manager(string name, int age, double salary, int teamSize) : base(name, age, salary)
        {
            TeamSize = teamSize;
        }

        public override double CalculateBonus()
        {
            return Salary * 0.10 + TeamSize * 500;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Размер команды: {TeamSize}");
        }
    }

    class Developer : Employee
    {
        public string ProgrammingLanguage { get; set; }

        public Developer(string name, int age, double salary, string programmingLanguage) : base(name, age, salary)
        {
            ProgrammingLanguage = programmingLanguage;
        }

        public override double CalculateBonus()
        {
            return Salary * 0.15;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Язык программирования: {ProgrammingLanguage}");
        }
    }

    class Intern : Employee
    {
        public string University { get; set; }

        public Intern(string name, int age, double salary, string university) : base(name, age, salary)
        {
            University = university;
        }

        public override double CalculateBonus()
        {
            return Salary * 0.03;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Университет: {University}");
        }
    }
}

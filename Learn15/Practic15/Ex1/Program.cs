using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{

    class Cone
    {
        double r;
        double h;

        public double Radius
        {
            get { return r; }
            set
            {
                if (value > 0)
                    r = value;
                else
                    Console.WriteLine("Радиус должен быть положительным");
            }
        }

        public double Height
        {
            get { return h; }
            set { if (value > 0) h = value; else Console.WriteLine("Высота должна быть положительной"); }
        }

        public Cone(double radius, double height)
        {
            Radius = radius;
            Height = height;
        }

        public double BaseArea()
        {
            return Math.PI * r * r;
        }

        public double LateralSurfaceArea()
        {
            double l = Math.Sqrt(r * r + h * h);
            return Math.PI * r * l;
        }

        public double TotalSurfaceArea()
        {
            return BaseArea() + LateralSurfaceArea();
        }
    }


    class Car
    {

        public string Brand { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
        public int Year { get; set; }

        public Car(string brand, string color, double price, int year)
        {
            Brand = brand;
            Color = color;
            Price = price;
            Year = year;
        }

        public double PriceWithDiscount()
        {
            return Price * 0.95;
        }

        public void Info()
        {
            Console.WriteLine($"Марка: {Brand}, Цвет: {Color}, Цена: {Price} руб., Год: {Year}");
        }
    }

    // Пример использования классов
    class Program
    {
        static void Main()
        {

            Cone cone = new Cone(5, 6);
            Console.WriteLine("Площадь основания конуса: " + cone.BaseArea());
            Console.WriteLine("Боковая площадь поверхности конуса: " + cone.LateralSurfaceArea());
            Console.WriteLine("Полная площадь поверхности конуса: " + cone.TotalSurfaceArea());
            Console.WriteLine();

            Car car = new Car("Lamborgini", "Белый", 10000000090, 2025);
            car.Info();
            Console.WriteLine("Цена со скидкой: " + car.PriceWithDiscount() + " руб.");
        }
    }

}

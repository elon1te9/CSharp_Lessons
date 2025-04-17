using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    class Zdanie
    {

        static int number = 1;
        private int buildingNumber; 
        private double height; 
        private int floors; 
        private int apartments;
        private int entrances; 

        public Zdanie(double height, int floors, int apartments, int entrances)
        {
            this.buildingNumber = BuildingNumber(); // номер дома
            this.Height = height; // высота
            this.Floors = floors; // колво этажей
            this.Apartments = apartments; // колво квартир
            this.Entrances = entrances; // колво подъездов
        }

        public int BuildingNumber()
        {
            return number++;
        }

        public double Height
        {
            get { return height; }
            set
            {
                if (value > 0)
                    height = value;
            }
        }
        public int Floors
        {
            get { return floors; }
            set
            {
                if (value > 0)
                    floors = value;
            }
        }

        public int Apartments
        {
            get { return apartments; }
            set
            {
                if (value > 0)
                    apartments = value;
            }
        }

        public int Entrances
        {
            get { return entrances; }
            set
            {
                if (value > 0)
                    entrances = value;
            } 
        }

        public double GetFloorHeight()
        {
            return Height / Floors; // высота этажа
        }

        public int GetApartmentsPerEntrance()
        {
            return Apartments / Entrances; // колво квартир в подъезе
        }

        public int GetApartmentsPerFloor()
        {
            return Apartments / Floors; // колво квартир на этаже
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Дом №{buildingNumber}"); 
            Console.WriteLine($"Высота дома - {Height} m");
            Console.WriteLine($"Этажей - {Floors}"); 
            Console.WriteLine($"Квартир - {Apartments}"); 
            Console.WriteLine($"Подъездов -  {Entrances}"); 
            Console.WriteLine($"Высота каждого этажа -  {GetFloorHeight():F2} m"); 
            Console.WriteLine($"Количество квартир в каждом подъезде - {GetApartmentsPerEntrance()}"); 
            Console.WriteLine($"Количество квартир на каждом этаже - {GetApartmentsPerFloor()}"); 
        }
    }
}

using System;

namespace LampenWereld
{
    class Program
    {
        static void Main(string[] args)
        {
            //Lamp obj = new Lamp(-200, ConsoleColor.Red);
            Lamp obj = new Lamp { Lumen = -200, Kleur = ConsoleColor.Red };
            // obj.lumen = -300;
            //obj.Kleur = ConsoleColor.Magenta;
            //obj.Lumen = 350;
            obj.Aan();
            obj.Uit();
        }
    }

    // Blauwdruk lamp
    class Lamp
    {
        // Fields: Hierin sla je eigenschappen op
        private int lumen = 100;

        //public void SetLumen(int val)
        //{
        //    if (val >= 0 && val < 1000)
        //    {
        //        this.lumen = val;
        //    }
        //}
        //public int GetLumen()
        //{
        //    return this.lumen;
        //}
        // Properties: Geven gecontroleerde toegang tot fields (encapsulation)

        // Auto generating property
        public ConsoleColor Kleur { get; set; } = ConsoleColor.Yellow;

        public int Lumen
        {
            get
            {
                return this.lumen;
            }
            set
            {
                if (value >= 0 && value < 1000)
                {
                    this.lumen = value;
                }
            }
        }


        // Methods: Hierin leg je gedrag vast
        public void Aan()
        {
            Console.BackgroundColor = Kleur;
            Console.WriteLine($"De lamp brandt met {Lumen} lumen");
        }
        public void Uit()
        {
            Console.ResetColor();
            Console.WriteLine("De lamp is uit");
        }

        // Constructors: Gebruik je om fields van een initiele waarde te voorzien
        //public Lamp() : this(100, ConsoleColor.Yellow)
        //{
        //    //lumen = 100;
        //    //kleur = ConsoleColor.Yellow;
        //}
        //public Lamp(int lumen, ConsoleColor kleur)
        //{
        //    Lumen = lumen;
        //    Kleur = kleur;
        //}
    }
}

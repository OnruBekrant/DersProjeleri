using System;

namespace AbstractionShapes
{
    abstract class Sekil
    {
        public abstract void Ciz(); // Gövdesi yok, mecbur ezilecek
    }

    class Kare : Sekil
    {
        public override void Ciz() { Console.WriteLine("Kare çizildi."); }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Sekil s = new Sekil(); // HATA! Abstract new'lenemez.
            Sekil s = new Kare();
            s.Ciz();
        }
    }
}
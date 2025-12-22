using System;

namespace PolymorphismZoo
{
    class Hayvan
    {
        public virtual void SesCikar() { Console.WriteLine("Hayvan sesi"); }
    }

    class Kedi : Hayvan
    {
        public override void SesCikar() { Console.WriteLine("Miyav (Override)"); }
    }

    class Kopek : Hayvan
    {
        public new void SesCikar() { Console.WriteLine("Hav Hav (New - Gizleme)"); }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Hayvan h1 = new Kedi();
            h1.SesCikar(); // ÇIKTI: Miyav (Çünkü override edildi, çekirdek değişti)

            Hayvan h2 = new Kopek();
            h2.SesCikar(); // ÇIKTI: Hayvan sesi (Çünkü new ile sadece kabuk değişti, referans Hayvan olduğu için asıl metoda gitti)
        }
    }
}
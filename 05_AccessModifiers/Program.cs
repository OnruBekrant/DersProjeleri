using System;

namespace AccessModifiers
{
    class Ata
    {
        public int HalkaAcik = 1;
        protected int AileyeOzel = 2;
        private int BanaOzel = 3;
    }

    class Cocuk : Ata
    {
        public void Goster()
        {
            Console.WriteLine($"Public: {HalkaAcik}");
            Console.WriteLine($"Protected: {AileyeOzel}");
            // Console.WriteLine(BanaOzel); // HATA! Private mirasta geçmez.
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Cocuk c = new Cocuk();
            c.Goster();
            // c.AileyeOzel = 5; // HATA! Protected dışarıdan erişilemez.
        }
    }
}
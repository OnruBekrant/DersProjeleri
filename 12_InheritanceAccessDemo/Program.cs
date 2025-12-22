using System;

namespace InheritanceAccessDemo
{
    class Varlik
    {
        private int _privDegisken = 1;   // Sadece Varlık görür
        protected int ProtDegisken = 2;  // Varlık + Kedi görür
        public int PublicDegisken = 3;   // Herkes görür

        public void DenemeVarlik()
        {
            Console.WriteLine($"Varlık İçi: {_privDegisken}, {ProtDegisken}, {PublicDegisken}");
        }
    }

    class Kedi : Varlik
    {
        public void DenemeKedi()
        {
            // _privDegisken = 5; // HATA! Private erişilemez.
            ProtDegisken = 5;    // OK! Protected mirasta geçerlidir.
            PublicDegisken = 10; // OK!
            
            Console.WriteLine($"Kedi (Mirasçı) İçi: Protected={ProtDegisken}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Kedi k = new Kedi();
            k.PublicDegisken = 99; // OK
            // k.ProtDegisken = 99; // HATA! Dışarıdan protected görülmez.
            
            k.DenemeKedi();
            Console.ReadLine();
        }
    }
}
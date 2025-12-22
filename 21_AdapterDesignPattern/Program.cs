using System;

namespace AdapterDesignPattern
{
    // 1. Hedef (Target) - Bizim elimizdeki eski sistem (Örn: 220V Priz)
    class EskiSistem
    {
        public virtual void SarjEt(int voltaj)
        {
            Console.WriteLine($"Eski Sistem: {voltaj}V ile şarj ediliyor.");
        }
    }

    // 2. Adapte Edilen (Adaptee) - Uyumsuz yeni sistem (Örn: Telefon 5V ister)
    class YeniTelefon
    {
        public void Calistir(int voltaj, int amper)
        {
            Console.WriteLine($"Yeni Telefon: {voltaj}V ve {amper}A ile güvenle şarj oluyor.");
        }
    }

    // 3. Adaptör (Adapter) - Aradaki çevirici
    class Adapter : EskiSistem
    {
        private YeniTelefon _telefon;

        public Adapter()
        {
            _telefon = new YeniTelefon();
        }

        public override void SarjEt(int voltaj)
        {
            Console.WriteLine($"Adaptör Devrede: Gelen {voltaj}V dönüştürülüyor...");
            // Eski sistemden gelen voltajı (örn 220), yeni sisteme uygun hale (5V) getirip iletiyoruz.
            int donusturulenVoltaj = 5; 
            _telefon.Calistir(donusturulenVoltaj, 2); // 2 Amper sabit verdik
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Dönüştürücü Olmadan ---");
            EskiSistem priz = new EskiSistem();
            priz.SarjEt(220);

            Console.WriteLine("\n--- Dönüştürücü (Adapter) İle ---");
            EskiSistem adaptorluPriz = new Adapter(); // Tipi hala 'EskiSistem' ama içi Adapter
            adaptorluPriz.SarjEt(220);
        }
    }
}
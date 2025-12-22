using System;

namespace PolymorphismNotes
{
    // Ata Sınıf
    class Varlik
    {
        public virtual void HareketEt()
        {
            Console.WriteLine("Varlık: Standart hareket ediyor.");
        }

        public void SesVer()
        {
            Console.WriteLine("Varlık: Standart ses veriyor.");
        }
    }

    // Çocuk Sınıf 1
    class Kedi : Varlik
    {
        // Override: Çekirdeği değiştiriyoruz (Referans Varlık olsa bile bu çalışır)
        public override void HareketEt()
        {
            Console.WriteLine("Kedi: Süzülerek hareket ediyor (Override).");
        }

        // New: Sadece Kedi referansında çalışır, Varlık referansında gizlenir.
        public new void SesVer()
        {
            Console.WriteLine("Kedi: Miyav (New).");
        }
    }

    // Çocuk Sınıf 2
    class Kopek : Varlik
    {
        public override void HareketEt()
        {
            Console.WriteLine("Köpek: Koşarak hareket ediyor (Override).");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- 1. DURUM: Kendi Referansları ---");
            Kedi k1 = new Kedi();
            k1.HareketEt(); // Kedi gibi
            k1.SesVer();    // Kedi gibi

            Console.WriteLine("\n--- 2. DURUM: Polymorphism (Ata Referansı) ---");
            
            // FOTOĞRAFTAKİ ÖRNEK SENARYO BURADA BAŞLIYOR
            
            Varlik v1 = new Varlik(); // Saf Varlık
            Varlik v2 = k1;           // Kedi nesnesini Varlık kutusuna koyduk (Liskov)
            Varlik v3 = new Kopek();  // Köpek nesnesini Varlık kutusuna koyduk

            // HareketEt (Virtual/Override olduğu için ÇEKİRDEK çalışır)
            Console.Write("v1.HareketEt -> "); v1.HareketEt(); 
            Console.Write("v2.HareketEt -> "); v2.HareketEt(); // Kedi gibi çalışır
            Console.Write("v3.HareketEt -> "); v3.HareketEt(); // Köpek gibi çalışır

            Console.WriteLine("\n--- Notlar ---");
            /*
             FOTOĞRAFTAKİ DERS NOTU:
             v1, v2, v3 hepsi de Varlik referansı olmasına rağmen
             HareketEt fonksiyonu hepsinde farklı çalışıyor.
             Ata sınıf nesnesine aktarsak bile
             Kedi kediliğini, köpek köpekliğini koruyor.
             Çünkü çekirdeklerini (override ile) değiştirdik.
             Buna POLYMORPHISM (Çok Biçimlilik) denir.
            */
            Console.WriteLine("Çıktılar incelendiğinde nesnelerin özünü koruduğu görülür.");
            
            Console.ReadLine();
        }
    }
}
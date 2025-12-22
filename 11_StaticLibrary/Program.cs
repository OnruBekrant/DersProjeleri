using System;

namespace StaticLibrary
{
    class Kitap
    {
        public string Adi;
        public string Yazari;
        
        // Static Pool: Hafızada tek bir yerde tutulur (Paint çizimindeki oks=0 kutusu)
        public static int Oks = 0; 

        public void OduncVer()
        {
            Console.WriteLine($"{Adi} - {Yazari} künyeli kitap ödünç verildi.");
            // Her ödünç vermede ortak sayacı arttır
            Console.WriteLine($"Ödünç Kitap Sayısı: {++Oks}");
        }

        // Static metotlar sadece static değişkenlere (havuza) erişebilir
        public static void SM()
        {
            Oks = 5; // OK
            // Adi = "Test"; // HATA! Nesne olmadan isme erişilemez.
            Console.WriteLine("Static metot çalıştı. OKS güncellendi.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Stack'teki k1 referansı -> Heap'teki nesneyi gösterir
            Kitap k1 = new Kitap { Adi = "Suç ve Ceza", Yazari = "Dostoyevski" };
            
            // Stack'teki k2 referansı -> Heap'teki başka bir nesneyi gösterir
            Kitap k2 = new Kitap { Adi = "Şeker Portakalı", Yazari = "Vasconcelos" };

            // k1 ve k2 farklı nesneler olsa da AYNI static değişkeni (oks) kullanırlar.
            k1.OduncVer(); 
            k2.OduncVer(); 
            
            Kitap.SM(); // Static metoda sınıf adıyla erişilir.
            Console.ReadLine();
        }
    }
}
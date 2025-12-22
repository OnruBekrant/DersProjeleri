using System;

namespace EncapsulationProperties
{
    class Ogrenci
    {
        private int _yas;
        public int Yas
        {
            get { return _yas; }
            set {
                if (value < 0 || value > 150) Console.WriteLine("Hata: Geçersiz yaş!");
                else _yas = value;
            }
        }
        // Sadece okunabilir property
        public string OkulAdi { get { return "KTUN"; } }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Ogrenci o1 = new Ogrenci();
            o1.Yas = 200; // Hata verir
            o1.Yas = 25;  // Kabul eder
            Console.WriteLine($"Öğrenci Yaşı: {o1.Yas}, Okul: {o1.OkulAdi}");
        }
    }
}
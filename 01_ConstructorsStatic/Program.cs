using System;

namespace ConstructorsStatic
{
    class Zaman
    {
        int gun, ay, yil;
        static Zaman() { Console.WriteLine("[Zaman] Static Constructor (1 kez çalışır)."); }
        public Zaman() { gun = DateTime.Now.Day; ay = DateTime.Now.Month; yil = DateTime.Now.Year; }
        public Zaman(int g, int a, int y) { gun = g; ay = a; yil = y; }
        public void ZamaniYaz() { Console.WriteLine($"Tarih: {gun}-{ay}-{yil}"); }
    }

    class Kitap
    {
        public string Adi;
        public static int OduncSayaci = 0; 
        public void OduncVer() { OduncSayaci++; Console.WriteLine($"{Adi} ödünç verildi. Toplam: {OduncSayaci}"); }
        public void IadeEt() { OduncSayaci--; Console.WriteLine($"{Adi} iade edildi. Toplam: {OduncSayaci}"); }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Zaman z1 = new Zaman(5, 7, 2030);
            z1.ZamaniYaz();
            
            Kitap k1 = new Kitap { Adi = "Sefiller" };
            k1.OduncVer();
            Kitap k2 = new Kitap { Adi = "1984" };
            k2.OduncVer(); // Sayaç ortak artar
        }
    }
}
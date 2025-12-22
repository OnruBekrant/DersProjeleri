using System;

namespace IComparableSorting
{
    class Personel : IComparable
    {
        public int SicilNo;
        public string Ad, Soyad;

        public Personel(int sn, string a, string s) { SicilNo = sn; Ad = a; Soyad = s; }

        public void Yaz() { Console.WriteLine($"{SicilNo}: {Ad} {Soyad}"); }

        // Sıralama mantığını burada kuruyoruz (Sicil No'ya göre)
        public int CompareTo(object obj)
        {
            Personel diger = (Personel)obj;
            // Küçükten büyüğe sıralar. Büyükten küçüğe için yer değiştir.
            return this.SicilNo.CompareTo(diger.SicilNo); 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Basit Dizi Sıralama
            int[] sayilar = { 5, 1, 99, -5, 10 };
            Array.Sort(sayilar);
            Console.WriteLine($"En küçük sayı: {sayilar[0]}");

            // Personel Sıralama
            Personel[] ekip = {
                new Personel(105, "Ahmet", "Yılmaz"),
                new Personel(20, "Zeynep", "Kaya"), // En küçük sicil
                new Personel(300, "Mehmet", "Demir")
            };

            Console.WriteLine("\n--- Sıralamadan Önce ---");
            foreach(var p in ekip) p.Yaz();

            Array.Sort(ekip); // IComparable sayesinde çalışır

            Console.WriteLine("\n--- Sıralamadan Sonra ---");
            foreach(var p in ekip) p.Yaz();

            Console.ReadLine();
        }
    }
}
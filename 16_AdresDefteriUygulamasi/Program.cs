using System;
using System.Collections.Generic;

namespace AdresDefteriUygulamasi
{
    class Kisi
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Tel { get; set; }
        public override string ToString() { return $"{Ad} {Soyad} \t| Tel: {Tel}"; }
    }

    class AdresDefteri
    {
        List<Kisi> rehber = new List<Kisi>();

        public void Ekle(string ad, string soyad, string tel)
        {
            // UML: "Special Case: Kişi zaten var"
            if (rehber.Exists(k => k.Ad == ad && k.Soyad == soyad))
            {
                Console.WriteLine("HATA: Bu kişi zaten kayıtlı!");
                return;
            }
            rehber.Add(new Kisi { Ad = ad, Soyad = soyad, Tel = tel });
            Console.WriteLine("Kayıt Eklendi.");
        }

        public void Sil(string ad)
        {
            // UML: "Step: Ad ile aranır, bulunursa silinir"
            Kisi silinecek = rehber.Find(k => k.Ad == ad);
            if (silinecek != null)
            {
                rehber.Remove(silinecek);
                Console.WriteLine($"{ad} silindi.");
            }
            else Console.WriteLine("Kişi bulunamadı.");
        }

        public void Listele()
        {
            Console.WriteLine("\n--- REHBER ---");
            if(rehber.Count == 0) Console.WriteLine("Rehber Boş.");
            else rehber.ForEach(k => Console.WriteLine(k));
            Console.WriteLine("--------------");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AdresDefteri defter = new AdresDefteri();
            defter.Ekle("Ali", "Yılmaz", "0555");
            defter.Ekle("Ayşe", "Demir", "0544");
            defter.Ekle("Ali", "Yılmaz", "0555"); // Hata verecek
            
            defter.Listele();
            
            defter.Sil("Ali");
            defter.Listele();

            Console.ReadLine();
        }
    }
}
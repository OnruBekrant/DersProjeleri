using System;
using System.Collections.Generic;

namespace InterfaceSegregationOCP
{
    // Arayüz Ayrımı (Interface Segregation)
    interface ISesVerebilenler { void SesVer(); }
    interface IDansEdebilenler { void DansEt(); }

    // Sınıflar
    class Insan : ISesVerebilenler, IDansEdebilenler
    {
        public void SesVer() { Console.WriteLine("İnsan: Do re mi fa sol"); }
        public void DansEt() { Console.WriteLine("İnsan: Tango yapıyor"); }
    }

    class Kus : ISesVerebilenler
    {
        public void SesVer() { Console.WriteLine("Kuş: Cik cik cik"); }
    }

    class Robot : IDansEdebilenler
    {
        public void DansEt() { Console.WriteLine("Robot: Mekanik dans"); }
    }

    // Yöneticiler
    class Koro
    {
        List<ISesVerebilenler> sanatcilar = new List<ISesVerebilenler>();
        public void SanatciEkle(ISesVerebilenler s) { sanatcilar.Add(s); }
        public void KoroSoylesin() { 
            Console.WriteLine("\n--- KORO ---");
            sanatcilar.ForEach(s => s.SesVer()); 
        }
    }

    class DansToplulugu
    {
        List<IDansEdebilenler> danscilar = new List<IDansEdebilenler>();
        public void DansciEkle(IDansEdebilenler d) { danscilar.Add(d); }
        public void DansBaslasin() { 
            Console.WriteLine("\n--- DANS ---");
            danscilar.ForEach(d => d.DansEt()); 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Koro koro = new Koro();
            koro.SanatciEkle(new Insan());
            koro.SanatciEkle(new Kus());
            // koro.SanatciEkle(new Robot()); // HATA! Robot şarkı söyleyemez.

            DansToplulugu dt = new DansToplulugu();
            dt.DansciEkle(new Insan());
            dt.DansciEkle(new Robot());
            // dt.DansciEkle(new Kus()); // HATA! Kuş dans edemez.

            koro.KoroSoylesin();
            dt.DansBaslasin();
            
            Console.ReadLine();
        }
    }
}
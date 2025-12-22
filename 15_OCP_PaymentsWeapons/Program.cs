using System;
using System.Collections.Generic;

namespace OCP_PaymentsWeapons
{
    // --- 1. SENARYO: SİLAH SİSTEMİ (OCP) ---
    interface IAtesEdilebilir { void AtesEt(); }

    class Tabanca : IAtesEdilebilir { public void AtesEt() { Console.WriteLine("Tabanca: Bam Bam!"); } }
    class Kilic : IAtesEdilebilir { public void AtesEt() { Console.WriteLine("Kılıç: Şlak Şlak!"); } }
    class Topuz : IAtesEdilebilir { public void AtesEt() { Console.WriteLine("Topuz: Güm Güm!"); } }

    class Oyuncu
    {
        List<IAtesEdilebilir> silahlar = new List<IAtesEdilebilir>();
        public void SilahEkle(IAtesEdilebilir s) { silahlar.Add(s); }
        public void FullSaldiri() 
        { 
            Console.WriteLine("--- FULL SALDIRI ---");
            silahlar.ForEach(s => s.AtesEt()); 
        }
    }

    // --- 2. SENARYO: ÖDEME SİSTEMİ (OCP) ---
    interface IOdemeYontemi { void Ode(); }
    class KrediKarti : IOdemeYontemi { public void Ode() { Console.WriteLine("Kredi Kartı ile ödendi."); } }
    class Nakit : IOdemeYontemi { public void Ode() { Console.WriteLine("Nakit ödendi."); } }

    class Program
    {
        static void Main(string[] args)
        {
            // Silah Testi
            Oyuncu o = new Oyuncu();
            o.SilahEkle(new Tabanca());
            o.SilahEkle(new Kilic());
            o.FullSaldiri();

            Console.WriteLine();

            // Ödeme Testi
            IOdemeYontemi odeme1 = new KrediKarti();
            odeme1.Ode();

            Console.ReadLine();
        }
    }
}
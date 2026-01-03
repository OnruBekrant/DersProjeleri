using System;

namespace DecoratorRPGBuffs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- OYUN BAŞLIYOR ---");
            IKarakter oyuncu = new TemelKarakter("Savaşçı Ali", 50, 20);
            Raporla(oyuncu);

            Console.WriteLine("\n--- 1. Demir Zırh Giyiliyor... ---");
            oyuncu = new DemirZirh(oyuncu);
            Raporla(oyuncu);

            Console.WriteLine("\n--- 2. Öfke Büyüsü (Rage) Basılıyor... ---");
            oyuncu = new OfkeBuyusu(oyuncu);
            Raporla(oyuncu); 
            // Matematik: (50 + 0) * 1.5 = 75 Saldırı
            // Savunma: 20 + 30 = 50 Savunma
        }

        static void Raporla(IKarakter k)
        {
            Console.WriteLine($"Karakter: {k.Isim} | Atk: {k.SaldiriGucu} | Def: {k.SavunmaGucu}");
        }
    }

    // Component
    public interface IKarakter
    {
        string Isim { get; }
        int SaldiriGucu { get; }
        int SavunmaGucu { get; }
    }

    // Concrete Component
    public class TemelKarakter : IKarakter
    {
        public string Isim { get; private set; }
        private int _atk;
        private int _def;

        public TemelKarakter(string isim, int atk, int def)
        {
            Isim = isim;
            _atk = atk;
            _def = def;
        }

        public int SaldiriGucu => _atk;
        public int SavunmaGucu => _def;
    }

    // Abstract Decorator
    public abstract class KarakterDecorator : IKarakter
    {
        protected IKarakter _karakter;
        public KarakterDecorator(IKarakter k) { _karakter = k; }

        public virtual string Isim => _karakter.Isim;
        public virtual int SaldiriGucu => _karakter.SaldiriGucu;
        public virtual int SavunmaGucu => _karakter.SavunmaGucu;
    }

    // Concrete Decorator 1: Zırh (Savunma artırır)
    public class DemirZirh : KarakterDecorator
    {
        public DemirZirh(IKarakter k) : base(k) { }
        public override int SavunmaGucu => base.SavunmaGucu + 30;
    }

    // Concrete Decorator 2: Büyü (Saldırıyı katlar)
    public class OfkeBuyusu : KarakterDecorator
    {
        public OfkeBuyusu(IKarakter k) : base(k) { }
        public override int SaldiriGucu => (int)(base.SaldiriGucu * 1.5);
    }
}
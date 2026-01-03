using System;

namespace RPGOyunBuffSistemi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- OYUN BAŞLIYOR ---");
            IKarakter oyuncu = new TemelKarakter("Savaşçı Ali", 50, 20);
            DurumuRaporla(oyuncu);

            Console.WriteLine("\n--- Demir Zırh Giyiliyor... ---");
            oyuncu = new DemirZirh(oyuncu);
            DurumuRaporla(oyuncu);

            Console.WriteLine("\n--- Efsanevi Kılıç Alınıyor... ---");
            oyuncu = new KilicBuff(oyuncu);
            DurumuRaporla(oyuncu);

            Console.WriteLine("\n--- Öfke Büyüsü (Rage) Basılıyor... ---");
            oyuncu = new OfkeBuyusu(oyuncu);
            DurumuRaporla(oyuncu); // Burada matematik: (50+15) * 1.5 = 97 görmeliyiz.

            Console.WriteLine("\n--- Büyünün Etkisi Geçti (Buff Siliniyor)... ---");
            if (oyuncu is KarakterDecorator decorator)
            {
                oyuncu = decorator.TabanKarakter;
            }
            DurumuRaporla(oyuncu);
        }

        // YARDIMCI METOT: Karışıklığı önlemek için yazdırma işini buraya aldık.
        // Bu metot, en dıştaki "oyuncu" nesnesinin HESAPLANMIŞ son halini okur.
        static void DurumuRaporla(IKarakter k)
        {
            Console.WriteLine($"GÜNCEL DURUM => İsim: {k.Isim} | TOPLAM SALDIRI: {k.SaldiriGucu} | TOPLAM SAVUNMA: {k.SavunmaGucu}");
            Console.WriteLine("Aktif Etkiler:");
            k.EtkileriListele(); // Eski BilgileriGoster metodunun adını değiştirdik
            Console.WriteLine("--------------------------------------------------");
        }
    }

    public interface IKarakter
    {
        string Isim { get; }
        int SaldiriGucu { get; }
        int SavunmaGucu { get; }
        void EtkileriListele(); // İsim değişikliği: Amacı daha net olsun
    }

    public class TemelKarakter : IKarakter
    {
        private string _isim;
        private int _baseSaldiri;
        private int _baseSavunma;

        public TemelKarakter(string isim, int saldiri, int savunma)
        {
            _isim = isim;
            _baseSaldiri = saldiri;
            _baseSavunma = savunma;
        }

        public string Isim => _isim;
        public int SaldiriGucu => _baseSaldiri;
        public int SavunmaGucu => _baseSavunma;

        public void EtkileriListele()
        {
            // Temel karakter artık "Atk: 50" diye hava atmasın, sadece temel olduğunu belirtsin.
            Console.WriteLine($"  -> [Temel] {_isim} (Taban Atk: {_baseSaldiri}, Taban Def: {_baseSavunma})");
        }
    }

    public abstract class KarakterDecorator : IKarakter
    {
        protected IKarakter _karakter;
        public KarakterDecorator(IKarakter karakter) { _karakter = karakter; }
        public IKarakter TabanKarakter => _karakter;

        public virtual string Isim => _karakter.Isim;
        public virtual int SaldiriGucu => _karakter.SaldiriGucu;
        public virtual int SavunmaGucu => _karakter.SavunmaGucu;

        public virtual void EtkileriListele()
        {
            _karakter.EtkileriListele();
        }
    }

    public class DemirZirh : KarakterDecorator
    {
        public DemirZirh(IKarakter karakter) : base(karakter) { }

        public override int SavunmaGucu => base.SavunmaGucu + 30;

        public override void EtkileriListele()
        {
            base.EtkileriListele();
            Console.WriteLine("  -> [Ekipman] Demir Zırh (+30 Savunma)");
        }
    }

    public class KilicBuff : KarakterDecorator
    {
        public KilicBuff(IKarakter karakter) : base(karakter) { }

        public override int SaldiriGucu => base.SaldiriGucu + 15;

        public override void EtkileriListele()
        {
            base.EtkileriListele();
            Console.WriteLine("  -> [Ekipman] Efsanevi Kılıç (+15 Saldırı)");
        }
    }

    public class OfkeBuyusu : KarakterDecorator
    {
        public OfkeBuyusu(IKarakter karakter) : base(karakter) { }

        public override int SaldiriGucu => (int)(base.SaldiriGucu * 1.5);

        public override void EtkileriListele()
        {
            base.EtkileriListele();
            Console.WriteLine("  -> [Büyü] Öfke Büyüsü (Saldırı x 1.5)");
        }
    }
}
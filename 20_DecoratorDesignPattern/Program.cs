using System;

namespace DecoratorDesignPattern
{
    // 1. Component (Temel Sınıf)
    class Silah
    {
        public virtual void AtesEt()
        {
            Console.WriteLine("Basit Silah: Pat Pat!");
        }
    }

    // 2. Decorator (Süsleyici Baz Sınıf)
    class Decorator : Silah
    {
        protected Silah _temelSilah;

        // Hangi silahı geliştireceğimizi buraya alıyoruz
        public void BilesenEkle(Silah silah)
        {
            _temelSilah = silah;
        }

        public override void AtesEt()
        {
            if (_temelSilah != null)
            {
                _temelSilah.AtesEt(); // Önce eski silahın özelliğini çalıştır
            }
        }
    }

    // 3. Concrete Decorators (Somut Süsleyiciler)
    class LazerSilah : Decorator
    {
        public override void AtesEt()
        {
            base.AtesEt(); // Önceki özellikleri koru
            Console.WriteLine(" + Lazer Eklentisi: Ciuuu Ciuuu!");
        }
    }

    class TurboSilah : Decorator
    {
        public override void AtesEt()
        {
            base.AtesEt(); // Önceki özellikleri koru
            Console.WriteLine(" + Turbo Mod: Ratatatata!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- 1. Basit Silah ---");
            Silah s = new Silah();
            s.AtesEt();

            Console.WriteLine("\n--- 2. Lazer Takılmış Silah ---");
            LazerSilah lazerli = new LazerSilah();
            lazerli.BilesenEkle(s); // Basit silaha lazer taktık
            lazerli.AtesEt();

            Console.WriteLine("\n--- 3. Turbo + Lazerli Silah ---");
            TurboSilah fullMod = new TurboSilah();
            fullMod.BilesenEkle(lazerli); // Lazerli silaha turbo taktık
            fullMod.AtesEt();
        }
    }
}
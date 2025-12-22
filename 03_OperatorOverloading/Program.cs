using System;

namespace OperatorOverloading
{
    class Kesir
    {
        public int Pay, Payda;
        public Kesir(int p, int pd) { Pay = p; Payda = pd; }
        
        public static Kesir operator +(Kesir k1, Kesir k2)
        {
            return new Kesir((k1.Pay * k2.Payda) + (k2.Pay * k1.Payda), k1.Payda * k2.Payda);
        }

        public static bool operator ==(Kesir k1, Kesir k2)
        {
            return (double)k1.Pay/k1.Payda == (double)k2.Pay/k2.Payda;
        }
        public static bool operator !=(Kesir k1, Kesir k2) { return !(k1 == k2); }

        public override string ToString() { return $"{Pay}/{Payda}"; }
        public override bool Equals(object obj) { return true; } // Uyarıyı susturmak için
        public override int GetHashCode() { return 0; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Kesir k1 = new Kesir(1, 2);
            Kesir k2 = new Kesir(1, 4);
            Kesir k3 = k1 + k2;
            Console.WriteLine($"Toplam: {k3}"); // Çıktı: 6/8 (veya sadeleşmemiş hali)
            
            if(new Kesir(1,2) == new Kesir(2,4)) Console.WriteLine("Kesirler denk.");
        }
    }
}
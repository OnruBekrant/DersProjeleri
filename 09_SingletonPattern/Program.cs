using System;

namespace SingletonPattern
{
    class Tekil
    {
        private static Tekil _nesne;
        private Tekil() { Console.WriteLine("Nesne oluşturuldu."); } // Private Constructor

        public static Tekil NesneVer()
        {
            if (_nesne == null) _nesne = new Tekil();
            return _nesne;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Tekil t1 = Tekil.NesneVer();
            Tekil t2 = Tekil.NesneVer(); // İkinci kez "Nesne oluşturuldu" yazmaz.
            
            if(t1 == t2) Console.WriteLine("İkisi de aynı referans.");
        }
    }
}
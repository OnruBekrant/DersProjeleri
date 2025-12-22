using System;

namespace Generics
{
    class Depo<T>
    {
        T[] veriler = new T[10];
        int sayac = 0;
        public void Ekle(T veri) { veriler[sayac++] = veri; }
        public T Getir(int index) { return veriler[index]; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Depo<string> isimler = new Depo<string>();
            isimler.Ekle("Ahmet");
            Console.WriteLine(isimler.Getir(0));

            Depo<int> sayilar = new Depo<int>();
            sayilar.Ekle(1923);
            Console.WriteLine(sayilar.Getir(0));
        }
    }
}
using System;

namespace FactoryDesignPattern
{
    // 1. Ürün Arayüzü (Interface)
    interface IPizza
    {
        void MalzemeleriHazirla();
        void HamurHazirla();
        void DecoreEt();
        void Pisir();
    }

    // 2. Somut Ürünler
    class KarisikPizza : IPizza
    {
        public void MalzemeleriHazirla() { Console.WriteLine("Karışık malzeme hazırlanıyor..."); }
        public void HamurHazirla() { Console.WriteLine("İnce hamur açılıyor..."); }
        public void DecoreEt() { Console.WriteLine("Sucuk, salam, mantar ekleniyor..."); }
        public void Pisir() { Console.WriteLine("200 derecede pişiriliyor."); }
    }

    class VejeteryanPizza : IPizza
    {
        public void MalzemeleriHazirla() { Console.WriteLine("Sebzeler yıkanıyor..."); }
        public void HamurHazirla() { Console.WriteLine("Tam buğday hamuru açılıyor..."); }
        public void DecoreEt() { Console.WriteLine("Mısır, biber, zeytin ekleniyor..."); }
        public void Pisir() { Console.WriteLine("180 derecede pişiriliyor."); }
    }

    // 3. Fabrika Arayüzü (Factory Interface)
    interface IPizzaFabrikasi
    {
        IPizza PizzaUret(); // Factory Method
    }

    // 4. Somut Fabrikalar (Hangi fabrikayı seçersen o pizzayı üretir)
    class KarisikPizzaFabrikasi : IPizzaFabrikasi
    {
        public IPizza PizzaUret() { return new KarisikPizza(); }
    }

    class VeggiePizzaFabrikasi : IPizzaFabrikasi
    {
        public IPizza PizzaUret() { return new VejeteryanPizza(); }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- SİPARİŞ 1: Karışık ---");
            IPizzaFabrikasi fabrika1 = new KarisikPizzaFabrikasi();
            IPizza p1 = fabrika1.PizzaUret();
            p1.MalzemeleriHazirla();
            p1.Pisir();

            Console.WriteLine("\n--- SİPARİŞ 2: Vejeteryan ---");
            IPizzaFabrikasi fabrika2 = new VeggiePizzaFabrikasi();
            IPizza p2 = fabrika2.PizzaUret();
            p2.MalzemeleriHazirla();
            p2.Pisir();
        }
    }
}
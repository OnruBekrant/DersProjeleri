using System;

namespace StrategyDesignPattern
{
    // 1. Strateji Arayüzü
    interface ISortStrategy
    {
        void Sirala();
    }

    // 2. Somut Stratejiler (Algoritmalar)
    class BubbleSort : ISortStrategy
    {
        public void Sirala() { Console.WriteLine("Bubble Sort (Baloncuk) ile sıralandı."); }
    }

    class QuickSort : ISortStrategy
    {
        public void Sirala() { Console.WriteLine("Quick Sort (Hızlı) ile sıralandı."); }
    }

    class MergeSort : ISortStrategy
    {
        public void Sirala() { Console.WriteLine("Merge Sort (Birleştirmeli) ile sıralandı."); }
    }

    class SelectionSort : ISortStrategy
    {
        public void Sirala() { Console.WriteLine("Selection Sort (Seçmeli) ile sıralandı."); }
    }

    // 3. Context (Bağlam) - Stratejiyi Kullanan Sınıf
    class SiralamaIslemi
    {
        private ISortStrategy _strateji;

        // Constructor'da hangi stratejiyi kullanacağımızı seçiyoruz
        public SiralamaIslemi(ISortStrategy strateji)
        {
            _strateji = strateji;
        }

        public void IslemYap()
        {
            Console.Write("Çalışan Algoritma: ");
            _strateji.Sirala();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // İstemci (Client) istediği algoritmayı seçip gönderir
            SiralamaIslemi siralama;

            siralama = new SiralamaIslemi(new BubbleSort());
            siralama.IslemYap();

            siralama = new SiralamaIslemi(new QuickSort());
            siralama.IslemYap();

            siralama = new SiralamaIslemi(new SelectionSort());
            siralama.IslemYap();
        }
    }
}
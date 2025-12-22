using System;

namespace TypeConversions
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Explicit (Açık) Dönüşüm
            // PDF Notu: "Hata alırız double'ı int'e atamak için explicit dönüşüm yaparız."
            double d = 5.4;
            int a = (int)d; // Veri kaybı olur (0.4 gider)
            Console.WriteLine($"Double ({d}) -> Int ({a})");

            // 2. Implicit (Kapalı) Dönüşüm
            short s = 100;
            int b = s; // Sorunsuz, otomatik
            Console.WriteLine($"Short ({s}) -> Int ({b})");

            Console.ReadLine();
        }
    }
}
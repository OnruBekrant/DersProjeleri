using System;

namespace Banka
{
    class BankaHesabi
    {
        public string SahipAdi//property
        {
            get;
            set;
        }
        public decimal Bakiye//property
        {
            get;
            private set;//sadece okunabilir
        }
        public static int ToplamHesapSayisi = 0;//static field ın amacı tüm banka hesaplarının sayısını tutmaktır.
        public static decimal ToplamMevduat = 0;//static field biz bu static fieldları kullanarak tüm banka hesaplarının toplam bakiyesini ve sayısını tutabiliriz.

        public BankaHesabi(string sahipAdi, decimal BaslangicBakiyesi)//constructor
        {
            SahipAdi = sahipAdi;
            if (BaslangicBakiyesi < 0)
            {
                Console.WriteLine("Hata: Başlangıç bakiyesi negatif olamaz!");
                BaslangicBakiyesi = 0;
            }
            Bakiye = BaslangicBakiyesi;
            ToplamHesapSayisi++;//her yeni hesap açıldığında sayacı artır
            ToplamMevduat += Bakiye;//toplam mevduata ekle
        }
        public void ParaYatir(decimal miktar)
        {
            if (miktar <= 0)
            {
                System.Console.WriteLine("Hata: Yatırılacak miktar pozitif olmalıdır!");
                return;
            }
            Bakiye += miktar;   //bakiye güncelle
            ToplamMevduat += miktar;    //toplam mevduatı güncelle
            return;
        }
        public void ParaÇek(decimal miktar)
        {
            if (miktar <= 0)
            {
                System.Console.WriteLine("Hata: Çekilecek miktar pozitif olmalıdır!");
                return;
            }
            else if (miktar > Bakiye)
            {
                System.Console.WriteLine("Hata: Yetersiz bakiye!");
                return;
            }
            Bakiye -= miktar;   //bakiye güncelle
            ToplamMevduat -= miktar;    //toplam mevduatı güncelle
            return;
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            BankaHesabi hesap1 = new BankaHesabi("Ali Veli", 1000);
            BankaHesabi hesap2 = new BankaHesabi("Ayşe Fatma", 500);
            hesap1.ParaYatir(250);
            System.Console.WriteLine($"Toplam Hesap Sayısı: {BankaHesabi.ToplamHesapSayisi}");
            System.Console.WriteLine($"Bankadaki Toplam Mevduat: {BankaHesabi.ToplamMevduat}");
        }
    }
}
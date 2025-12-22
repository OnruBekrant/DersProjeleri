namespace Calisma_02_Sirket;

class Calisan
{
    protected int SirketButcesi = 10000;
    //properties
    public string Ad
    {
        get; set;
    }
    public string Soyad
    {
        get; set;
    }
    public decimal Maas
    {
        get; set;
    }
    public Calisan(string ad, string soyad, decimal maas)//constructor
    {
        Ad = ad;
        Soyad = soyad;
        Maas = maas;
    }
    public virtual decimal MaasHesapla()
    {
        return Maas;
    }
}
class Yazilimci:Calisan
{
    public Yazilimci(string ad, string soyad, decimal maas, string dil) : base(ad, soyad, maas)//constructor, ata sınıfın constructor'ını çağırır.
    {
        YazilimDili = dil;
    }
    public string YazilimDili { get; set; }//property
    public override decimal MaasHesapla()
    {
        return base.MaasHesapla() + 5000;
    }
}
class Yonetici:Calisan
{
    public Yonetici(string ad, string soyad, decimal maas) : base(ad, soyad, maas)//constructor, ata sınıfın constructor'ını çağırır.
    {

    }
    public override decimal MaasHesapla()
    {
        return base.MaasHesapla() + (SirketButcesi * 10 / 100);
    }
}
class Program
{
    static void Main(string[] args)
    {
        Yazilimci y1 = new Yazilimci("Ahmet", "Yilmaz", 8000, "C#");
        Yonetici m1 = new Yonetici("Mehmet", "Demir", 12000);
        Calisan c1 = y1;
        Calisan c2 = m1;
        Console.WriteLine($"{c1.Ad} {c1.Soyad} (Yazılımcı) Maaş: " + c1.MaasHesapla());
        Console.WriteLine($"{c2.Ad} {c2.Soyad} (Yönetici) Maaş: " + c2.MaasHesapla());

    }
}

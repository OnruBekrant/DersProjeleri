namespace OyunFarkliDamageSistemleri;

class Program
{
    static void Main(string[] args)
    {
        // Örnek 1: Varsayılan (Fiziksel) Hasar Adaptörü
        // İkinci parametreyi vermediğimiz için varsayılan olarak "Physical" kullanır.
        IDamageable swordAttack = new DamageAdapter(new ThirdPartyDamageService());
        Console.WriteLine("--- Kılıç Saldırısı ---");
        swordAttack.TakeDamage(50);

        // Örnek 2: Ateş Hasarı Adaptörü (BONUS ÖZELLİK)
        // Aynı sınıfı kullanarak, sadece parametre değiştirerek farklı bir davranış elde ettik.
        IDamageable fireBall = new DamageAdapter(new ThirdPartyDamageService(), "Fire");
        Console.WriteLine("\n--- Ateş Topu Saldırısı ---");
        fireBall.TakeDamage(100);
        
        // Örnek 3: Zehir Hasarı Adaptörü
        IDamageable poisonTrap = new DamageAdapter(new ThirdPartyDamageService(), "Poison");
        Console.WriteLine("\n--- Zehir Tuzağı ---");
        poisonTrap.TakeDamage(10);
    }
}

// ---------------------------------------------------------
// 1. Target (Hedef)
// Oyun motorunun (istemcinin) beklediği standart arayüz.
// ---------------------------------------------------------
public interface IDamageable
{
    void TakeDamage(int damage);
}

// ---------------------------------------------------------
// 2. Adaptee (Adapte Edilen)
// Değiştiremediğimiz, uyumsuz imzaya sahip harici servis.
// ---------------------------------------------------------
public class ThirdPartyDamageService
{
    public void ApplyHit(float power, string damageType)
    {
        Console.WriteLine($"[ThirdParty Log] -> {power} gücünde '{damageType}' hasarı işlendi.");
    }
}

// ---------------------------------------------------------
// 3. Adapter (Adaptör)
// İki uyumsuz yapıyı birbirine bağlayan köprü.
// ---------------------------------------------------------
public class DamageAdapter : IDamageable
{
    private readonly ThirdPartyDamageService _legacyService;
    private readonly string _damageType; // BONUS: Esneklik sağlayan alan

    // Constructor Injection:
    // Hem servisi hem de bu adaptörün hangi tür hasar vuracağını alıyoruz.
    // 'damageType' için varsayılan değer "Physical" olarak ayarlandı.
    public DamageAdapter(ThirdPartyDamageService legacyService, string damageType = "Physical")
    {
        _legacyService = legacyService;
        _damageType = damageType;
    }

    // Oyun motoru sadece int gönderir, gerisini adaptör halleder.
    public void TakeDamage(int damage)
    {
        // 1. Veri Dönüşümü (int -> float)
        float power = (float)damage;

        // 2. Eksik Parametre Tamamlama
        // Constructor'dan gelen _damageType'ı kullanıyoruz.
        _legacyService.ApplyHit(power, _damageType);
    }
}
using System;

namespace AdapterGameIntegration
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Varsayılan (Fiziksel) Hasar
            IDamageable sword = new DamageAdapter(new ThirdPartyDamageService());
            Console.WriteLine("--- Kılıç Vuruşu ---");
            sword.TakeDamage(50);

            // 2. Özel Tür (Ateş) Hasarı - Adapter Constructor ile esneklik sağladık
            IDamageable fireBall = new DamageAdapter(new ThirdPartyDamageService(), "Fire");
            Console.WriteLine("\n--- Ateş Topu ---");
            fireBall.TakeDamage(100);
        }
    }

    // 1. Target (Bizim Oyun Motorumuzun Anladığı Dil)
    public interface IDamageable
    {
        void TakeDamage(int damage);
    }

    // 2. Adaptee (Uyumsuz Dış Servis - Değiştiremeyiz)
    public class ThirdPartyDamageService
    {
        public void ApplyHit(float power, string damageType)
        {
            Console.WriteLine($"[3. Parti Servis] -> {power} gücünde '{damageType}' hasarı işlendi.");
        }
    }

    // 3. Adapter (Çevirici)
    public class DamageAdapter : IDamageable
    {
        private readonly ThirdPartyDamageService _service;
        private readonly string _damageType;

        // Varsayılan olarak "Physical" hasar tipi atadık
        public DamageAdapter(ThirdPartyDamageService service, string damageType = "Physical")
        {
            _service = service;
            _damageType = damageType;
        }

        public void TakeDamage(int damage)
        {
            // int -> float dönüşümü ve eksik parametrenin (_damageType) tamamlanması
            _service.ApplyHit((float)damage, _damageType);
        }
    }
}
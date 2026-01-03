namespace RPGOyunuSaldiri;

class Program
{
    static void Main(string[] args)
    {
        // Oyun karakteri başlangıçta yakın dövüş saldırısı yapıyor
        GameCharacter hero = new GameCharacter(new MeleeAttack());
        hero.PerformAttack();

        // Oyun sırasında stratejiyi okçuluk saldırısına değiştir
        hero.SetStrategy(new BowAttack());
        hero.PerformAttack();

        // Sonra büyü saldırısına geçiş yap
        hero.SetStrategy(new MagicAttack());
        hero.PerformAttack();
    }
}
// 1. Strateji Arayüzü (Strategy Interface)
// Tüm saldırı tipleri bu ortak imzayı kullanmak zorundadır.
public interface IAttackStrategy
{
    void Attack();
}

// 2. Somut Stratejiler (Concrete Strategies)

// Yakın Dövüş Davranışı
public class MeleeAttack : IAttackStrategy
{
    public void Attack()
    {
        Console.WriteLine("Kılıçla yakından vurdu! (Hasar: 10)");
    }
}

// Okçuluk Davranışı
public class BowAttack : IAttackStrategy
{
    public void Attack()
    {
        Console.WriteLine("Uzaktan ok fırlattı! (Hasar: 5)");
    }
}

// Büyü Davranışı
public class MagicAttack : IAttackStrategy
{
    public void Attack()
    {
        Console.WriteLine("Ateş topu büyüsü attı! (Alan Hasarı: 20)");
    }
}

// 3. Bağlam (Context) - Oyun Karakteri
public class GameCharacter
{
    // Karakter bir saldırı stratejisine "sahiptir" (Has-a relationship)
    private IAttackStrategy _attackStrategy;

    // Başlangıç stratejisi (örn: Yumruk/Melee)
    public GameCharacter(IAttackStrategy initialStrategy)
    {
        _attackStrategy = initialStrategy;
    }

    // Oyun sırasında stratejiyi değiştirme metodu (Runtime change)
    public void SetStrategy(IAttackStrategy newStrategy)
    {
        _attackStrategy = newStrategy;
    }

    public void PerformAttack()
    {
        // Karakter saldırının nasıl yapıldığını bilmez, stratejiye devreder.
        _attackStrategy.Attack();
    }
}
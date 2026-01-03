using System;

namespace StrategyRPGCombat
{
    class Program
    {
        static void Main(string[] args)
        {
            // Karakter doğarken Yumrukçu olarak doğuyor
            GameCharacter hero = new GameCharacter(new MeleeAttack());
            hero.PerformAttack();

            // Savaş sırasında okunu çekiyor (Runtime değişimi)
            Console.WriteLine("\n--> Silah değiştiriliyor: YAY");
            hero.SetStrategy(new BowAttack());
            hero.PerformAttack();

            // Savaş kızışıyor, büyü yapıyor
            Console.WriteLine("\n--> Silah değiştiriliyor: ASA");
            hero.SetStrategy(new MagicAttack());
            hero.PerformAttack();
        }
    }

    // 1. Strategy Interface
    public interface IAttackStrategy
    {
        void Attack();
    }

    // 2. Concrete Strategies
    public class MeleeAttack : IAttackStrategy
    {
        public void Attack() { Console.WriteLine("YUMRUK: Yakından 10 hasar vurdu!"); }
    }

    public class BowAttack : IAttackStrategy
    {
        public void Attack() { Console.WriteLine("OKÇULUK: Uzaktan 5 hasar vurdu!"); }
    }

    public class MagicAttack : IAttackStrategy
    {
        public void Attack() { Console.WriteLine("BÜYÜ: Alan etkili 20 hasar vurdu!"); }
    }

    // 3. Context (Karakter)
    public class GameCharacter
    {
        private IAttackStrategy _strategy;

        public GameCharacter(IAttackStrategy initialStrategy)
        {
            _strategy = initialStrategy;
        }

        // Stratejiyi değiştiren metot (Kritik nokta burası)
        public void SetStrategy(IAttackStrategy newStrategy)
        {
            _strategy = newStrategy;
        }

        public void PerformAttack()
        {
            _strategy.Attack();
        }
    }
}
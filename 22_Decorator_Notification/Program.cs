using System;

namespace DecoratorNotification
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Senaryo 1: Sadece Email ---");
            IBildirim bildirim = new TemelBildirim();
            bildirim = new EmailDecorator(bildirim);
            Console.WriteLine(bildirim.Gonder("Sistem Hatası!"));

            Console.WriteLine("\n--- Senaryo 2: Email + SMS + Push (Hepsi Bir Arada) ---");
            // Zincirleme (Chaining) yapıyoruz
            IBildirim fullBildirim = new PushNotificationDecorator(
                                        new SMSDecorator(
                                            new EmailDecorator(
                                                new TemelBildirim())));
            
            Console.WriteLine(fullBildirim.Gonder("Kritik Uyarı!"));
        }
    }

    // 1. Arayüz (Component)
    public interface IBildirim
    {
        string Gonder(string mesaj);
    }

    // 2. Temel Bileşen (Concrete Component)
    public class TemelBildirim : IBildirim
    {
        public string Gonder(string mesaj)
        {
            return $"Mesaj İçeriği: '{mesaj}'";
        }
    }

    // 3. Temel Decorator (Abstract Decorator)
    public abstract class BildirimDecorator : IBildirim
    {
        protected IBildirim _bildirim;

        public BildirimDecorator(IBildirim bildirim)
        {
            _bildirim = bildirim;
        }

        public virtual string Gonder(string mesaj)
        {
            return _bildirim.Gonder(mesaj);
        }
    }

    // 4. Somut Decorator'lar (Concrete Decorators)
    public class EmailDecorator : BildirimDecorator
    {
        public EmailDecorator(IBildirim bildirim) : base(bildirim) { }

        public override string Gonder(string mesaj)
        {
            return base.Gonder(mesaj) + " | --> Email Gönderildi";
        }
    }

    public class SMSDecorator : BildirimDecorator
    {
        public SMSDecorator(IBildirim bildirim) : base(bildirim) { }

        public override string Gonder(string mesaj)
        {
            return base.Gonder(mesaj) + " | --> SMS Gönderildi";
        }
    }

    public class PushNotificationDecorator : BildirimDecorator
    {
        public PushNotificationDecorator(IBildirim bildirim) : base(bildirim) { }

        public override string Gonder(string mesaj)
        {
            return base.Gonder(mesaj) + " | --> Push Notification Gönderildi";
        }
    }
}
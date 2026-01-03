class Program
    {
        static void Main(string[] args)
        {
            // 1. En sade hali (Çekirdek bileşen)
            IBildirim bildirim = new TemelBildirim();

            // 2. Özellikleri dinamik olarak ekliyoruz (Runtime)
            // İstersek sadece Email ve Push yapabiliriz, SMS'i atlayabiliriz.
            bildirim = new EmailDecorator(bildirim);
            bildirim = new SMSDecorator(bildirim);
            bildirim = new PushNotificationDecorator(bildirim);

            // Zincirleme çalıştırma
            string sonuc = bildirim.Gonder("Sistem uyarısı!");
            Console.WriteLine(sonuc);

            IBildirim digerBildirim = new TemelBildirim();
            digerBildirim = new EmailDecorator(digerBildirim);
            digerBildirim = new SMSDecorator(digerBildirim);
            string digerSonuc = digerBildirim.Gonder("Başka bir uyarı!");
            Console.WriteLine(digerSonuc);
        }
    }

    // 1. SOYUTLAMA (Interface)
    public interface IBildirim
    {
        string Gonder(string mesaj);
    }

    // 2. TEMEL BİLEŞEN (Concrete Component)
    // Bu, zincirin en temel halkasıdır.
    public class TemelBildirim : IBildirim
    {
        public string Gonder(string mesaj)
        {
            return mesaj; // Veya loglama yapabilir, veritabanına kayıt atabilir.
        }
    }

    // 3. TEMEL DECORATOR (Abstract Decorator)
    // Diğer tüm dekoratörler buradan türeyecek.
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

    // 4. SOMUT DECORATOR'LAR (Concrete Decorators)
    public class EmailDecorator : BildirimDecorator
    {
        public EmailDecorator(IBildirim bildirim) : base(bildirim) { }

        public override string Gonder(string mesaj)
        {
            // Önce temel işi yap, sonra kendi işini ekle
            return base.Gonder(mesaj) + " -> Email Gönderildi";
        }
    }

    public class SMSDecorator : BildirimDecorator
    {
        public SMSDecorator(IBildirim bildirim) : base(bildirim) { }

        public override string Gonder(string mesaj)
        {
            return base.Gonder(mesaj) + " -> SMS Gönderildi";
        }
    }

    public class PushNotificationDecorator : BildirimDecorator
    {
        public PushNotificationDecorator(IBildirim bildirim) : base(bildirim) { }

        public override string Gonder(string mesaj)
        {
            return base.Gonder(mesaj) + " -> Push Notification Gönderildi";
        }
    }
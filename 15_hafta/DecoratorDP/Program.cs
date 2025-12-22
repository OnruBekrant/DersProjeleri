namespace DecoratorDP;

class Program
{
    static void Main(string[] args)
    {
        Silah silah = new Silah();

        LazerSilah lazerSilah = new LazerSilah();
        lazerSilah.BilesenEkle(silah);

        TurboSilah turboLazerSilah = new TurboSilah();
        turboLazerSilah.BilesenEkle(lazerSilah);

        turboLazerSilah.atesEt();
    }
}
class Silah
{
    public virtual void atesEt()
    {
        Console.WriteLine("Basit Silah ateş etti.");
    }
}
class Decorator:Silah
{
    protected Silah? temelSilah;
    public void BilesenEkle(Silah bilesen)
    {
        temelSilah = bilesen;
    }
    public override void atesEt()
    {
        if (temelSilah != null)
        {
            //base.atesEt();
            temelSilah?.atesEt();
        }
    }
}
class LazerSilah : Decorator
{
    public override void atesEt()
    {
        base.atesEt();
        Console.WriteLine("Lazer Silah ateş etti.");
    }
}
class TurboSilah : Decorator
{
    public override void atesEt()
    {
        base.atesEt();
        Console.WriteLine("TurboSilah ateş etti.");
    }
}
namespace AdapterDP;

class Program
{
    static void Main(string[] args)
    {
        Onceki o = new Adapter();
        o.sarjEt(8);
    }
}
class AdapteEdilen//adaptörün adapte ettiği sınıf
{
    public void calistir(int a, int b)
    {
        Console.WriteLine("AdapteEdilen MethodA çalıştı.");
    }
}
class Onceki//değiştirmek istediğimiz sınıf
{
    public virtual void sarjEt(int a)
    {
        Console.WriteLine("Onceki SarjEt çalıştı.");
    }
}
class Adapter:Onceki//adaptör sınıfı
{
    public override void sarjEt(int a)
    {
        AdapteEdilen adapteEdilen = new AdapteEdilen();
        adapteEdilen.calistir(a, 0);
    }
}
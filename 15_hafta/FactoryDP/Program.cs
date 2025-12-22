namespace FactoryDP;

class Program
{
    static void Main(string[] args)
    {
        PizzaDukkani dukkan = new PizzaDukkani();
        IPizza p = new KarisikPizza();
        dukkan.Uret(p);
        IPizza p2 = new VegeteryanPizza();
        dukkan.Uret(p2);
    }
}
interface IPizza
{
    void malzemeleriHazirla()
    {
        
    }
    void hamurHazirla()
    {
        
    }
    void decoreEt()
    {
        
    }
    void pisir()
    {
        
    }
}
class VegeteryanPizza:IPizza
{   
    void malzemeleriHazirla()
    {
        Console.WriteLine("Vegeteryan Pizza Malzemeleri Hazirlaniyor...");
    }
    void hamurHazirla()
    {
        Console.WriteLine("Vegeteryan Pizza Hamuru Hazirlaniyor...");
    }
    void decoreEt()
    {
        Console.WriteLine("Vegeteryan Pizza Decore Ediliyor...");
    }
    void pisir()
    {
        Console.WriteLine("Vegeteryan Pizza Pisiriliyor...");
    }

}
class KarisikPizza:IPizza
{
    void malzemeleriHazirla()
    {
        Console.WriteLine("Karisik Pizza Malzemeleri Hazirlaniyor...");
    }
    void hamurHazirla()
    {
        Console.WriteLine("Karisik Pizza Hamuru Hazirlaniyor...");
    }
    void decoreEt()
    {
        Console.WriteLine("Karisik Pizza Decore Ediliyor...");
    }
    void pisir()
    {
        Console.WriteLine("Karisik Pizza Pisiriliyor...");
    }
}
class PizzaDukkani
{
    public void Uret(IPizza pizza)
    {
        pizza.malzemeleriHazirla();
        pizza.hamurHazirla();
        pizza.decoreEt();
        pizza.pisir();
    }
}

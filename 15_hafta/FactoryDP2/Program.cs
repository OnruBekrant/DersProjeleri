namespace FactoryDP2;

class Program
{
    static void Main(string[] args)
    {
        IPizzaFactory pizzaFactory = new KarisikPizzaFactory();
        IPizza pizza = pizzaFactory.PizzaUret();
        pizza.MalzemeleriHazirla();
        pizza.Hazirla();
        pizza.DecoreEt();
        pizza.Pisme();

        Console.WriteLine();

        pizzaFactory = new VegeteryanPizzaFactory();
        pizza = pizzaFactory.PizzaUret();
        pizza.MalzemeleriHazirla();
        pizza.Hazirla();
        pizza.DecoreEt();
        pizza.Pisme();
    }
}
interface IPizza
{
    void MalzemeleriHazirla();
    void Hazirla();
    void DecoreEt();
    void Pisme();
}
class KarisikPizza : IPizza
{
    public void MalzemeleriHazirla()
    {
        Console.WriteLine("Klasik pizza malzemeleri hazırlanıyor...");
    }

    public void Hazirla()
    {
        Console.WriteLine("Klasik pizza hazırlanıyor...");
    }

    public void DecoreEt()
    {
        Console.WriteLine("Klasik pizza dekore ediliyor...");
    }

    public void Pisme()
    {
        Console.WriteLine("Klasik pizza pişiriliyor...");
    }
}
class VegeteryanPizza:IPizza
{
    public void MalzemeleriHazirla()
    {
        Console.WriteLine("Vejeteryan pizza malzemeleri hazırlanıyor...");
    }

    public void Hazirla()
    {
        Console.WriteLine("Vejeteryan pizza hazırlanıyor...");
    }

    public void DecoreEt()
    {
        Console.WriteLine("Vejeteryan pizza dekore ediliyor...");
    }

    public void Pisme()
    {
        Console.WriteLine("Vejeteryan pizza pişiriliyor...");
    }   
}
interface IPizzaFactory
{
    IPizza PizzaUret();
}
class KarisikPizzaFactory : IPizzaFactory
{
    public IPizza PizzaUret()
    {
        return new KarisikPizza();
    }
}
class VegeteryanPizzaFactory : IPizzaFactory
{
    public IPizza PizzaUret()
    {
        return new VegeteryanPizza();
    }
}
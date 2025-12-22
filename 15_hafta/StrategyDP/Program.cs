namespace StrategyDP;

class Program
{
    static void Main(string[] args)
    {
        Siralama siralama;

        siralama = new Siralama(new BubbleSort());
        siralama.islem();

        siralama = new Siralama(new QuickSort());
        siralama.islem();

        siralama = new Siralama(new MergeSort());
        siralama.islem();

        siralama = new Siralama(new SelectionSort());
        siralama.islem();
    }
}
interface ISortStrategy
{
    void Sirala();
}
class BubbleSort : ISortStrategy
{
    public void Sirala()
    {
        Console.WriteLine("Bubble Sort ile sıralandı.");
    }
}
class QuickSort : ISortStrategy
{
    public void Sirala()
    {
        Console.WriteLine("Quick Sort ile sıralandı.");
    }
}
class MergeSort : ISortStrategy
{
    public void Sirala()
    {
        Console.WriteLine("Merge Sort ile sıralandı.");
    }
}
class SelectionSort : ISortStrategy
{
    public void Sirala()
    {
        Console.WriteLine("Selection Sort ile sıralandı.");
    }
}
class Siralama
{
    private ISortStrategy _sortStrategy;

    public Siralama(ISortStrategy sortStrategy)//constructor
    {
        _sortStrategy = sortStrategy;
    }
    public void islem()
    {
        _sortStrategy.Sirala();
    }
}
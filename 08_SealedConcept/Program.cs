using System;

namespace SealedConcept
{
    class A { public virtual void Yaz() { Console.WriteLine("A"); } }
    class B : A { public sealed override void Yaz() { Console.WriteLine("B (Mühürlü)"); } }
    class C : B 
    { 
        // public override void Yaz() { } // HATA! B'de mühürlendiği için ezilemez.
        public new void Yaz() { Console.WriteLine("C (Yeni metod)"); } 
    }

    class Program
    {
        static void Main(string[] args)
        {
            new C().Yaz();
        }
    }
}
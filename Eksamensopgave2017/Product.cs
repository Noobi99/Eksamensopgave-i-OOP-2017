using System.Threading;

namespace Eksamensopgave2017
{
    public class Product
    {
        // har def value på 0
        private static int _id = 0;
        
        // Inde i klassen, så bliver setters i hvert fald ikke brugt.
        public int Id { get; }
        public string Name { get; }
        public float Price { get; }

        public Product(string name, float price)
        {
            Name = name;
            Price = price;

            // ref skal være initialized, hvor out ikke skal være. In betyder bare man ikke må modificere in parametret.
            Id = Interlocked.Increment(ref _id);

        }


    }
}
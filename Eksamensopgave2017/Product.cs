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
        public bool Active { get; set; }

        public Product(string name, float price, bool active)
        {
            Name = name;
            Price = price;
            Active = active;

            // ref skal være initialized, hvor out ikke skal være. In betyder bare man ikke må modificere in parametret.
            Id = Interlocked.Increment(ref _id);

        }

        public override string ToString()
        {
            return "Id: " + Id + " Name: " + Name + " Price: " + Price + " Active: " + Active;
        }
    }
}
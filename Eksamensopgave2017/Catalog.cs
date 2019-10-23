using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Eksamensopgave2017
{
    public class Catalog
    {
        private List<Product> products = new List<Product>();

        public List<Product> Products
        {
            get => products;
            //set => products = value;
        }

        public Catalog(string path)
        { 
            UpdateCatalog(path);
        }
        
        public void UpdateCatalog(string path)
        {
            int lineCounter = 0;
            
            using(var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    string[] values = line.Split(';');

                    // Parse value
                    bool tryParse = Int32.TryParse(values[2], out int result2);
                    //bool result3 =  Convert.ToBoolean(values[3]);

                    if (tryParse == true)
                    {
                        // Format: id;name;price;active;deactivate_date
                        Product readProduct = new Product(values[1], result2, true);
                        products.Add(readProduct);                        
                    }
                    
                    lineCounter++;
                }

                Console.WriteLine("LINES IN CATALOG: " + lineCounter);
            }
        }

        // Debug metode, der bliver udskrevet i BuySystemCLI nu
        public void PrintCatalog()
        {
            foreach (var product in products)
            {
                Console.WriteLine(product.ToString());
            }
        }
        
    }
}
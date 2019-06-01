using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;

namespace Eksamensopgave2017
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            /*
            List<User> users = new List<User>()
            {
                new User(){Id = 4, Username = "chrisercool"},
                new User(){Id = 2, Username = "olfa320"},
                new User(){Id = 5, Username = "bent501"},
                new User(){Id = 3, Username = "69leethaxor"},
                new User(){Id = 1, Username = "qwertyqwert"}
            };

            //users.Sort(new CompareUserByUsernameReverse());

            //foreach (var user in users)
            //{
            //    Console.WriteLine(user);
            //}
            
            Collection<User> userz = new Collection<User>();

            // Initializing this collection from other list
            foreach (var user in users)
            {
                userz.Add(user);
            }

            foreach (var user in userz)
            {
                Console.WriteLine(user);
            }
            
            
            Collection<Transaction> transactions = new Collection<Transaction>();
            
            Transaction transaction1 = new Transaction();
            Transaction transaction2 = new Transaction();
            Transaction transaction3 = new Transaction();
            
            transactions.Add(transaction1);
            transactions.Add(transaction2);
            transactions.Add(transaction3);

            foreach (var transaction in transactions)
            {
                Console.WriteLine(transaction.Id);
            }
            
            */
            
            List<User> users = new List<User>()
            {
                new User(){Id = 4, Username = "chrisercool", Money = 80f},
                new User(){Id = 2, Username = "olfa320", Money = 24f},
                new User(){Id = 5, Username = "bent501"},
                new User(){Id = 3, Username = "69leethaxor"},
                new User(){Id = 1, Username = "qwertyqwert"}
            };
            
            List<Product> products = new List<Product>()
            {
                new Product("coca cola 1.5L", 20f),
                new Product("Matilde Kakao", 15),
                new Product("Twix bar", 7),
                new Product("Snickers bar", 7),
            };
            
            BuySystem buySystem = new BuySystem();
            Notifier notifier = new Notifier(buySystem);
            
            buySystem.BuyProduct(users[0], products[0]);
            buySystem.BuyProduct(users[1], products[0]);
            buySystem.BuyProduct(users[0], products[0]);
            buySystem.BuyProduct(users[1], products[0]);
            buySystem.BuyProduct(users[3], products[0]);
            buySystem.BuyProduct(users[4], products[0]);
            buySystem.BuyProduct(users[2], products[0]);

            var searchedTransactions = buySystem.GetTransactions(users[0], 10);

            foreach (var searchedTransaction in searchedTransactions)
            {
                Console.WriteLine(searchedTransaction);
            }

        }
    }
}
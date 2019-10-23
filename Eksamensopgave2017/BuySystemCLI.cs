using System;
using System.Collections.Generic;

namespace Eksamensopgave2017
{
    public class BuySystemCLI
    {
        private Catalog _catalog;
        private BuySystem _buySystem;
        private Notifier _notifier;
        private List<User> _users;

        public BuySystemCLI(BuySystem buySystem)
        {
            _buySystem = buySystem;
            _notifier = new Notifier(_buySystem);

        }
        
        public void Start()
        {
            // retrieve users
            UserCatalog userCatalog = new UserCatalog();
            _users = userCatalog.GetUsers();

            _catalog = new Catalog(@"C:\Programming\products.csv");
            
            Update();
        }

        // Infinite loop, might be another thread?
        public void Update()
        {
            string input;
            ShowActiveProducts();

            do
            {
                Console.WriteLine("Type 'show', 'buy', 'insert' or 'exit'");
                
                input = Console.ReadLine();

                switch (input)
                {
                    case "show":
                        ShowActiveProducts();
                        break;
                    
                    case "buy":
                        Console.WriteLine("Type an ID of the product you want to buy");

                        string prodIdReadLine = Console.ReadLine();
                        Int32.TryParse(prodIdReadLine, out int prodId);

                        User user = UserPrompt();

                        if(user != null && prodId < _catalog.Products.Count + 1)
                            // -1 because the list of product starts at index 0. To prevent out of bounds too
                            _buySystem.BuyProduct(user, _catalog.Products[prodId - 1]);
                        
                        break;
                    
                    case "insert":
                        Console.WriteLine("Type amount:");

                        string amountReadLine = Console.ReadLine();
                        Int32.TryParse(amountReadLine, out int amount);

                        User userAmount = UserPrompt();

                        if (userAmount != null)
                            _buySystem.AddCreditsToAccount(userAmount, amount);

                        break;
                    
                    default:
                        Console.WriteLine("Not a recognized command");
                        break;
                }

            } while (input != "exit");
        }

        public User UserPrompt()
        {
            Console.WriteLine("Type username:");
            string usernameRead = Console.ReadLine();

            // Shouldn't be here probably, it is not this class responsibility
            foreach (var user in _users)
            {
                if (user.Username == usernameRead)
                {
                    return user;
                }
            }

            return null;
        }
        

        public void ShowActiveProducts()
        {
            foreach (var product in _catalog.Products)
            {
                Console.WriteLine(product);
            }
        }
        
    }
}
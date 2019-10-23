using System;
using System.Collections.Generic;
using System.IO;

namespace Eksamensopgave2017
{
    public class BuySystem
    {
        List<Transaction> transactions = new List<Transaction>();
        
        // dateTime for storing log
        private static DateTime _dateTime;
        // streamWriter for log
        private static StreamWriter outputFile;
        
        public static void LogToFile(string message)
        {
            // Creating a logfile in documents
            // Set a variable to the Documents path.
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Append text to an existing file named "WriteLines.txt".
            using (outputFile = new StreamWriter(Path.Combine(docPath, "Log.txt"), true))
            {
                outputFile.WriteLine(_dateTime + " " + message);
            }
        }

        public static void LogToConsole(string message)
        {
            Console.WriteLine(_dateTime + " " + message);
        }
        
        // Constructor to set up logger and so on
        public BuySystem()
        {
            Logger.WriteMessage += LogToFile;
            Logger.WriteMessage += LogToConsole;
            _dateTime = DateTime.Now;
            
        }
        
        public int BuyProduct(User user, Product product)
        {
            try
            {
                BuyTransaction buyTransaction = new BuyTransaction(user, product.Price);
                TrackTransaction(buyTransaction);
                Logger.WriteMessage(buyTransaction.ToString() + " Product Name & ID: " + product.Name + product.Id);
            }
            catch (InsufficientCreditsException e)
            {
                Logger.WriteMessage("ID:" + user.Id + " There were not enough credits on the user's account");
                return 1;
            }

            // Trigger event to notify user
            if (user.Money <= 2000)
            {
                PushNotification?.Invoke(this, new UserBalanceNotificationArgs(user.Money));
            } 
            return 0;
        }

        public int AddCreditsToAccount(User user, float amount)
        {
            InsertCashTransaction insertCashTransaction = new InsertCashTransaction(user, amount);
            TrackTransaction(insertCashTransaction);
            Logger.WriteMessage(insertCashTransaction.ToString());
            
            return 0;
        }

        private void TrackTransaction(Transaction transaction)
        {
            transactions.Add(transaction);
        }


        public IEnumerable<Transaction> GetTransactions(User user, int count)
        {
            foreach (var transaction in transactions)
            {
                if (transaction.User.Id.Equals(user.Id))
                {
                    yield return transaction;                    
                }
            }
        }

        // EVENT
        public event EventHandler<UserBalanceNotificationArgs> PushNotification;
    }
    
    // EVENT
    public class UserBalanceNotificationArgs : EventArgs
    {
        public float Balance { get; }
        
        public UserBalanceNotificationArgs(float balance)
        {
            Balance = balance;
        }
    }


/*    BuyProduct(user, product)
    ◦ udfører den logik der køber et produkt på en brugers konto, ved brug af en transaktion
    • AddCreditsToAccount(user, amount)
    ◦ indsætter et beløb på en brugers konto, via en transaktion.
    • ExecuteTransaction(transaction)
    ◦ hjælpemetode til at eksekvere transaktioner, og sørge for at de bliver tilføjet til en liste af udførte transaktioner. Hvis transaktionen altså ikke fejler.
    • GetProductByID(...)
    ◦ Finder og returnerer det unikke produkt i listen over produkter ud fra et produkt-id. Der bliver kastet en brugerdefineret exception hvis produktet ikke eksisterer. Denne exception indeholder information om produkt og beskrivende besked.
    • GetUsers(Func<User, bool> predicate)
    ◦ Brugere der overholder predicate
    • GetUserByUsername(string username)
    ◦ Finder og returnerer den unikke bruger i brugerlisten ud fra brugernavn. Der bliver kastet en brugerdefineret exception hvis brugeren ikke findes. Denne exception indeholder information om bruger og beskrivende besked.
    • GetTransactions(User user, int count)
    ◦ Finder et angivet (via parameter) antal transaktioner relateret til en given specifik bruger. Det er de nyeste transaktioner der findes.
    • ActiveProducts
    ◦ aktive produkter i stregsystemet på nuværende tidspunkt*/
}
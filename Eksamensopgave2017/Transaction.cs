using System;
using System.Text;
using System.Threading;

namespace Eksamensopgave2017
{
    public abstract class Transaction
    {
        // Field
        private static int _id = 0;
        protected User associatedUser { get; set; }

        public User User
        {
            get { return associatedUser; }
        }
        
        
        // Property
        public int Id { get; private set; }
        
        public Transaction(User user)
        { 
            Id = Interlocked.Increment(ref _id);
            associatedUser = user;
        }

        public abstract void Execute();

        public override string ToString()
        {
            return "ID:" + _id + " User:" + associatedUser + " Money: " + associatedUser.Money;
        }
    }

    public class InsufficientCreditsException : Exception
    {
        public InsufficientCreditsException()
        {
        }

        public InsufficientCreditsException(string message)
            : base(message)
        {
        }

        public InsufficientCreditsException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
    
}
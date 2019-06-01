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

    public class InsertCashTransaction : Transaction
    {
        private float _amount;
        
        public InsertCashTransaction(User user, float amount) : base(user)
        {
            associatedUser = user;
            _amount = amount;
            Execute();
        }

        public override void Execute()
        {
            associatedUser.Money = associatedUser.Money + _amount;
        }
    }
    
    public class BuyTransaction : Transaction
    {
        private float _amount;
        
        public BuyTransaction(User user, float amount) : base(user)
        {
            associatedUser = user;
            _amount = amount;
            Execute();
        }

        public override void Execute()
        {
            if (_amount > associatedUser.Money)
            {
                throw new InsufficientCreditsException("The user does not have enough money");
            }
            else
            {
                associatedUser.Money = associatedUser.Money - _amount;
            }
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
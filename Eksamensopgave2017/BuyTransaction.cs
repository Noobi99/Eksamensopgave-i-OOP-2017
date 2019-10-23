namespace Eksamensopgave2017
{
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
}
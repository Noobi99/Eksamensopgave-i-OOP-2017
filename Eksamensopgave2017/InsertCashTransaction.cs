namespace Eksamensopgave2017
{
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
}
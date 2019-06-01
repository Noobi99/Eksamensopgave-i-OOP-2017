using System;

namespace Eksamensopgave2017
{
    public class Notifier
    {
        private BuySystem _buySystem;
        
        
        public Notifier(BuySystem buySystem)
        {
            _buySystem = buySystem;
            
            // Subscribe to event
            _buySystem.PushNotification += Notification;
        }

        public void Notification(object sender, UserBalanceNotificationArgs e)
        {
            Console.WriteLine("You are running low on money lad. You are at: " + e.Balance);
        }
    }
}
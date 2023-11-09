using Baltazar.SharedContext;
using Baltazar.NotificationContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baltazar.SubscriptionContext
{
    public class Student : Base
    {
        public Student(string name)
        {   
            Name = name;
            Subscriptions = new List<Subscription>();
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public User User { get; set; }

        public IList<Subscription> Subscriptions { get; set; }

        public bool isPremium => Subscriptions.Any(x => !x.IsInactive);

        public void CreateSubscription(Subscription subscription)
        {
            if (isPremium)
                AddNotification(new Notification("student.subs","ja tem assinatura ativa"));
            Subscriptions.Add(subscription);
        }



    }
}

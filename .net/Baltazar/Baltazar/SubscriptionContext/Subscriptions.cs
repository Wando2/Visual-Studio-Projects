using Baltazar.SharedContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baltazar.SubscriptionContext
{
    public class Subscription : Base
    {
        Plan Plan { get; set; }

        DateTime? ExpirationDate { get; set; }

        public bool IsInactive => ExpirationDate <= DateTime.Now;
    }
}

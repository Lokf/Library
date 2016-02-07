using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lokf.Library.Users
{
    public class Fine
    {
        public Fine(Guid lendingId, decimal amount)
        {
            LendingId = lendingId;

            Amount = amount;
        }

        public Guid LendingId { get; }

        public decimal Amount { get; }        
    }
}

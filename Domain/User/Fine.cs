using System;

namespace Lokf.Library.Users
{
    public class Fine
    {
        public Fine(Guid lendingId, decimal amount)
        {
            LendingId = lendingId;

            Amount = amount;
        }

        public decimal Amount { get; }

        public Guid LendingId { get; }
    }
}

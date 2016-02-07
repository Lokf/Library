namespace Lokf.Library.Contracts.Events
{
    using Infrastructure;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UserFinedEvent : DomainEvent
    {
        public UserFinedEvent(Guid userId, Guid lendingId, decimal amount)
            : base(userId)
        {
            LendingId = lendingId;

            Amount = amount;
        }

        public Guid LendingId { get; }

        public decimal Amount { get; }
    }
}

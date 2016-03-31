namespace Lokf.Library.Contracts.Events
{
    using Infrastructure;
    using System;

    public class UserFinedEvent : DomainEvent
    {
        public UserFinedEvent(Guid userId, Guid lendingId, decimal amount)
            : base(userId)
        {
            LendingId = lendingId;

            Amount = amount;
        }

        public decimal Amount { get; }

        public Guid LendingId { get; }
    }
}

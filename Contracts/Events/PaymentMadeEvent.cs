namespace Lokf.Library.Contracts.Events
{
    using Infrastructure;
    using System;

    public class PaymentMadeEvent : DomainEvent
    {
        public PaymentMadeEvent(Guid userId, decimal amount, DateTime date)
            : base(userId)
        {
            Amount = amount;

            Date = date;
        }

        public decimal Amount { get; }

        public DateTime Date { get; }
    }
}

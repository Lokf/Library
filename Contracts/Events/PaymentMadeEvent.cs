namespace Lokf.Library.Contracts.Events
{
    using Infrastructure;
    using System;

    /// <summary>
    /// Event for a payment have been made.
    /// </summary>
    public class PaymentMadeEvent : DomainEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentMadeEvent"/> class.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <param name="amount">The amount.</param>
        /// <param name="date">The date of the payment.</param>
        public PaymentMadeEvent(Guid userId, decimal amount, DateTime date)
            : base(userId)
        {
            Amount = amount;

            Date = date;
        }

        /// <summary>
        /// Gets the amount.
        /// </summary>
        public decimal Amount { get; }

        /// <summary>
        /// Gets the date of the payment.
        /// </summary>
        public DateTime Date { get; }
    }
}

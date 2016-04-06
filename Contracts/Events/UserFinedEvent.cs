namespace Lokf.Library.Contracts.Events
{
    using Infrastructure;
    using System;

    /// <summary>
    /// Event for a user have been fined.
    /// </summary>
    public class UserFinedEvent : DomainEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserFinedEvent"/> class.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <param name="lendingId">The lending ID.</param>
        /// <param name="amount">The amount</param>
        public UserFinedEvent(Guid userId, Guid lendingId, decimal amount)
            : base(userId)
        {
            LendingId = lendingId;

            Amount = amount;
        }

        /// <summary>
        /// Gets the amount.
        /// </summary>
        public decimal Amount { get; }

        /// <summary>
        /// Gets the lending ID.
        /// </summary>
        public Guid LendingId { get; }
    }
}

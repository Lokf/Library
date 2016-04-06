namespace Lokf.Library.Users
{
    using System;

    /// <summary>
    /// Represents a fine.
    /// </summary>
    public class Fine
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Fine"/> class.
        /// </summary>
        /// <param name="lendingId">The lending ID.</param>
        /// <param name="amount">The amount.</param>
        public Fine(Guid lendingId, decimal amount)
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

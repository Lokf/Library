namespace Lokf.Library.Contracts.Reports
{
    using System;

    /// <summary>
    /// Report for a user fine.
    /// </summary>
    public class UserFineReport
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserFineReport"/> class.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <param name="lendingId">The lending ID.</param>
        /// <param name="amount">The amount.</param>
        public UserFineReport(Guid userId, Guid lendingId, decimal amount)
        {
            UserId = userId;

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

        /// <summary>
        /// Gets the user ID.
        /// </summary>
        public Guid UserId { get; }
    }
}

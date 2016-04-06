namespace Lokf.Library.Contracts.Commands
{
    using Infrastructure;
    using System;

    /// <summary>
    /// A command for fining a user.
    /// </summary>
    public sealed class FineUserCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FineUserCommand"/> class.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <param name="lendingId">The lending ID.</param>
        /// <param name="amount">The amount.</param>
        public FineUserCommand(Guid userId, Guid lendingId, decimal amount)
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

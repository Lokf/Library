namespace Lokf.Library.Contracts.Commands
{
    using Infrastructure;
    using System;

    /// <summary>
    /// Command for making a payment.
    /// </summary>
    public class MakePaymentCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MakePaymentCommand"/> class.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <param name="amount">The amount.</param>
        /// <param name="date">The date of the payment.</param>
        public MakePaymentCommand(Guid userId, decimal amount, DateTime date)
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

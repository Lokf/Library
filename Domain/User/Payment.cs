namespace Lokf.Library.Users
{
    using System;

    /// <summary>
    /// Represents a payment.
    /// </summary>
    public class Payment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Payment"/> class.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <param name="date">The date of the payment.</param>
        public Payment(decimal amount, DateTime date)
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

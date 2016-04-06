namespace Lokf.Library.Contracts.Commands
{
    using Infrastructure;
    using System;

    /// <summary>
    /// Command for returning a book.
    /// </summary>
    public class ReturnBookCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnBookCommand"/> class.
        /// </summary>
        /// <param name="lendingId">The lending ID.</param>
        /// <param name="returnDate">The return date.</param>
        public ReturnBookCommand(Guid lendingId, DateTime returnDate)
            : base(lendingId)
        {
            ReturnDate = returnDate;
        }

        /// <summary>
        /// Gets the return date.
        /// </summary>
        public DateTime ReturnDate { get; }
    }
}

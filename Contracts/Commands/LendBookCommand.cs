namespace Lokf.Library.Contracts.Commands
{
    using Infrastructure;
    using System;

    /// <summary>
    /// Command for lending a book.
    /// </summary>
    public sealed class LendBookCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LendBookCommand"/> class.
        /// </summary>
        /// <param name="lendingId">The lending ID.</param>
        /// <param name="userId">The user ID.</param>
        /// <param name="bookId">The book ID.</param>
        /// <param name="lendDate">The date of the lending.</param>
        public LendBookCommand(Guid lendingId, Guid userId, Guid bookId, DateTime lendDate)
            : base(lendingId)
        {
            UserId = userId;

            BookId = bookId;

            LendDate = lendDate;
        }

        /// <summary>
        /// Gets the book ID.
        /// </summary>
        public Guid BookId { get; }

        /// <summary>
        /// Gets the date of the lending.
        /// </summary>
        public DateTime LendDate { get; }

        /// <summary>
        /// Gets the user ID.
        /// </summary>
        public Guid UserId { get; }
    }
}

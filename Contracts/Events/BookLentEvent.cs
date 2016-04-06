namespace Lokf.Library.Contracts.Events
{
    using Infrastructure;
    using System;

    /// <summary>
    /// Event for a book have been lent.
    /// </summary>
    public class BookLentEvent : DomainEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookLentEvent"/> class.
        /// </summary>
        /// <param name="lendingId">The lending ID.</param>
        /// <param name="userId">The user ID.</param>
        /// <param name="bookId">The book ID.</param>
        /// <param name="lendDate">The date the book was lent.</param>
        /// <param name="dueDate">The due date of the lending.</param>
        public BookLentEvent(Guid lendingId, Guid userId, Guid bookId, DateTime lendDate, DateTime dueDate)
            : base(lendingId)
        {
            UserId = userId;

            BookId = bookId;

            LendDate = lendDate;

            DueDate = dueDate;
        }

        /// <summary>
        /// Gets the book ID.
        /// </summary>
        public Guid BookId { get; }

        /// <summary>
        /// Gets the due date.
        /// </summary>
        public DateTime DueDate { get; }

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

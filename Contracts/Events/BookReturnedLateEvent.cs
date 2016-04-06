namespace Lokf.Library.Contracts.Events
{
    using Infrastructure;
    using System;

    /// <summary>
    /// Event for a book have been returned too late.
    /// </summary>
    public class BookReturnedLateEvent : DomainEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookReturnedLateEvent"/> class.
        /// </summary>
        /// <param name="lendingId">The lending ID.</param>
        /// <param name="returnDate">The return date.</param>
        /// <param name="dueDate">The due date.</param>
        public BookReturnedLateEvent(Guid lendingId, DateTime returnDate, DateTime dueDate)
            : base(lendingId)
        {
            ReturnDate = returnDate;

            DueDate = dueDate;
        }

        /// <summary>
        /// Gets the due date.
        /// </summary>
        public DateTime DueDate { get; }

        /// <summary>
        /// Gets the return date.
        /// </summary>
        public DateTime ReturnDate { get; }
    }
}

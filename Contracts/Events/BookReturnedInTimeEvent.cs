namespace Lokf.Library.Contracts.Events
{
    using Infrastructure;
    using System;

    /// <summary>
    /// Event for a book have been returned in time.
    /// </summary>
    public class BookReturnedInTimeEvent : DomainEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookReturnedInTimeEvent"/> class.
        /// </summary>
        /// <param name="lendingId">The lending ID.</param>
        /// <param name="returnDate">The return date.</param>
        public BookReturnedInTimeEvent(Guid lendingId, DateTime returnDate)
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

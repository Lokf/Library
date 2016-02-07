namespace Lokf.Library.Contracts.Events
{
    using Infrastructure;
    using System;

    public class BookReturnedLateEvent : DomainEvent
    {
        public BookReturnedLateEvent(Guid lendingId, DateTime returnDate, DateTime dueDate)
            : base(lendingId)
        {
            ReturnDate = returnDate;

            DueDate = dueDate;
        }

        public DateTime ReturnDate { get; }

        public DateTime DueDate { get; }
    }
}

namespace Lokf.Library.Contracts.Events
{
    using Infrastructure;
    using System;

    public class BookReturnedInTimeEvent : DomainEvent
    {
        public BookReturnedInTimeEvent(Guid lendingId, DateTime returnDate)
            : base(lendingId)
        {
            ReturnDate = returnDate;
        }

        public DateTime ReturnDate { get; }
    }
}

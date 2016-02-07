

namespace Lokf.Library.Contracts.Events
{
    using Infrastructure;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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

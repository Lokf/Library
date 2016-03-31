namespace Lokf.Library.Test.Scenarios.A_book_is_returned
{
    using Contracts.Events;
    using Infrastructure;
    using Lendings;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class Given_a_already_returned_book : When_a_book_is_returned
    {
        protected override Exception ExpectedException()
        {
            return new BookAlreadyReturnedException();
        }

        protected override IEnumerable<IDomainEvent> Given()
        {
            yield return new BookLentEvent(_lendingId, Guid.Empty, Guid.Empty, new DateTime(2014, 7, 10), new DateTime(2014, 8, 9));
            yield return new BookReturnedInTimeEvent(_lendingId, new DateTime(2014, 7, 11));
        }
    }
}

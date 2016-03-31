namespace Lokf.Library.Test.Scenarios.A_book_is_returned
{
    using Contracts.Events;
    using Infrastructure;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class Given_a_book_lent_yielding_the_return_to_be_late : When_a_book_is_returned
    {
        protected override IEnumerable<IDomainEvent> ExpectedEvents()
        {
            yield return new BookReturnedLateEvent(_lendingId, new DateTime(2014, 7, 11), new DateTime(2014, 7, 9));
        }

        protected override IEnumerable<IDomainEvent> Given()
        {
            yield return new BookLentEvent(_lendingId, Guid.Empty, Guid.Empty, new DateTime(2014, 6, 10), new DateTime(2014, 7, 9));
        }
    }
}

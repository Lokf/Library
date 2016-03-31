namespace Lokf.Library.Test.Scenarios.A_book_is_returned
{
    using Contracts.Events;
    using Infrastructure;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class Given_a_book_lent_yielding_the_return_to_be_in_time : When_a_book_is_returned
    {
        protected override IEnumerable<IDomainEvent> ExpectedEvents()
        {
            yield return new BookReturnedInTimeEvent(_lendingId, new DateTime(2014, 7, 11));
        }

        protected override IEnumerable<IDomainEvent> Given()
        {
            yield return new BookLentEvent(_lendingId, Guid.Empty, Guid.Empty, new DateTime(2014, 7, 10), new DateTime(2014, 8, 9));
        }
    }
}

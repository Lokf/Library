namespace Lokf.Library.Test.Scenarios.A_book_is_lent
{
    using Contracts.Events;
    using Infrastructure;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class Given_a_registered_user : When_a_book_is_lent
    {
        protected override IEnumerable<IDomainEvent> ExpectedEvents()
        {
            yield return new BookLentEvent(Guid.Empty, _userId, Guid.Empty, new DateTime(2014, 7, 10), new DateTime(2014, 8, 9));
        }

        protected override IEnumerable<IDomainEvent> Given()
        {
            yield return new UserRegisteredEvent(_userId, "900625-1277");
        }
    }
}

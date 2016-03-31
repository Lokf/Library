namespace Lokf.Library.Test.Scenarios.A_book_is_lent
{
    using Contracts.Events;
    using Infrastructure;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class Given_a_user_with_a_paid_off_debt : When_a_book_is_lent
    {
        protected override IEnumerable<IDomainEvent> ExpectedEvents()
        {
            yield return new BookLentEvent(Guid.Empty, _userId, Guid.Empty, new DateTime(2014, 7, 10), new DateTime(2014, 8, 9));
        }

        protected override IEnumerable<IDomainEvent> Given()
        {
            yield return new UserRegisteredEvent(_userId, "900625-1277");
            yield return new UserFinedEvent(_userId, Guid.Empty, 100);
            yield return new PaymentMadeEvent(_userId, 100, new DateTime(2014, 7, 10));
        }
    }
}

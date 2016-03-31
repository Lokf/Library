namespace Lokf.Library.Test.Scenarios.A_book_is_lent
{
    using Contracts.Events;
    using Infrastructure;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class Given_a_user_in_debt : When_a_book_is_lent
    {
        protected override Exception ExpectedException()
        {
            return new Exception();
        }

        protected override IEnumerable<IDomainEvent> Given()
        {
            yield return new UserRegisteredEvent(_userId, "900625-1277");
            yield return new UserFinedEvent(_userId, Guid.Empty, 100);
        }
    }
}

namespace Lokf.Library.Test.Scenarios.A_user_is_fined
{
    using Contracts.Events;
    using Infrastructure;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class Given_a_registered_user : When_a_user_is_fined
    {
        protected override IEnumerable<IDomainEvent> ExpectedEvents()
        {
            yield return new UserFinedEvent(_userId, Guid.Empty, 100);
        }

        protected override IEnumerable<IDomainEvent> Given()
        {
            yield return new UserRegisteredEvent(_userId, "900625-1277");
        }
    }
}

namespace Lokf.Library.Test.Scenarios.A_user_is_registered
{
    using Contracts.Events;
    using Infrastructure;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class Give_no_registered_user : When_a_user_is_registered
    {
        protected override IEnumerable<IDomainEvent> ExpectedEvents()
        {
            yield return new UserRegisteredEvent(Guid.Empty, "900625-1277");
        }

        protected override IEnumerable<IDomainEvent> Given()
        {
            yield break;
        }
    }
}

namespace Lokf.Library.Test.Scenarios.A_payment_is_made
{
    using Contracts.Events;
    using Infrastructure;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class Given_a_user_with_a_matching_debt : When_a_payment_is_made
    {
        protected override IEnumerable<IDomainEvent> ExpectedEvents()
        {
            yield return new PaymentMadeEvent(_userId, 100, new DateTime(2014, 7, 10));
        }

        protected override IEnumerable<IDomainEvent> Given()
        {
            yield return new UserRegisteredEvent(_userId, "199006251277");
            yield return new UserFinedEvent(_userId, Guid.Empty, 100);
        }
    }
}

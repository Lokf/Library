namespace Lokf.Library.Test.Scenarios.A_payment_is_made
{
    using Contracts.Events;
    using Infrastructure;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using Users;

    [TestFixture]
    public class Given_a_debt_yielding_the_payment_to_be_too_large : When_a_payment_is_made
    {
        protected override Exception ExpectedException()
        {
            return new TooLargePaymentException();
        }

        protected override IEnumerable<IDomainEvent> Given()
        {
            yield return new UserRegisteredEvent(_userId, "199006251277");
            yield return new UserFinedEvent(_userId, Guid.Empty, 50);
        }
    }
}

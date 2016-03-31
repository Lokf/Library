namespace Lokf.Library.Test.Scenarios.A_user_is_fined
{
    using Infrastructure;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class Given_no_registered_user2 : When_a_user_is_fined
    {
        protected override Exception ExpectedException()
        {
            return new AggregateNotFoundException();
        }
    }
}

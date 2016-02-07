

namespace Lokf.Library.Test.Scenarios
{
    using Lokf.Library.Infrastructure;
    using Lokf.Library.Users;
    using Lokf.Library.CommandHandlers;
    using Lokf.Library.Contracts.Commands;
    using Lokf.Library.Contracts.Events;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestFixture]
    public class When_a_user_is_registered : CommandTest<RegisterUserCommand>
    {
        protected override ICommandHandler<RegisterUserCommand> OnHandler()
        {
            var repository = new DomainRepository<User>(UnitOfWork);

            return new RegisterUserCommandHandler(repository);
        }

        protected override RegisterUserCommand When()
        {
            return new RegisterUserCommand(Guid.Empty, "900625-1277");
        }

        protected override IEnumerable<IDomainEvent> Given()
        {
            yield break;
        }

        protected override IEnumerable<IDomainEvent> ExpectedEvents()
        {
            yield return new UserRegisteredEvent(Guid.Empty, "900625-1277");
        }
    }
}

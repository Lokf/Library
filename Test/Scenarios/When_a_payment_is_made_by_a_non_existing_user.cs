

namespace Lokf.Library.Test.Scenarios
{
    using Contracts.Commands;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Infrastructure;
    using Users;
    using CommandHandlers;

    public class When_a_payment_is_made_by_a_non_existing_user : CommandTest<MakePaymentCommand>
    {
        private static readonly Guid _userId = Guid.NewGuid();

        protected override ICommandHandler<MakePaymentCommand> OnHandler()
        {
            var repository = new DomainRepository<User>(UnitOfWork);

            return new MakePaymentCommandHandler(repository);
        }

        protected override MakePaymentCommand When()
        {
            return new MakePaymentCommand(_userId, 100, new DateTime(2014, 7, 10));
        }

        protected override Exception ExpectedException()
        {
            return new AggregateNotFoundException();
        }
    }
}

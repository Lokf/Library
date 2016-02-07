namespace Lokf.Library.Test.Scenarios
{
    using Contracts.Commands;
    using Infrastructure;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Contracts.Events;
    using Lendings;
    using CommandHandlers;

    public class When_a_book_not_lent_is_returned : CommandTest<ReturnBookCommand>
    {
        static readonly Guid _lendingId = Guid.NewGuid();

        protected override IEnumerable<IDomainEvent> Given()
        {
            yield break;
        }

        protected override ICommandHandler<ReturnBookCommand> OnHandler()
        {
            var repository = new DomainRepository<Lending>(UnitOfWork);

            return new ReturnBookCommandHandler(repository);
        }

        protected override ReturnBookCommand When()
        {
            return new ReturnBookCommand(_lendingId, new DateTime(2014, 7, 10));
        }

        protected override Exception ExpectedException()
        {
            return new AggregateNotFoundException();
        }
    }
}

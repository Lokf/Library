namespace Lokf.Library.Test.Scenarios
{
    using Infrastructure;
    using Contracts.Events;
    using Contracts.Commands;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CommandHandlers;
    using Lendings;


    public class When_a_returned_book_is_returned : CommandTest<ReturnBookCommand>
    {
        static readonly Guid _lendingId = Guid.NewGuid();

        protected override IEnumerable<IDomainEvent> Given()
        {
            yield return new BookLentEvent(_lendingId, Guid.Empty, Guid.Empty, new DateTime(2014, 7, 10), new DateTime(2014, 8, 9));

            yield return new BookReturnedInTimeEvent(_lendingId, new DateTime(2014, 7, 11));
        }

        protected override ICommandHandler<ReturnBookCommand> OnHandler()
        {
            var repository = new DomainRepository<Lending>(UnitOfWork);

            return new ReturnBookCommandHandler(repository);
        }

        protected override ReturnBookCommand When()
        {
            return new ReturnBookCommand(_lendingId, new DateTime(2014, 7, 11));
        }

        protected override Exception ExpectedException()
        {
            return new BookAlreadyReturnedException();
        }
    }
}

namespace Lokf.Library.CommandHandlers
{
    using Infrastructure;
    using Contracts.Commands;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Lendings;

    public class ReturnBookCommandHandler : ICommandHandler<ReturnBookCommand>
    {
        private readonly IDomainRepository<Lending> _repository;

        public ReturnBookCommandHandler(IDomainRepository<Lending> repository)
        {
            _repository = repository;
        }

        public void Handle(ReturnBookCommand command)
        {
            var lending = _repository.GetById(command.AggregateId);

            lending.ReturnBook(command.ReturnDate);
        }
    }

}

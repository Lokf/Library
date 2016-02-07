namespace Lokf.Library.CommandHandlers
{
    using Infrastructure;
    using Contracts.Commands;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Users;

    public class MakePaymentCommandHandler : ICommandHandler<MakePaymentCommand>
    {
        private readonly IDomainRepository<User> _repository;

        public MakePaymentCommandHandler(IDomainRepository<User> repository)
        {
            _repository = repository;
        }

        public void Handle(MakePaymentCommand command)
        {
            var user = _repository.GetById(command.AggregateId);

            user.MakePayment(command.Amount, command.Date);
        }
    }
}

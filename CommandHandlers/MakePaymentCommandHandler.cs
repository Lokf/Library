namespace Lokf.Library.CommandHandlers
{
    using Contracts.Commands;
    using Infrastructure;
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

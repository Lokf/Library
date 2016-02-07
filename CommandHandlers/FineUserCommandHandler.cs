namespace Lokf.Library.CommandHandlers
{
    using Infrastructure;
    using Contracts.Commands;
    using Users;

    public class FineUserCommandHandler : ICommandHandler<FineUserCommand>
    {
        private readonly IDomainRepository<User> _repository;

        public FineUserCommandHandler(IDomainRepository<User> repository)
        {
            _repository = repository;
        }

        public void Handle(FineUserCommand command)
        {
            var user = _repository.GetById(command.AggregateId);

            user.FineUser(command.LendingId, command.Amount);
        }
    }
}

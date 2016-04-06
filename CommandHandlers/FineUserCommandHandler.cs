namespace Lokf.Library.CommandHandlers
{
    using Contracts.Commands;
    using Infrastructure;
    using Users;

    /// <summary>
    /// Handler for <see cref="FineUserCommand"/>.
    /// </summary>
    public class FineUserCommandHandler : ICommandHandler<FineUserCommand>
    {
        private readonly IDomainRepository<User> _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="FineUserCommandHandler"/> class.
        /// </summary>
        /// <param name="repository">The user repository.</param>
        public FineUserCommandHandler(IDomainRepository<User> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Handles the command.
        /// </summary>
        /// <param name="command">The command.</param>
        public void Handle(FineUserCommand command)
        {
            var user = _repository.GetById(command.AggregateId);

            user.FineUser(command.LendingId, command.Amount);
        }
    }
}

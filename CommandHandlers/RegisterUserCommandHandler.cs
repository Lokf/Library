namespace Lokf.Library.CommandHandlers
{
    using Infrastructure;
    using Contracts.Commands;
    using Users;

    /// <summary>
    /// A handler for the <see cref="RegisterUserCommand"/> command.
    /// </summary>
    public sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand>
    {
        private readonly IDomainRepository<User> _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterUserCommandHandler"/> class.
        /// </summary>
        /// <param name="repository">The user repository.</param>
        public RegisterUserCommandHandler(IDomainRepository<User> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Handles the command.
        /// </summary>
        /// <param name="command">The command to handle.</param>
        public void Handle(RegisterUserCommand command) {
            var user = User.RegisterUser(command.AggregateId, PersonalIdentityNumber.Parse(command.PersonalIdentityNumber));

            _repository.Add(user);
        }
    }
}

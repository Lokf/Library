namespace Lokf.Library.CommandHandlers
{
    using Contracts.Commands;
    using Infrastructure;
    using Users;

    /// <summary>
    /// Handlers for <see cref="MakePaymentCommand"/>.
    /// </summary>
    public class MakePaymentCommandHandler : ICommandHandler<MakePaymentCommand>
    {
        private readonly IDomainRepository<User> _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="MakePaymentCommandHandler"/> class.
        /// </summary>
        /// <param name="repository">The user repository.</param>
        public MakePaymentCommandHandler(IDomainRepository<User> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Handles the command.
        /// </summary>
        /// <param name="command">The command.</param>
        public void Handle(MakePaymentCommand command)
        {
            var user = _repository.GetById(command.AggregateId);

            user.MakePayment(command.Amount, command.Date);
        }
    }
}

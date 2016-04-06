namespace Lokf.Library.CommandHandlers
{
    using Contracts.Commands;
    using Infrastructure;
    using Lendings;

    /// <summary>
    /// Handlers for <see cref="ReturnBookCommand"/>.
    /// </summary>
    public class ReturnBookCommandHandler : ICommandHandler<ReturnBookCommand>
    {
        private readonly IDomainRepository<Lending> _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnBookCommandHandler"/> class.
        /// </summary>
        /// <param name="repository">The lending repository.</param>
        public ReturnBookCommandHandler(IDomainRepository<Lending> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Handles the command.
        /// </summary>
        /// <param name="command">The command.</param>
        public void Handle(ReturnBookCommand command)
        {
            var lending = _repository.GetById(command.AggregateId);

            lending.ReturnBook(command.ReturnDate);
        }
    }
}

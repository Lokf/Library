namespace Lokf.Library.CommandHandlers
{
    using Contracts.Commands;
    using Infrastructure;
    using Lendings;
    using Services;
    using Users;

    /// <summary>
    /// Handler for <see cref="LendBookCommand"/>.
    /// </summary>
    public class LendBookCommandHandler : ICommandHandler<LendBookCommand>
    {
        private readonly IDueDateCalculator _dueDateCalculator;
        private readonly IDomainRepository<Lending> _lendingRepository;
        private readonly IDomainRepository<User> _userRepositroy;

        /// <summary>
        /// Initializes a new instance of the <see cref="LendBookCommandHandler"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="lendingRepository">The lending repository.</param>
        /// <param name="dueDateCalculator">The due date calculator.</param>
        public LendBookCommandHandler(IDomainRepository<User> userRepository, IDomainRepository<Lending> lendingRepository, IDueDateCalculator dueDateCalculator)
        {
            _userRepositroy = userRepository;

            _lendingRepository = lendingRepository;

            _dueDateCalculator = dueDateCalculator;
        }

        /// <summary>
        /// Handles the command.
        /// </summary>
        /// <param name="command">The command.</param>
        public void Handle(LendBookCommand command)
        {
            var user = _userRepositroy.GetById(command.UserId);

            var lending = user.LendBook(command.AggregateId, command.BookId, command.LendDate, _dueDateCalculator);

            _lendingRepository.Add(lending);
        }
    }
}

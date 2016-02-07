namespace Lokf.Library.CommandHandlers
{
    using Infrastructure;
    using Contracts.Commands;
    using Services;
    using Lendings;
    using Users;

    public class LendBookCommandHandler : ICommandHandler<LendBookCommand>
    {
        private readonly IDomainRepository<Lending> _lendingRepository;

        private readonly IDomainRepository<User> _userRepositroy;

        private readonly IDueDateCalculator _dueDateCalculator;

        public LendBookCommandHandler(IDomainRepository<User> userRepository, IDomainRepository<Lending> lendingRepository, IDueDateCalculator dueDateCalculator)
        {
            _userRepositroy = userRepository;

            _lendingRepository = lendingRepository;

            _dueDateCalculator = dueDateCalculator;
        }

        public void Handle(LendBookCommand command)
        {
            var user = _userRepositroy.GetById(command.UserId);

            var lending = user.LendBook(command.AggregateId, command.BookId, command.LendDate, _dueDateCalculator);

            _lendingRepository.Add(lending);
        }
    }
}

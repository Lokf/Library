namespace Lokf.Library.CommandHandlers
{
    using Contracts.Commands;
    using Infrastructure;
    using Lendings;
    using Services;
    using Users;

    public class LendBookCommandHandler : ICommandHandler<LendBookCommand>
    {
        private readonly IDueDateCalculator _dueDateCalculator;
        private readonly IDomainRepository<Lending> _lendingRepository;

        private readonly IDomainRepository<User> _userRepositroy;

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

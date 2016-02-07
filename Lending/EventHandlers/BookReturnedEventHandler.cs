namespace Lokf.Library.Lendings.EventHandlers
{
    using Infrastructure;
    using Events;
    using System;

    public class BookReturnedEventHandler : IEventHandler<BookReturnedInTimeEvent>
    {
        //private readonly IDomainRepository<User> _repository;

        public BookReturnedEventHandler()
        {

        }

        public void Handle(BookReturnedInTimeEvent command)
        {
            throw new NotImplementedException();
        }
    }
}

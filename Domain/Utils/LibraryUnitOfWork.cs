using Lokf.Library.Infrastructure;
using Lokf.Library.Lendings;
using Lokf.Library.Users;

namespace Domain.Utils
{
    public class LibraryUnitOfWork : EventStoreUnitOfWork
    {
        public LibraryUnitOfWork(IEventStore eventStore, IChangeTracker2 changeTracker) : base(eventStore, changeTracker)
        {
            Users = new DomainRepository<User>(eventStore, changeTracker);

            Lendings = new DomainRepository<Lending>(eventStore, changeTracker);
        }

        public IDomainRepository<Lending> Lendings { get; }

        public IDomainRepository<User> Users { get; }
    }
}

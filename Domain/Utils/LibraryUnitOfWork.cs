namespace Domain.Utils
{
    using Lokf.Library.Infrastructure;
    using Lokf.Library.Lendings;
    using Lokf.Library.Users;

    /// <summary>
    /// Represents a unit of work for the library.
    /// </summary>
    public class LibraryUnitOfWork : EventStoreUnitOfWork
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LibraryUnitOfWork"/> class.
        /// </summary>
        /// <param name="eventStore">The underlying event store.</param>
        /// <param name="changeTracker">The change tracker.</param>
        public LibraryUnitOfWork(IEventStore eventStore, IChangeTracker2 changeTracker) : base(eventStore, changeTracker)
        {
            Users = new DomainRepository<User>(eventStore, changeTracker);

            Lending = new DomainRepository<Lending>(eventStore, changeTracker);
        }

        /// <summary>
        /// Gets a repository for lending.
        /// </summary>
        public IDomainRepository<Lending> Lending { get; }

        /// <summary>
        /// Gets a repository for users.
        /// </summary>
        public IDomainRepository<User> Users { get; }
    }
}

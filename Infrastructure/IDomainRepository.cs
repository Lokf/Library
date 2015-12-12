namespace Lokf.Library.Infrastructure
{
    using System;

    /// <summary>
    /// Domain repository for event sourced objects.
    /// </summary>
    /// <typeparam name="TEventSourced">The event sourced type.</typeparam>
    public interface IDomainRepository<TEventSourced>
        where TEventSourced : IEventSourced
    {
        /// <summary>
        /// Gets the aggreagate by its ID.
        /// </summary>
        /// <param name="aggregateId">The aggregate ID.</param>
        /// <returns>The aggregate.</returns>
        TEventSourced GetById(Guid aggregateId);

        /// <summary>
        /// Adds a new aggregate to the repository for storage.
        /// </summary>
        /// <param name="aggregate">The aggregate to add to the repository.</param>
        void Add(TEventSourced aggregate);
    }
}

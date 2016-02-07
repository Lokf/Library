namespace Lokf.Library.Infrastructure
{
    using System;

    /// <summary>
    /// Base class for all commands.
    /// </summary>
    public abstract class Command : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Command"/> class.
        /// </summary>
        /// <param name="aggregateId">The aggregate ID.</param>
        public Command(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }

        /// <summary>
        /// Gets the aggregate ID.
        /// </summary>
        public Guid AggregateId { get; }
    }
}

namespace Lokf.Library.Infrastructure
{
    using System.Collections.Generic;

    /// <summary>
    /// Provides functionality for handling the aggregates marked as dirty.
    /// </summary>
    public interface IChangeTracker2 : IChangeTracker
    {
        /// <summary>
        /// Gets the dirty aggregates.
        /// </summary>
        IEnumerable<AggregateRoot> DirtyAggregates { get; }

        /// <summary>
        /// Resets the tracking of dirty aggregates.
        /// </summary>
        void ClearDirtyAggregates();
    }
}

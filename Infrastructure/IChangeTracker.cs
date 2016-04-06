namespace Lokf.Library.Infrastructure
{
    /// <summary>
    /// Provides functionality for tracking changed aggregates.
    /// </summary>
    public interface IChangeTracker
    {
        /// <summary>
        /// Marks the aggregate as dirty.
        /// </summary>
        /// <param name="aggregate">The aggregate.</param>
        void MarkAsDirty(AggregateRoot aggregate);
    }
}

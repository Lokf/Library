namespace Lokf.Library.Infrastructure
{
    using System;

    /// <summary>
    /// All commands must implement this interface.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Gets the ID of the targeted aggregate.
        /// </summary>
        Guid AggregateId { get; }
    }
}

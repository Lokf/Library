namespace Lokf.Library.Infrastructure
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    public interface IDomainEvent
    {
        Guid AggregateId { get; }
        Guid Id { get; }
        int Version { get; }
    }
}

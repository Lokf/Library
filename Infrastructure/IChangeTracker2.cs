using System.Collections.Generic;

namespace Lokf.Library.Infrastructure
{
    public interface IChangeTracker2 : IChangeTracker
    {
        IEnumerable<AggregateRoot> DirtyAggregates { get; }

        void ClearDirtyAggregates();
    }
}

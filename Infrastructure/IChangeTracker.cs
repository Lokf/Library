namespace Lokf.Library.Infrastructure
{
    public interface IChangeTracker
    {
        void MarkAsDirty(AggregateRoot aggregate);
    }
}

namespace Lokf.Library.Infrastructure
{
    /// <summary>
    /// Provides functionality for perform several tasks within one transaction.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Commits the work done within this unit.
        /// </summary>
        void Commit();

        /// <summary>
        /// Rollbacks the work done within this unit.
        /// </summary>
        void Rollback();
    }
}

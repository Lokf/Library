namespace Lokf.Library.Contracts.Queries
{
    using Infrastructure;
    using Reports;
    using System;

    /// <summary>
    /// Query for getting a user by its ID.
    /// </summary>
    public class GetUserByIdQuery : IQuery<UserReport>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetUserByIdQuery"/> class.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        public GetUserByIdQuery(Guid userId)
        {
            UserId = userId;
        }

        /// <summary>
        /// Gets the user ID.
        /// </summary>
        public Guid UserId { get; }
    }
}

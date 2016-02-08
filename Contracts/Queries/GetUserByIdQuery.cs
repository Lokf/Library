namespace Lokf.Library.Contracts.Queries
{
    using Infrastructure;
    using Reports;
    using System;

    public class GetUserByIdQuery : IQuery<UserReport>
    {
        public GetUserByIdQuery(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; }
    }
}

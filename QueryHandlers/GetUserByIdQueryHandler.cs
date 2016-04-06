namespace Lokf.Library.QueryHandlers
{
    using Contracts.Queries;
    using Contracts.Reports;
    using Infrastructure;
    using ReportingCaches;
    using System.Linq;

    /// <summary>
    /// Handler for <see cref="GetUserByIdQuery"/>.
    /// </summary>
    public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserReport>
    {
        private readonly UserReportCache _userCache;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetUserByIdQueryHandler"/> class.
        /// </summary>
        /// <param name="userCache">The user cache.</param>
        public GetUserByIdQueryHandler(UserReportCache userCache)
        {
            _userCache = userCache;
        }

        /// <summary>
        /// Handles the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>The user report.</returns>
        public UserReport Handle(GetUserByIdQuery query)
        {
            return _userCache.Users.Single(x => x.UserId == query.UserId);
        }
    }
}

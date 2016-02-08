namespace Lokf.Library.QueryHandlers
{
    using Contracts.Queries;
    using Contracts.Reports;
    using Infrastructure;
    using ReportingCaches;
    using System.Linq;

    public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserReport>
    {
        private readonly UserReportCache _userCache;

        public GetUserByIdQueryHandler(UserReportCache userCache)
        {
            _userCache = userCache;
        }

        public UserReport Handle(GetUserByIdQuery query)
        {
            return _userCache.Users.Single(x => x.UserId == query.UserId);
        }
    }
}

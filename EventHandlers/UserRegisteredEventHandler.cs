namespace EventHandlers
{
    using Lokf.Library.Contracts.Events;
    using Lokf.Library.Contracts.Reports;
    using Lokf.Library.Infrastructure;
    using Lokf.Library.ReportingCaches;

    public class UserRegisteredEventHandler : IEventHandler<UserRegisteredEvent>
    {
        private readonly UserReportCache _userCache;

        public UserRegisteredEventHandler(UserReportCache userCache)
        {
            _userCache = userCache;
        }

        public void Handle(UserRegisteredEvent @event)
        {
            _userCache.Add(new UserReport(@event.AggregateId, @event.PersonalIdentityNumber));
        }
    }
}

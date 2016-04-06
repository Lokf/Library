namespace EventHandlers
{
    using Lokf.Library.Contracts.Events;
    using Lokf.Library.Contracts.Reports;
    using Lokf.Library.Infrastructure;
    using Lokf.Library.ReportingCaches;

    /// <summary>
    /// Handler for <see cref="UserRegisteredEvent"/>.
    /// </summary>
    public class UserRegisteredEventHandler : IEventHandler<UserRegisteredEvent>
    {
        private readonly UserReportCache _userCache;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRegisteredEventHandler"/> class.
        /// </summary>
        /// <param name="userCache">The user report cache.</param>
        public UserRegisteredEventHandler(UserReportCache userCache)
        {
            _userCache = userCache;
        }

        /// <summary>
        /// Handles the event.
        /// </summary>
        /// <param name="event">The event.</param>
        public void Handle(UserRegisteredEvent @event)
        {
            _userCache.Add(new UserReport(@event.AggregateId, @event.PersonalIdentityNumber));
        }
    }
}

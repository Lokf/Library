namespace Lokf.Library.User
{
    using Infrastructure;
    using Events;
    using System;

    public sealed class User : AggregateRoot
    {
        public User(Guid userId) 
            : base(userId)
        {

        }

        public static User RegisterUser(Guid userId, PersonalIdentityNumber personalIdentityNumber)
        {
            var user = new User(userId);

            var userRegisteredEvent = new UserRegisteredEvent(userId, personalIdentityNumber.ToString());

            user.RaiseEvent(userRegisteredEvent);

            return user;
        }
    }
}

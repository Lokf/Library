namespace Lokf.Library.Users
{
    using Contracts.Events;
    using Infrastructure;
    using Lendings;
    using Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The aggregate root of the user aggregate. Provides functionality for managing users,
    /// such as registration, user details and debt handling.
    /// </summary>
    public sealed class User : AggregateRoot
    {
        private readonly List<Fine> _fines = new List<Fine>();

        private readonly List<Payment> _payments = new List<Payment>();

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        public User(Guid userId)
            : base(userId)
        {
            RegisterEventHandlers();
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <param name="personalIdentityNumber">The personal identity number.</param>
        /// <returns></returns>
        public static User RegisterUser(Guid userId, PersonalIdentityNumber personalIdentityNumber)
        {
            var user = new User(userId);

            var userRegisteredEvent = new UserRegisteredEvent(userId, personalIdentityNumber.ToString());

            user.RaiseEvent(userRegisteredEvent);

            return user;
        }

        public void FineUser(Guid lendingId, decimal amount)
        {
            var userFinedEvent = new UserFinedEvent(AggregateId, lendingId, amount);

            RaiseEvent(userFinedEvent);
        }

        public Lending LendBook(Guid lendingId, Guid bookId, DateTime lendDate, IDueDateCalculator dueDataCalculator)
        {
            if (IsInDebt())
            {
                throw new Exception("Cant borrow when i debt");
            }

            return Lending.LendBook(lendingId, AggregateId, bookId, lendDate, dueDataCalculator);
        }

        public void MakePayment(decimal amount, DateTime date)
        {
            if (amount > OutstandingDebt())
            {
                throw new TooLargePaymentException();
            }

            var paymentMadeEvent = new PaymentMadeEvent(AggregateId, amount, date);

            RaiseEvent(paymentMadeEvent);
        }

        private bool IsInDebt()
        {
            return OutstandingDebt() > 0;
        }

        private void OnPaymentMade(PaymentMadeEvent @event)
        {
            _payments.Add(new Payment(@event.Amount, @event.Date));
        }

        private void OnUserFined(UserFinedEvent @event)
        {
            _fines.Add(new Fine(@event.LendingId, @event.Amount));
        }

        private void OnUserRegistered(UserRegisteredEvent @event)
        {
        }

        private decimal OutstandingDebt()
        {
            return _fines.Sum(x => x.Amount) - _payments.Sum(x => x.Amount);
        }

        private void RegisterEventHandlers()
        {
            Handles<UserRegisteredEvent>(OnUserRegistered);
            Handles<UserFinedEvent>(OnUserFined);
            Handles<PaymentMadeEvent>(OnPaymentMade);
        }
    }
}

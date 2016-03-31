namespace Lokf.Library.Infrastructure
{
    /// <summary>
    /// A decorator for the command handlers. Wraps the command execution in a transaction
    /// using a unit of work.
    /// </summary>
    /// <typeparam name="TCommand">The command type.</typeparam>
    public class TransactionalCommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        public readonly ICommandHandler<TCommand> _commandHandler;
        public readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionalCommandHandler{TCommand}"/> class.
        /// </summary>
        /// <param name="commandHandler">The command handler to wrap in a transaction.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        public TransactionalCommandHandler(ICommandHandler<TCommand> commandHandler, IUnitOfWork unitOfWork)
        {
            _commandHandler = commandHandler;

            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Executes the command, wrapped in a transaction by the unit of work.
        /// </summary>
        /// <param name="command">The command.</param>
        public void Handle(TCommand command)
        {
            try
            {
                _commandHandler.Handle(command);

                _unitOfWork.Commit();
            }
            catch
            {
                _unitOfWork.Rollback();

                throw;
            }
        }
    }
}

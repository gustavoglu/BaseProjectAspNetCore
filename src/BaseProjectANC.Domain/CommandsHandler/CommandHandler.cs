using BaseProjectANC.Domain.Core.Bus;
using BaseProjectANC.Domain.Core.Commands;
using BaseProjectANC.Domain.Core.UoW;
using BaseProjectANC.Domain.Core.Notifications;

namespace BaseProjectANC.Domain.CommandsHandler
{
    public class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IBus _bus;
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;


        public CommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications)
        {
            _uow = uow;
            _bus = bus;
            _notifications = notifications;
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                _bus.RaizeEvent(new DomainNotification(message.MessageType,error.ErrorMessage));
            }
        }

        public bool Commit()
        {
            if (_notifications.HasNotification()) return false;

            var commandResponse = _uow.Commit();

            if (commandResponse.Success) return true;

            _bus.RaizeEvent(new DomainNotification("Commit", "Algo deu errado ao atualizar o banco de dados"));

            return false;
        }

    }
}

using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BaseProjectANC.Domain.Core.Notifications;
using BaseProjectANC.Domain.Interfaces;
using BaseProjectANC.Domain.Core.Bus;

namespace BaseProjectANC.Services.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Base")]
    public class BaseController : Controller
    {
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;

        private readonly IBus _bus; 

        private readonly IUser _user;

        protected string userId { get { return _user.IsAuthenticated() ? _user.UserId : string.Empty; } }

        public BaseController(IBus bus,IUser user, IDomainNotificationHandler<DomainNotification> notifications)
        {
            _notifications = notifications;
            _user = user;
            _bus = bus;
        }

        protected new IActionResult Response(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notifications.GetNotifications().Select(n => n.Value)
            });
        }

        protected bool OperacaoValida()
        {
            return (!_notifications.HasNotification());
        }

        protected void NotificatErrosModelInvalida()
        {
            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                _bus.RaizeEvent(new DomainNotification(string.Empty,erro.ErrorMessage));
            }
        }

        protected void NotificarErro(string codigo, string mensagem)
        {
            _bus.RaizeEvent(new DomainNotification(codigo, mensagem));
        }
    }
}
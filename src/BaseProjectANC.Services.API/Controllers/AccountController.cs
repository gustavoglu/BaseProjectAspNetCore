using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseProjectANC.Domain.Core.Notifications;
using BaseProjectANC.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using BaseProjectANC.Infra.Identity.Models;
using Microsoft.Extensions.Logging;
using BaseProjectANC.Domain.Core.Bus;
using BaseProjectANC.Infra.Identity.Models.AccountViewModels;
using Microsoft.AspNetCore.Authorization;

namespace BaseProjectANC.Services.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signManager;
        private readonly ILogger _logger;

        public AccountController(IBus bus, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILoggerFactory loggerFactory, IUser user, IDomainNotificationHandler<DomainNotification> notifications) : base(bus, user, notifications)
        {
            _userManager = userManager;
            _signManager = signInManager;
            _logger = loggerFactory.CreateLogger<AccountController>();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Registrar-se")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid) { NotificatErrosModelInvalida(); return Response(model); }

            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                _logger.LogInformation(1, "Usuario criado com sucesso!");
                return Response(model);
            }

            AdicionarErrosIdentity(result);

            return Response(model);
        }

        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid) return Response(model);

            var result = await _signManager.PasswordSignInAsync(model.Email, model.Password, false, true);
            if (result.Succeeded)
            {
                _logger.LogInformation(1, "Usuario logado com sucesso");
                return Response(model);
            }

            NotificarErro(result.ToString(), "Falha ao realizar o Login");
            return Response(model);
        }

        private void AdicionarErrosIdentity(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                NotificarErro(result.ToString(), error.Description);
            }
        }

    }
}
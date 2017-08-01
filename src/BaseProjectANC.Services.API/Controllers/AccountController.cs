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
using Microsoft.Extensions.Options;
using BaseProjectANC.Infra.Identity.Authorization;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace BaseProjectANC.Services.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signManager;
        private readonly ILogger _logger;
        private readonly IBus Bus;
        private readonly JwtTokenOptions _jwtTokenOptions;

        public AccountController(IOptions<JwtTokenOptions> jwtTokenOptions, IBus bus, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILoggerFactory loggerFactory, IUser user, IDomainNotificationHandler<DomainNotification> notifications) : base(bus, user, notifications)
        {
            _userManager = userManager;
            _signManager = signInManager;
            _logger = loggerFactory.CreateLogger<AccountController>();
            Bus = bus;
            _jwtTokenOptions = jwtTokenOptions.Value;

            ThrowIfInvalidOptions(_jwtTokenOptions);
        }

        private static long ToUnixEpochDate(DateTime date) =>
            (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

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

        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid) return Response(model);

            var result = await _signManager.PasswordSignInAsync(model.Email, model.Password, false, true);
            if (result.Succeeded)
            {
                _logger.LogInformation(1, "Usuario logado com sucesso");
                var tokenResponse = ObterTokenUsuario(model);
                return Response(tokenResponse);
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

        private async Task<object> ObterTokenUsuario(LoginViewModel login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);
            var userClaims = await _userManager.GetClaimsAsync(user);

            userClaims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, await _jwtTokenOptions.JtiGenerator()));
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_jwtTokenOptions.IssueAt).ToString(),ClaimValueTypes.Integer64));

            var jwt = new JwtSecurityToken(
                issuer: _jwtTokenOptions.Issuer,
                audience: _jwtTokenOptions.Audience,
                claims: userClaims,
                notBefore: _jwtTokenOptions.NotBefore,
                expires: _jwtTokenOptions.Expiration,
                signingCredentials: _jwtTokenOptions.SigningCredentials);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                expirese_in = (int)_jwtTokenOptions.ValidFor.TotalSeconds,
                user = user,
            };

            return response;

        }

        private static void ThrowIfInvalidOptions(JwtTokenOptions options)
        {
            if (options == null) throw new ArgumentNullException(nameof(JwtTokenOptions));

            if (options.ValidFor <= TimeSpan.Zero)
            {
                throw new ArgumentException("Must be a non-zero TimeSpan.", nameof(JwtTokenOptions.ValidFor));
            }
            if (options.SigningCredentials == null)
            {
                throw new ArgumentNullException(nameof(JwtTokenOptions.SigningCredentials));
            }
            if (options.JtiGenerator == null)
            {
                throw new ArgumentNullException(nameof(JwtTokenOptions.SigningCredentials));
            }
        }

    }
}
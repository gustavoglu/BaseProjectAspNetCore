using BaseProjectANC.Domain.Interfaces;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using BaseProjectANC.Infra.Identity.Extensions;

namespace BaseProjectANC.Infra.Identity.Models
{
    public class AspNetUser : IUser
    {

        private readonly IHttpContextAccessor _accessor;

        public AspNetUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string UserName => _accessor.HttpContext.User.Identity.Name;

        public string UserId => IsAuthenticated() ? _accessor.HttpContext.User.GetUserId() : string.Empty;

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext.User.Claims;
        }

        public bool IsAuthenticated()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}

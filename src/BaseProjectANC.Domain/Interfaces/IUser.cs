using System.Collections.Generic;
using System.Security.Claims;

namespace BaseProjectANC.Domain.Interfaces
{
    public interface IUser
    {
        string UserName { get; }

        string UserId { get; }

        bool IsAuthenticated();

        IEnumerable<Claim> GetClaimsIdentity();
    }
}

using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace EmployeePlatform.Core.Security
{
    public interface IIdentityHelper
    {
        ClaimsPrincipal CreateIdentity(string Name, string Role, Dictionary<string, string> Claims = null);
        ClaimsPrincipal GetCurrentIdenity();
    }

    public class IdentityHelper : IIdentityHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IdentityHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ClaimsPrincipal CreateIdentity(string Name, string Role, Dictionary<string, string> Claims = null)
        {
            var identity = new ClaimsIdentity("aspnetcoreauth", Name, Role);

            identity.AddClaim(new Claim("UserName", Name));
            if (Claims != null)
            {
                foreach (var key in Claims.Keys)
                {
                    identity.AddClaim(new Claim(key, Claims[key]));
                }
            }

            return new ClaimsPrincipal(identity);
        }

        public ClaimsPrincipal GetCurrentIdenity()
        {
            return _httpContextAccessor.HttpContext.User as ClaimsPrincipal;
        }
    }
}
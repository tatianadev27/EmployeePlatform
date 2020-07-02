using EmployeePlatform.Entities;
using System.Security.Claims;

namespace EmployeePlatform
{
    public interface IIdentityHelper
    {
        ClaimsPrincipal CreateIdentity(string Name, string Role, AuthenticateResponseDTO user);
        string GetCurrentToken();
    }
}

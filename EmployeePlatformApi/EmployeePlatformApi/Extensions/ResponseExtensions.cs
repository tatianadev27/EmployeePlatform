using EmployeePlatform.GraphQLServer.Helpers;
using Microsoft.AspNetCore.Http;


namespace EmployeePlatformApi
{
    public static class ResponseExtensions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", Strings.RemoveAllNonPrintableCharacters(message));
            response.Headers.Add("access-control-expose-headers", "Application-Error");
        }
    }
}

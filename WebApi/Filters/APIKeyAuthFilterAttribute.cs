using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;

namespace WebApi.Filters
{
    public class APIKeyAuthFilterAttribute : Attribute, IAuthorizationFilter
    {
        private const string APIKeyHeader = "ApiKey";
        private const string ClientIdHeader = "ClientId";

        public void OnAuthorization(AuthorizationFilterContext context)
        {

            if (!context.HttpContext.Request.Headers.TryGetValue(ClientIdHeader, out var clientId))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (!context.HttpContext.Request.Headers.TryGetValue(APIKeyHeader, out var clientApiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var config = context.HttpContext.RequestServices.GetService(typeof(IConfiguration)) as IConfiguration;
            var apiKey = config.GetValue<string>($"ApiKey:{clientId}");

            if (apiKey != clientApiKey)
                context.Result = new UnauthorizedResult();


        }
    }
}

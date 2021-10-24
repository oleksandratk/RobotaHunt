using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RobotaHunt.Identity.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiBaseAuthAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            IdentityApiController controller = (IdentityApiController)context.Controller;

            // Checks if request header contains "Authorization" key
            if (!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                context.Result = controller.StatusCode(StatusCodes.Status401Unauthorized, "No Authorization key has been found");
                return;
            }

            // Checks if "Authorization" key is the same as in config
            var apiKeyFromHeader = AuthenticationHeaderValue.Parse(context.HttpContext.Request.Headers["Authorization"]);
            var apiKey = ""; //TODO get configs from ConfigurationManager.AppSettings["IdentityApiKey"];

            if (!apiKey.Equals(apiKeyFromHeader.Parameter))
            {
                context.Result = controller.StatusCode(StatusCodes.Status401Unauthorized, "Authorization key is incorrect");
                return;
            }

            await next();
        }
    }
}
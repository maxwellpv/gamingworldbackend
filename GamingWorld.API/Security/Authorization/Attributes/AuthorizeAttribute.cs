using System;
using System.Linq;
using GamingWorld.API.Security.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GamingWorld.API.Security.Authorization.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();

            // When Action is decorated with [AllowAnonymous] attribute
            // Then skip authorization process
            if (allowAnonymous)
                return;
            
            // Authorization Process
            var user = (User)context.HttpContext.Items["User"];
            
            // If user is null then Unauthorized Request    
            if (user == null)
                context.Result = new JsonResult(
                        new { message = "Unauthorized" })
                    { StatusCode = StatusCodes.Status401Unauthorized };

        }
    }
}
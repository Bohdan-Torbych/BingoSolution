using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace BingoAPI.Filters.TypeFilters;

/// <summary>
/// Represents an attribute that authorizes the user based on authentication status and username.
/// </summary>
public class AuthorizeUserAttribute : TypeFilterAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AuthorizeUserAttribute"/> class.
    /// </summary>
    public AuthorizeUserAttribute() : base(typeof(AuthorizeUserFilter))
    {
    }

    /// <summary>
    /// Represents the filter that performs the authorization logic.
    /// </summary>
    private sealed class AuthorizeUserFilter : IAsyncAuthorizationFilter
    {
        /// <summary>
        /// Performs the authorization logic.
        /// </summary>
        /// <param name="context">The authorization filter context.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var userName = context.HttpContext.User.Identity?.Name;

            if (string.IsNullOrEmpty(userName) || !(context.HttpContext.User.Identity?.IsAuthenticated ?? true))
            {
                context.Result = new UnauthorizedObjectResult("Username is null or you are not authorized");
            }

            return Task.CompletedTask;
        }
    }
}


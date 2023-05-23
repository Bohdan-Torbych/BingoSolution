using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BingoAPI.Filters.TypeFilters;

/// <summary>
/// Represents an attribute that ensures the user is not authenticated.
/// </summary>
public class UserNotAuthorizeAttribute : TypeFilterAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserNotAuthorizeAttribute"/> class.
    /// </summary>
    public UserNotAuthorizeAttribute() : base(typeof(UserNotAuthorize))
    {
    }

    /// <summary>
    /// Represents the filter that performs the authorization logic.
    /// </summary>
    private sealed class UserNotAuthorize : IAsyncAuthorizationFilter
    {
        /// <summary>
        /// Performs the authorization logic.
        /// </summary>
        /// <param name="context">The authorization filter context.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User.Identity?.IsAuthenticated ?? false)
                context.Result = new StatusCodeResult(405);

            return Task.CompletedTask;
        }
    }
}

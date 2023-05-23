using Microsoft.AspNetCore.Identity;

namespace BingoAPI.Core.Entities;

/// <summary>
/// Represents a user in the application.
/// </summary>
public class ApplicationUser : IdentityUser<Guid>
{
    /// <summary>
    /// Gets or sets the full name of the user.
    /// </summary>
    public string? FullName { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the user's game information is private.
    /// </summary>
    public bool IsGameInfoPrivate { get; set; } = false;

    /// <summary>
    /// Gets or sets the game schedule for the user.
    /// </summary>
    public DateTime? GameSchedule { get; set; }
}

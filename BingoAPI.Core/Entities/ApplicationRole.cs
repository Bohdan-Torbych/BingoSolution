using Microsoft.AspNetCore.Identity;

namespace BingoAPI.Core.Entities;

/// <summary>
/// Represents a users roles in the application.
/// </summary>
public class ApplicationRole : IdentityRole<Guid>
{
}

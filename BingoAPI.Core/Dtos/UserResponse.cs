namespace BingoAPI.Core.Dtos;

/// <summary>
/// Represents a DTO (Data Transfer Object) that represents a user.
/// </summary>
public class UserResponse
{
    /// <summary>
    /// Gets or sets the ID of the user.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the full name of the user.
    /// </summary>
    public string? FullName { get; set; }

    /// <summary>
    /// Gets or sets the username of the user.
    /// </summary>
    public string? UserName { get; set; }

    /// <summary>
    /// Gets or sets the phone number of the user.
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the user's game information is private.
    /// </summary>
    public bool IsGameInfoPrivate { get; set; }

    /// <summary>
    /// Gets or sets the game schedule for the user.
    /// </summary>
    public DateTime? GameSchedule { get; set; }
}


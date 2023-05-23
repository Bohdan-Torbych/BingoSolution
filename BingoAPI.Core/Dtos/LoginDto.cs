using System.ComponentModel.DataAnnotations;

namespace BingoAPI.Core.Dtos;

/// <summary>
/// Represents a DTO (Data Transfer Object) for user login.
/// </summary>
public class LoginDto
{
    /// <summary>
    /// Gets or sets the email address of the user.
    /// </summary>
    [Required(ErrorMessage = "{0} cannot be empty")]
    public string? Email { get; set; }

    /// <summary>
    /// Gets or sets the password of the user.
    /// </summary>
    [Required(ErrorMessage = "{0} cannot be empty")]
    public string? Password { get; set; }
}

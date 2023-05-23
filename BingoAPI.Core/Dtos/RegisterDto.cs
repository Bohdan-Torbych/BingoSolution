using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BingoAPI.Core.Dtos;

/// <summary>
/// Represents a DTO (Data Transfer Object) for user registration.
/// </summary>
public class RegisterDto
{
    /// <summary>
    /// Gets or sets the full name of the user.
    /// </summary>
    [Required(ErrorMessage = "{0} cannot be empty")]
    public string? FullName { get; set; }

    /// <summary>
    /// Gets or sets the email address of the user.
    /// </summary>
    [Required(ErrorMessage = "{0} cannot be empty")]
    [EmailAddress(ErrorMessage = "Invalid format of email address")]
    public string? Email { get; set; }

    /// <summary>
    /// Gets or sets the phone number of the user.
    /// </summary>
    [Phone]
    public string? Phone { get; set; }

    /// <summary>
    /// Gets or sets the password of the user.
    /// </summary>
    [Required(ErrorMessage = "{0} cannot be empty")]
    public string? Password { get; set; }

    /// <summary>
    /// Gets or sets the confirmation password of the user.
    /// </summary>
    [Required(ErrorMessage = "{0} cannot be empty")]
    [Compare("Password")]
    [DisplayName("Confirm password")]
    public string? ConfirmPassord { get; set; }
}


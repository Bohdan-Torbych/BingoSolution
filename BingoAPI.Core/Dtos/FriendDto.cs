using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BingoAPI.Core.Dtos;

/// <summary>
/// Represents a DTO (Data Transfer Object) for adding or accepting a friend.
/// </summary>
public class FriendDto
{
    /// <summary>
    /// Gets or sets the username of the friend.
    /// </summary>
    [Required(ErrorMessage = "{0} cannot be empty")]
    [DisplayName("Friend username")]
    public string? FriendUserName { get; set; }
}


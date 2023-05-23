using System.ComponentModel.DataAnnotations.Schema;

namespace BingoAPI.Core.Entities;

/// <summary>
/// Represents a friendship between two users.
/// </summary>
public class Friendship
{
    /// <summary>
    /// Gets or sets the ID of the user.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Gets or sets the ID of the friend.
    /// </summary>
    public Guid FriendId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the friendship is accepted.
    /// </summary>
    public bool IsAccepted { get; set; }

    /// <summary>
    /// Gets or sets the user associated with the friendship.
    /// </summary>
    [ForeignKey("UserId")]
    public virtual ApplicationUser? User { get; set; }

    /// <summary>
    /// Gets or sets the friend associated with the friendship.
    /// </summary>
    [ForeignKey("FriendId")]
    public virtual ApplicationUser? Friend { get; set; }
}

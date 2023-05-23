using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BingoAPI.Core.Dtos;

/// <summary>
/// Represents a DTO (Data Transfer Object) for game schedule.
/// </summary>
public class GameScheduleDto
{
    /// <summary>
    /// Gets or sets the game time.
    /// </summary>
    [Required(ErrorMessage = "{0} cannot be empty")]
    [DisplayName("Game Time")]
    public string? GameTime { get; set; }
}


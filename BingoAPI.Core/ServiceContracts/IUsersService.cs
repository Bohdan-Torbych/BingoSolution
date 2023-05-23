using BingoAPI.Core.Dtos;

namespace BingoAPI.Core.ServiceContracts;

/// <summary>
/// Represents a service for managing user-related operations.
/// </summary>
public interface IUsersService
{
    /// <summary>
    /// Retrieves all users.
    /// </summary>
    /// <returns>A list of UserResponse objects representing all users.</returns>
    Task<List<UserResponse>> GetAllUsers();

    /// <summary>
    /// Retrieves users ordered by their game schedule.
    /// </summary>
    /// <param name="userName">The username to filter the users.</param>
    /// <returns>A list of UserResponse objects representing the users ordered by game schedule.</returns>
    /// <exception cref="ArgumentException">If the user is not found by <param name="userName"></param></exception>
    Task<List<UserResponse>> GetUsersOrderedByGameSchedule(string userName);

    /// <summary>
    /// Retrieves users based on their game schedule and optional game time.
    /// If game time is null it filtered users by current UTC time.
    /// </summary>
    /// <param name="userName">The username to filter the users.</param>
    /// <param name="gameTime">The optional game time to filter the users.</param>
    /// <returns>A list of UserResponse objects representing the users matching the criteria.</returns>
    /// <exception cref="ArgumentException">If the user is not found by <param name="userName"></param></exception>
    /// <exception cref="ArgumentException">If <param name="gameTime"></param> was in wrong format</exception>
    Task<List<UserResponse>> GetMatchesGameSchedule(string userName, string? gameTime = null);

    /// <summary>
    /// Sets the game schedule for a user.
    /// </summary>
    /// <param name="username">The username of the user.</param>
    /// <param name="gameTime">The game time to set for the user.</param>
    /// <returns>A UserResponse object representing the user with the updated game schedule.</returns>
    /// <exception cref="ArgumentException">If the user is not found by <param name="userName"></param></exception>
    /// <exception cref="ArgumentException">If <param name="gameTime"></param> was in wrong format</exception>
    Task<UserResponse> SetGameSchedule(string username, string gameTime);

    /// <summary>
    /// Sets the game privacy for a user.
    /// </summary>
    /// <param name="username">The username of the user.</param>
    /// <param name="privacy">The privacy setting to set for the user.</param>
    /// <returns>A UserResponse object representing the user with the updated game privacy.</returns>
    /// <exception cref="ArgumentException">If the user is not found by <param name="userName"></param></exception>
    Task<UserResponse> SetGamePrivacy(string username, bool privacy);
}

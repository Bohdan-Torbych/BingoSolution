using BingoAPI.Core.Dtos;

namespace BingoAPI.Core.ServiceContracts;

/// <summary>
/// Represents a service for managing user friendships.
/// </summary>
public interface IFriendshipsService
{
    /// <summary>
    /// Retrieves all friends of a user by its username.
    /// </summary>
    /// <param name="username">The username of the user.</param>
    /// <returns>A list of UserResponse objects representing the user's friends.</returns>
    Task<List<UserResponse>> GetAllUserFriends(string username);

    /// <summary>
    /// Retrieves all friend requests received by a user.
    /// </summary>
    /// <param name="username">The username of the user.</param>
    /// <returns>A list of UserResponse objects representing the friend requests.</returns>
    /// <exception cref="ArgumentException">If the user is not found by <param name="username"></param></exception>
    Task<List<UserResponse>> GetAllFriendRequests(string username);

    /// <summary>
    /// Sends a friend request to another user.
    /// </summary>
    /// <param name="username">The username of the user sending the friend request.</param>
    /// <param name="friendUsername">The username of the user receiving the friend request.</param>
    /// <returns>True if the friend request was successfully sent, false otherwise.</returns>
    /// <exception cref="ArgumentException">If the user is not found by <param name="username"></param></exception>
    /// <exception cref="ArgumentException">If the user friend is not found by <param name="friendUsername"></param></exception>
    Task<bool> AddFriend(string username, string friendUsername);

    /// <summary>
    /// Accepts a friend request from another user.
    /// </summary>
    /// <param name="username">The username of the user accepting the friend request.</param>
    /// <param name="friendUsername">The username of the user who sent the friend request.</param>
    /// <returns>True if the friend request was successfully accepted, false otherwise.</returns>
    /// <exception cref="ArgumentException">If the user is not found by <param name="username"></param></exception>
    /// <exception cref="ArgumentException">If the user friend is not found by <param name="friendUsername"></param></exception>
    Task<bool> AcceptFriend(string username, string friendUsername);
}


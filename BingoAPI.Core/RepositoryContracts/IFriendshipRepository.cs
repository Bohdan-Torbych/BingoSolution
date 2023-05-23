using BingoAPI.Core.Entities;

namespace BingoAPI.Core.RepositoryContracts;

/// <summary>
/// Represents a repository for managing user friendships.
/// </summary>
public interface IFriendshipRepository
{
    /// <summary>
    /// Finds all friends of a user.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <returns>A list of friendship objects representing the user's friends.</returns>
    Task<List<Friendship>> FindAllUserFriends(Guid userId);

    /// <summary>
    /// Finds all friend requests received by a user.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <returns>A list of friendship objects representing the friend requests.</returns>
    Task<List<Friendship>> FindAllFriendRequests(Guid userId);

    /// <summary>
    /// Adds a friend to a user's friend list.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <param name="friendId">The ID of the friend to add.</param>
    /// <returns>True if the friend was successfully added, false otherwise.</returns>
    Task<bool> AddFriend(Guid userId, Guid friendId);

    /// <summary>
    /// Accepts a friend request from another user.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <param name="friendId">The ID of the user who sent the friend request.</param>
    /// <returns>True if the friend request was successfully accepted, false otherwise.</returns>
    Task<bool> AcceptFriend(Guid userId, Guid friendId);

    /// <summary>
    /// Checks if two users are friends.
    /// </summary>
    /// <param name="firstUser">The ID of the first user.</param>
    /// <param name="secondUser">The ID of the second user.</param>
    /// <returns>True if the users are friends, false otherwise.</returns>
    Task<bool> IsUsersFriends(Guid firstUser, Guid secondUser);
}

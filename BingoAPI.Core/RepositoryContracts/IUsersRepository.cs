using BingoAPI.Core.Entities;

namespace BingoAPI.Core.RepositoryContracts;

/// <summary>
/// Represents a repository for managing user data in the database.
/// </summary>
public interface IUsersRepository
{
    /// <summary>
    /// Saves user into DB
    /// </summary>
    /// <param name="user">The user's data to save</param>
    /// <param name="password">The user's password</param>
    /// <returns>The saved user object, or null if saving was not successful.</returns>
    Task<ApplicationUser?> SaveUser(ApplicationUser user, string password);

    /// <summary>
    /// Logs in a user into the system.
    /// </summary>
    /// <param name="email">The user's email.</param>
    /// <param name="password">The user's password.</param>
    /// <returns>The logged-in user object, or null if login was not successful.</returns>
    Task<ApplicationUser?> Login(string email, string password);

    /// <summary>
    /// Fully updates a user's data in the database.
    /// </summary>
    /// <param name="user">The new user data.</param>
    /// <returns>The updated user object, or null if updating was not successful.</returns>
    Task<ApplicationUser?> UpdateUser(ApplicationUser user);

    /// <summary>
    /// Retrieves all users from the database.
    /// </summary>
    /// <returns>A list of users.</returns>
    Task<List<ApplicationUser>> FindAllUsers();

    /// <summary>
    /// Finds a user by their email.
    /// </summary>
    /// <param name="email">The email to search for.</param>
    /// <returns>The user with the matching email, or null if not found.</returns>
    Task<ApplicationUser?> FindUserByEmail(string email);

    /// <summary>
    /// Signs out the user from the system.
    /// </summary>
    Task SignOut();
}

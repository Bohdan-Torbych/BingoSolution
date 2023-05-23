using BingoAPI.Core.Dtos;

namespace BingoAPI.Core.ServiceContracts;

/// <summary>
/// Represents a service for managing user accounts.
/// </summary>
public interface IAccountService
{
    /// <summary>
    /// Registers a new user.
    /// </summary>
    /// <param name="registerDto">The data for user registration.</param>
    /// <returns>A UserResponse object containing information about the registered user.</returns>
    /// <exception cref="ArgumentException">If user already exist with given email</exception>
    /// <exception cref="ArgumentException">If user register was not successful</exception>
    Task<UserResponse> Register(RegisterDto registerDto);

    /// <summary>
    /// Logs in a user.
    /// </summary>
    /// <param name="loginDto">The login credentials of the user.</param>
    /// <returns>A UserResponse object containing information about the logged-in user.</returns>
    /// <exception cref="ArgumentException">If user gave invalid email or password</exception>
    Task<UserResponse> Login(LoginDto loginDto);

    /// <summary>
    /// Signs out the user.
    /// </summary>
    Task SignOut();
}

namespace BingoAPI.Core.Exception;

/// <summary>
/// Represents an API exception.
/// </summary>
public class ApiException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApiException"/> class.
    /// </summary>
    /// <param name="statusCode">The HTTP status code associated with the exception.</param>
    /// <param name="message">The error message.</param>
    /// <param name="details">Additional details or information about the exception.</param>
    public ApiException(int statusCode, string message, string details)
    {
        StatusCode = statusCode;
        Message = message;
        Details = details;
    }

    /// <summary>
    /// Gets or sets the HTTP status code associated with the exception.
    /// </summary>
    public int StatusCode { get; set; }

    /// <summary>
    /// Gets or sets the error message.
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Gets or sets additional details or information about the exception.
    /// </summary>
    public string Details { get; set; }
}

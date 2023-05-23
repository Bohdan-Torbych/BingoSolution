using System.ComponentModel.DataAnnotations;

namespace BingoAPI.Core.ValidationHelper;

/// <summary>
/// Represents a model validator utility class.
/// </summary>
internal static class ModelValidator
{
    /// <summary>
    /// Validates the specified model object.
    /// </summary>
    /// <param name="model">The model object to validate.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="model"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when the validation of the model fails.</exception>
    public static void Validate(object? model)
    {
        if (model is null)
            throw new ArgumentNullException(nameof(model));

        ValidationContext validationContext = new ValidationContext(model);
        List<ValidationResult> validationResults = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(model, validationContext, validationResults, true);
        if (!isValid)
        {
            throw new ArgumentException(validationResults.FirstOrDefault()?.ErrorMessage);
        }
    }
}


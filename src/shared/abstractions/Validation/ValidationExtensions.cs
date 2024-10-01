using FluentValidation;

namespace MagCoders.Orders.Shared.Abstractions.Validation;

/// <summary>
/// Extensions for validators.
/// </summary>
public static class ValidationExtensions
{
	/// <summary>
	/// Wrapper function to run validation function inside ui form.
	/// </summary>
	/// <typeparam name="T">Type of model to validate.</typeparam>
	/// <param name="validator">Validator.</param>
	/// <returns>Function for validate.</returns>
	public static Func<object, string, Task<IEnumerable<string>>> GetValidateFunc<T>(this IValidator<T> validator) => async (model, propertyName) =>
	{
		if (model is not T)
		{
			throw new InvalidOperationException($"Validation of type {model.GetType().Name} is not supported by validator of type IValidator<{typeof(T).Name}>.");
		}

		var result = await validator.ValidateAsync(ValidationContext<T>.CreateWithOptions((T)model, x => x.IncludeProperties(propertyName)));
		if (result.IsValid)
		{
			return Array.Empty<string>();
		}

		return result.Errors.Select(e => e.ErrorMessage);
	};
}
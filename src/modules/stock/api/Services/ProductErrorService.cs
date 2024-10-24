using System.Security.Authentication;
using MagCoders.Orders.Shared.Infrastructure.Exceptions;

namespace MagCoders.Orders.Modules.Stock.Api.Services;

/// <summary>
/// Order service that shows how exceptions handled by global error handler should be thrown.
/// </summary>
public class ProductErrorService
{
	/// <summary>
	/// Initializes a new instance of the <see cref="ProductErrorService"/> class.
	/// </summary>
	public ProductErrorService()
	{
	}

	/// <summary>
	/// Method throwing AppExceptionError.
	/// </summary>
	/// <exception cref="AppException">Thrown when an application-specific error occurs, such as when a database operation fails.</exception>
	public void ThrowAppException()
	{
		throw new AppException(
			"e.g. \"An exception has been raised that is likely due to a transient failure." +
				"Consider enabling transient error resiliency by adding 'EnableRetryOnFailure' to the 'UseSqlServer' call.\"");
	}

	/// <summary>
	/// Method throwing AuthenticationException.
	/// </summary>
	/// <exception cref="AuthenticationException">
	/// Thrown when user authentication fails.
	/// </exception>
	public void ThrowAuthenticationException()
	{
		throw new AuthenticationException("Authentication failed: please provide valid credentials.");
	}

	/// <summary>
	/// Method throwing Exception.
	/// </summary>
	/// <exception cref="Exception">
	/// Thrown for any other unhandled exception.
	/// </exception>
	public void ThrowException()
	{
		throw new Exception("An unexpected error has occurred.");
	}

	/// <summary>
	/// Method throwing UnauthorizedAccessException.
	/// </summary>
	/// <exception cref="UnauthorizedAccessException">
	/// Thrown when a user is not authorized to access a resource.
	/// </exception>
	public void ThrowUnauthorizedAccessException()
	{
		throw new UnauthorizedAccessException("Access denied: you are not authorized to access this resource.");
	}
}
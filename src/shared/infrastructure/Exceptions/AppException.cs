using System.Globalization;

namespace MagCoders.Orders.Shared.Infrastructure.Exceptions;

/// <summary>
/// AppException class.
/// </summary>
public class AppException : Exception
{
	/// <summary>
	/// Initializes a new instance of the <see cref="AppException"/> class.
	/// </summary>
	public AppException()
		: base()
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="AppException"/> class.
	/// </summary>
	/// <param name="message">Error message.</param>
	/// <param name="args">Arguments.</param>
	public AppException(string message, params object[] args)
	: base(string.Format(CultureInfo.CurrentCulture, message, args))
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="AppException"/> class.
	/// </summary>
	/// <param name="message">Error message.</param>
	protected AppException(string? message)
		: base(message)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="AppException"/> class.
	/// </summary>
	/// <param name="message">Error message.</param>
	/// <param name="innerException">Inner exception.</param>
	protected AppException(string? message, Exception? innerException)
		: base(message, innerException)
	{
	}
}
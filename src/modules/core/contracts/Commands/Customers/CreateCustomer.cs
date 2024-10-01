namespace MagCoders.Orders.Modules.Core.Contracts.Commands.Customers;

/// <summary>
/// Create customer command.
/// </summary>
public class CreateCustomer
{
	/// <summary>
	/// Customer identifier.
	/// </summary>
	public Guid Id { get; set; }

	/// <summary>
	/// Customer first name.
	/// </summary>
	public string FirstName { get; set; } = null!;

	/// <summary>
	/// Customer second name.
	/// </summary>
	public string? SecondName { get; set; }

	/// <summary>
	/// Customer last name.
	/// </summary>
	public string LastName { get; set; } = null!;

	/// <summary>
	/// Customer credit card number.
	/// </summary>
	public string CreditCardNumber { get; set; } = null!;

	/// <summary>
	/// Customer email address.
	/// </summary>
	public string EmailAddress { get; set; } = null!;

	/// <summary>
	/// Customer birth date.
	/// </summary>
	public DateTime? BirthDate { get; set; }
}
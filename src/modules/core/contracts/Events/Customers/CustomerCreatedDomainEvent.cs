using MagCoders.Orders.Modules.Core.Contracts.ValueObjects;
using MagCoders.Orders.Shared.Infrastructure.Domain.ValueObjects;
using MagCoders.Orders.Shared.Infrastructure.Events;

namespace MagCoders.Orders.Modules.Core.Contracts.Events.Customers;

/// <summary>
/// Customer created domain event.
/// </summary>
public class CustomerCreatedDomainEvent : DomainEvent
{
	/// <summary>
	/// Initializes a new instance of the <see cref="CustomerCreatedDomainEvent"/> class.
	/// </summary>
	/// <param name="id">Customer identifier.</param>
	/// <param name="name">Customer name.</param>
	/// <param name="creditCard">Customer credit card data.</param>
	/// <param name="emailAddress">Email address.</param>
	/// <param name="birthDate">Birth date.</param>
	/// <param name="level">Customer level.</param>
	public CustomerCreatedDomainEvent(
		CustomerId id,
		CustomerName name,
		CreditCard creditCard,
		EmailAddress emailAddress,
		DateOnly birthDate,
		CustomerLevel level)
	{
		this.Id = id;
		this.Name = name;
		this.CreditCard = creditCard;
		this.EmailAddress = emailAddress;
		this.BirthDate = birthDate;
		this.Level = level;
	}

	/// <summary>
	/// Customer birth date.
	/// </summary>
	public DateOnly BirthDate { get; }

	/// <summary>
	/// Customer credit card data.
	/// </summary>
	public CreditCard CreditCard { get; }

	/// <summary>
	/// Customer name.
	/// </summary>
	public EmailAddress EmailAddress { get; }

	/// <summary>
	/// Customer identifier.
	/// </summary>
	public CustomerId Id { get; }

	/// <summary>
	/// Customer level.
	/// </summary>
	public CustomerLevel Level { get; }

	/// <summary>
	/// Customer name.
	/// </summary>
	public CustomerName Name { get; }
}
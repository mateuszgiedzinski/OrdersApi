using MagCoders.Orders.Modules.Core.Contracts.Events.Customers;
using MagCoders.Orders.Modules.Core.Contracts.ValueObjects;
using MagCoders.Orders.Shared.Infrastructure;
using MagCoders.Orders.Shared.Infrastructure.Domain;
using MagCoders.Orders.Shared.Infrastructure.Domain.ValueObjects;

namespace MagCoders.Orders.Modules.Core.Domain;

/// <summary>
/// Order of aggregate root.
/// </summary>
public class CustomerAggregate : Aggregate, IEntity<CustomerId>
{
	private CustomerAggregate()
	{
	}

	private CustomerAggregate(
		CustomerId id,
		CustomerName name,
		CreditCard creditCard,
		EmailAddress emailAddress,
		DateOnly birthDate,
		CustomerLevel level)
	{
		if (id.Value == Guid.Empty)
		{
			throw new InvalidOperationException("Id value cannot be empty!");
		}

		var customerCreated = new CustomerCreatedDomainEvent(id, name, creditCard, emailAddress, birthDate, level);
		this.Apply(customerCreated, this.Handle);
	}

	/// <summary>
	/// Birth date of the customer.
	/// </summary>
	public DateOnly BirthDate { get; private set; }

	/// <summary>
	/// Creation date.
	/// </summary>
	public DateTime CreatedOn { get; private set; }

	/// <summary>
	/// Customer credit card number.
	/// </summary>
	public CreditCard CreditCard { get; private set; }

	/// <summary>
	/// Email address.
	/// </summary>
	public EmailAddress EmailAddress { get; private set; }

	/// <summary>
	/// Customer identifier.
	/// </summary>
	public CustomerId Id { get; private set; }

	/// <summary>
	/// Level of the customer.
	/// </summary>
	public CustomerLevel Level { get; private set; }

	/// <summary>
	/// Customer name.
	/// </summary>
	public CustomerName Name { get; private set; }

	/// <summary>
	/// Create Order.
	/// </summary>
	/// <param name="id">Unique identifier.</param>
	/// <param name="name">Customer name.</param>
	/// <param name="creditCard">Customer credit card.</param>
	/// <param name="emailAddress">Customer email address.</param>
	/// <param name="birthDate">Customer birth date.</param>
	/// <returns>New aggregate.</returns>
	public static CustomerAggregate Create(
		Guid id,
		CustomerName name,
		CreditCard creditCard,
		EmailAddress emailAddress,
		DateOnly birthDate)
	{
		var customerId = new CustomerId(id);
		return new CustomerAggregate(customerId, name, creditCard, emailAddress, birthDate, CustomerLevels.New);
	}

	private void Handle(CustomerCreatedDomainEvent @event)
	{
		this.Id = @event.Id;
		this.Name = @event.Name;
		this.CreatedOn = @event.Timestamp;
		this.EmailAddress = @event.EmailAddress;
		this.CreditCard = @event.CreditCard;
		this.BirthDate = @event.BirthDate;
		this.CreatedOn = @event.Timestamp;
	}
}
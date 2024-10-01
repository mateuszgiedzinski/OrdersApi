using MagCoders.Orders.Modules.Core.Contracts.ValueObjects;
using MagCoders.Orders.Modules.Core.Domain;
using MagCoders.Orders.Shared.Abstractions.Commands;
using MagCoders.Orders.Shared.Abstractions.Domain;
using MagCoders.Orders.Shared.Infrastructure.Domain.ValueObjects;

namespace MagCoders.Orders.Modules.Core.Application.Customer.CreatingCustomer.CreatingCustomer;

/// <summary>
/// Create customer command.
/// </summary>
/// <param name="Id">Customer identifier.</param>
/// <param name="FirstName">Customer first name.</param>
/// <param name="SecondName">Customer second name.</param>
/// <param name="LastName">Customer last name.</param>
/// <param name="CreditCardNumber">Customer credit card number.</param>
/// <param name="EmailAddress">Customer email address.</param>
/// <param name="BirthDate">Customer birth date.</param>
public record CreateCustomer(
	Guid Id,
	string FirstName,
	string? SecondName,
	string LastName,
	string CreditCardNumber,
	string EmailAddress,
	DateOnly BirthDate) : ICommand;

/// <summary>
/// Create order command handler implementation.
/// </summary>
public class CreateCustomerHandler(IRepository<CustomerAggregate, CustomerId> repository) : ICommandHandler<CreateCustomer>
{
	/// <inheritdoc/>
	public async Task Handle(CreateCustomer command, CancellationToken cancellationToken)
	{
		var customerName = new CustomerName(command.FirstName, command.SecondName, command.LastName);
		var customer = CustomerAggregate.Create(
			command.Id,
			customerName,
			new CreditCard(command.CreditCardNumber),
			new EmailAddress(command.EmailAddress),
			command.BirthDate);

		await repository.Persist(customer);
	}
}
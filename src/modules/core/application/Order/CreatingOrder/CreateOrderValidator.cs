using FluentValidation;

using MagCoders.Orders.Modules.Core.Application.Customer.CreatingCustomer.CreatingCustomer;

namespace MagCoders.Orders.Modules.Core.Application.Order.CreatingOrder;

/// <summary>
/// Create order validator class.
/// </summary>
public class CreateOrderValidator : AbstractValidator<CreateCustomer>
{
	/// <summary>
	/// Initializes a new instance of the <see cref="CreateOrderValidator"/> class.
	/// </summary>
	public CreateOrderValidator()
	{
		this.RuleFor(example => example.Id)
		.NotNull()
		.NotEmpty();
	}
}
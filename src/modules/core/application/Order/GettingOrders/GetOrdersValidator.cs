using FluentValidation;

namespace MagCoders.Orders.Modules.Core.Application.Order.GettingOrders;

/// <summary>
/// GetOrdersValidator class.
/// </summary>
public class GetOrdersValidator : AbstractValidator<GetOrders>
{
	/// <summary>
	/// Initializes a new instance of the <see cref="GetOrdersValidator"/> class.
	/// </summary>
	public GetOrdersValidator()
	{
	}
}
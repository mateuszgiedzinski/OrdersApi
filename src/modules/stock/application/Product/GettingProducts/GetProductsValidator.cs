using FluentValidation;

namespace MagCoders.Orders.Modules.Stock.Application.Product.GettingProducts;

/// <summary>
/// GetProductsValidator class.
/// </summary>
public class GetProductsValidator : AbstractValidator<GetProducts>
{
	/// <summary>
	/// Initializes a new instance of the <see cref="GetProductsValidator"/> class.
	/// </summary>
	public GetProductsValidator()
	{
	}
}
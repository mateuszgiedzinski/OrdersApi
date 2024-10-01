using FluentValidation;

namespace MagCoders.Orders.Modules.Stock.Application.Product.CreatingProduct;

/// <summary>
/// Create order validator class.
/// </summary>
public class CreateProductValidator : AbstractValidator<CreateProduct>
{
	/// <summary>
	/// Initializes a new instance of the <see cref="CreateProductValidator"/> class.
	/// </summary>
	public CreateProductValidator()
	{
		this.RuleFor(example => example.Id).NotEmpty().NotNull();
		this.RuleFor(example => example.Name).NotEmpty().NotNull();
	}
}
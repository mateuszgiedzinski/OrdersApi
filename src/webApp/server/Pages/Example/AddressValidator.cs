using FluentValidation;

namespace MagCoders.Orders.Ui.Client.Pages.Example;

/// <summary>
/// Address validator.
/// </summary>
public class AddressValidator : AbstractValidator<Address>
{
	/// <summary>
	/// Initializes a new instance of the <see cref="AddressValidator"/> class.
	/// </summary>
	public AddressValidator()
	{
		this.RuleFor(p => p.Line1).NotEmpty().WithMessage("You must enter Line 1");
		this.RuleFor(p => p.Town).NotEmpty().WithMessage("You must enter a town");
		this.RuleFor(p => p.County).NotEmpty().WithMessage("You must enter a county");
		this.RuleFor(p => p.Postcode).NotEmpty().WithMessage("You must enter a postcode");
	}
}
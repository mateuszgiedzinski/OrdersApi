using FluentValidation;

namespace MagCoders.Orders.Modules.Core.Contracts.Commands.Customers;

/// <summary>
/// Create order validator class.
/// </summary>
public class CreateCustomerValidator : AbstractValidator<CreateCustomer>
{
	/// <summary>
	/// Initializes a new instance of the <see cref="CreateCustomerValidator"/> class.
	/// </summary>
	public CreateCustomerValidator()
	{
		this.RuleFor(customer => customer.Id)
		.NotEmpty()
		.NotNull();
		this.RuleFor(customer => customer.FirstName)
		.NotEmpty()
		.NotNull()
		.MaximumLength(64);
		this.RuleFor(customer => customer.LastName)
		.NotEmpty()
		.NotNull()
		.MaximumLength(64);
		this.RuleFor(x => x.SecondName)
			.Must((customer, secondName) => customer.FirstName != secondName)
			.WithErrorCode("ERR_20")
			.WithMessage("{PropertyName} cannot be equal to first name.")
			.When(x => x.FirstName != null && x.SecondName != null);
		this.RuleFor(customer => customer.CreditCardNumber)
		.NotEmpty()
		.NotNull()
		.CreditCard();
		this.RuleFor(customer => customer.EmailAddress)
		.NotEmpty()
		.NotNull()
		.EmailAddress();
		this.RuleFor(customer => customer.BirthDate)
		.LessThan(DateTime.UtcNow.AddYears(-18));
	}
}
using FluentValidation;

namespace MagCoders.Orders.Ui.Client.Pages.Example;

/// <summary>
/// Person validator.
/// </summary>
public class PersonValidator : AbstractValidator<Person>
{
	/// <summary>
	/// Initializes a new instance of the <see cref="PersonValidator"/> class.
	/// </summary>
	public PersonValidator()
	{
		this.RuleSet(
			"Names",
			() =>
			{
				this.RuleFor(p => p.FirstName)
				.NotEmpty()
				.WithMessage("You must enter your first name")
				.MaximumLength(50)
				.WithMessage("First name cannot be longer than 50 characters");

				this.RuleFor(p => p.LastName)
				.NotEmpty()
				.WithMessage("You must enter your last name")
				.MaximumLength(50)
				.WithMessage("Last name cannot be longer than 50 characters");
			});

		this.RuleFor(p => p.Age)
		.NotNull()
		.WithMessage("You must enter your age")
		.GreaterThanOrEqualTo(0)
		.WithMessage("Age must be greater than 0")
		.LessThan(150)
		.WithMessage("Age cannot be greater than 150");

		this.RuleFor(p => p.EmailAddress)
		.NotEmpty()
		.WithMessage("You must enter an email address")
		.EmailAddress()
		.WithMessage("You must provide a valid email address")
		.MustAsync(async (email, _) => await IsUniqueAsync(email))
		.WithMessage("Email address must be unique");

		this.RuleFor(p => p.Address).SetValidator(new AddressValidator());
	}

	private static async Task<bool> IsUniqueAsync(string? email)
	{
		await Task.Delay(300);
		return email?.ToLower() != "mail@my.com";
	}
}
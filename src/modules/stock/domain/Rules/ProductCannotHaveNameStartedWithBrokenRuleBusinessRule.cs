using MagCoders.Orders.Shared.Abstractions.Domain;

namespace MagCoders.Orders.Modules.Stock.Domain.Rules;

/// <summary>
/// Order rule.
/// </summary>
public class ProductCannotHaveNameStartedWithBrokenRuleBusinessRule : IBusinessRule
{
	private readonly string name;

	/// <summary>
	/// Initializes a new instance of the <see cref="ProductCannotHaveNameStartedWithBrokenRuleBusinessRule"/> class.
	/// </summary>
	/// <param name="name">Order name.</param>
	public ProductCannotHaveNameStartedWithBrokenRuleBusinessRule(string name)
	{
		this.name = name;
	}

	/// <inheritdoc/>
	public string RuleName => $"{nameof(ProductCannotHaveNameStartedWithBrokenRuleBusinessRule)}doesn't meet requirement";

	/// <inheritdoc/>
	public bool IsBroken()
	{
		return this.name.StartsWith("brokenRule");
	}
}
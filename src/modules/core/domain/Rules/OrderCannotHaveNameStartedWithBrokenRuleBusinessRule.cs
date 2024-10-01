using MagCoders.Orders.Shared.Abstractions.Domain;

namespace MagCoders.Orders.Modules.Core.Domain.Rules;

/// <summary>
/// Order rule.
/// </summary>
public class OrderCannotHaveNameStartedWithBrokenRuleBusinessRule : IBusinessRule
{
	private readonly string name;

	/// <summary>
	/// Initializes a new instance of the <see cref="OrderCannotHaveNameStartedWithBrokenRuleBusinessRule"/> class.
	/// </summary>
	/// <param name="name">Order name.</param>
	public OrderCannotHaveNameStartedWithBrokenRuleBusinessRule(string name)
	{
		this.name = name;
	}

	/// <inheritdoc/>
	public string RuleName => $"{nameof(OrderCannotHaveNameStartedWithBrokenRuleBusinessRule)}doesn't meet requirement";

	/// <inheritdoc/>
	public bool IsBroken()
	{
		return this.name.StartsWith("brokenRule");
	}
}
namespace MagCoders.Orders.Shared.Abstractions.Domain;

/// <summary>
/// Business rule interface.
/// </summary>
public interface IBusinessRule
{
	/// <summary>
	/// Business rule name.
	/// </summary>
	string RuleName { get; }

	/// <summary>
	/// Check business rule.
	/// </summary>
	/// <returns>Information if rule has been broken.</returns>
	bool IsBroken();
}
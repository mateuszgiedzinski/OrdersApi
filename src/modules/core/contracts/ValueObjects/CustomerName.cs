namespace MagCoders.Orders.Modules.Core.Contracts.ValueObjects;

/// <summary>
/// Represents customer name.
/// </summary>
/// <param name="FirstName">First name of the customer.</param>
/// <param name="SecondName">Second name.</param>
/// <param name="LastName">Surname of the customer.</param>
public record struct CustomerName(string FirstName, string? SecondName, string LastName)
{
	/// <summary>
	/// Formats name to string.
	/// </summary>
	/// <returns>String representing full name.</returns>
	public string Format()
	{
		return $"{this.FirstName} {this.SecondName} {this.LastName}";
	}

	/// <inheritdoc/>
	public override string ToString() => this.Format();
}
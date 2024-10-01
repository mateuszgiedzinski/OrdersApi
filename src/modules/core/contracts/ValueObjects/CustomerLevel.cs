namespace MagCoders.Orders.Modules.Core.Contracts.ValueObjects;

/// <summary>
/// Representation of customer level.
/// </summary>
/// <param name="Code">Customer level code.</param>
/// <param name="Name">Customer level name.</param>
public record struct CustomerLevel(int Code, string Name)
{
	/// <summary>
	/// Provides CustomerLevel based on code.
	/// </summary>
	/// <param name="levelCode">Level code value..</param>
	/// <returns>Representation of customer level.</returns>
	/// <exception cref="NotSupportedException">Throws not supported exception when invalid code passed.</exception>
	public static CustomerLevel CreateFromCode(int levelCode)
	{
		switch (levelCode)
		{
			case 1:
				return CustomerLevels.New;
			case 2:
				return CustomerLevels.Normal;
			case 3:
				return CustomerLevels.Premium;
			default:
				throw new NotSupportedException($"Customer level with code {levelCode} is not supported yet.");
		}
	}
}

/// <summary>
/// Static class to wrap possible values of customer level.
/// </summary>
public static class CustomerLevels
{
	/// <summary>
	/// Customer is new.
	/// </summary>
	public static readonly CustomerLevel New = new CustomerLevel(1, "New");

	/// <summary>
	/// Represents standard customer.
	/// </summary>
	public static readonly CustomerLevel Normal = new CustomerLevel(2, "Normal");

	/// <summary>
	/// Represents premium customer.
	/// </summary>
	public static readonly CustomerLevel Premium = new CustomerLevel(3, "Premium");
}
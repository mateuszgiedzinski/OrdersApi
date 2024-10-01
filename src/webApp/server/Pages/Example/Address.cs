namespace MagCoders.Orders.Ui.Client.Pages.Example;

/// <summary>
/// Class representing address.
/// </summary>
public class Address
{
	/// <summary>
	/// Country name.
	/// </summary>
	public string? County { get; set; }

	/// <summary>
	/// Get or sets line 1 of the address.
	/// </summary>
	public string? Line1 { get; set; }

	/// <summary>
	/// Get or sets line 2 of the address.
	/// </summary>
	public string? Line2 { get; set; }

	/// <summary>
	/// Get or sets post code.
	/// </summary>
	public string? Postcode { get; set; }

	/// <summary>
	/// Gets or sets town.
	/// </summary>
	public string? Town { get; set; }
}
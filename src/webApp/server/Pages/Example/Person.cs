namespace MagCoders.Orders.Ui.Client.Pages.Example;

/// <summary>
/// Class representing person.
/// </summary>
public class Person
{
	/// <summary>
	/// Gets or sets person first name.
	/// </summary>
	public string? FirstName { get; set; }

	/// <summary>
	/// Gets or sets last name.
	/// </summary>
	public string? LastName { get; set; }

	/// <summary>
	/// Gets or sets person age..
	/// </summary>
	public int? Age { get; set; }

	/// <summary>
	/// Gets or sets email address.
	/// </summary>
	public string? EmailAddress { get; set; }

	/// <summary>
	/// Gets or sets person address.
	/// </summary>
	public Address Address { get; set; } = new();
}
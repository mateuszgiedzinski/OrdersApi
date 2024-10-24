namespace MagCoders.Orders.Shared.Abstractions;

/// <summary>
/// Base class of collection response.
/// </summary>
/// <typeparam name="T">Type of elements in collection.</typeparam>
public class PagedList<T>
{
	/// <summary>
	/// List of items of generic type.
	/// </summary>
	public List<T> Items { get; set; } = null!;

	/// <summary>
	/// Total count of items.
	/// </summary>
	public int TotalCount { get; set; }
}
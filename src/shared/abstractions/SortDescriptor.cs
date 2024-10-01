namespace MagCoders.Orders.Shared.Abstractions;

/// <summary>
/// Sort criteria.
/// </summary>
public class SortDescriptor
{
	/// <summary>
	/// Column.
	/// </summary>
	public string ColumnName { get; set; } = null!;

	/// <summary>
	/// SortOrder.
	/// </summary>
	public bool SortAscending { get; set; }
}
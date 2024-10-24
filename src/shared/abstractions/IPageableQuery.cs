namespace MagCoders.Orders.Shared.Abstractions;

/// <summary>
/// Paging criteria.
/// </summary>
public interface IPageableQuery
{
	/// <summary>
	/// Page size.
	/// </summary>
	int PageSize { get; set; }

	/// <summary>
	/// Page index.
	/// </summary>
	int PageIndex { get; set; }
}
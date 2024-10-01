namespace MagCoders.Orders.Shared.Abstractions;

/// <summary>
/// Text search interface.
/// </summary>
public interface ITextSearchQuery
{
	/// <summary>
	/// Search text.
	/// </summary>
	string? Search { get; set; }
}
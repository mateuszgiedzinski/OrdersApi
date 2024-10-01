namespace MagCoders.Orders.Shared.Infrastructure;

/// <summary>
/// Entity id interface.
/// </summary>
/// <typeparam name="TKey">Key.</typeparam>
public interface IEntityId<TKey>
{
	/// <summary>
	/// Entity id.
	/// </summary>
	public TKey Value { get; }
}
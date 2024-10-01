using Microsoft.Extensions.DependencyInjection;

namespace MagCoders.Orders.Shared.Abstractions.Attributes;

/// <summary>
/// Attribute defines the lifetime of the registered class.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class LifetimeAttribute : Attribute
{
	/// <summary>
	/// Lifetime of the registered class.
	/// </summary>
	public ServiceLifetime Lifetime { get; set; }
}
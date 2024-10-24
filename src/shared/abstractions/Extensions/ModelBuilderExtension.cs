using System.Reflection;

using Microsoft.EntityFrameworkCore;

namespace MagCoders.Orders.Shared.Abstractions.Extensions;

/// <summary>
/// Define extension methods for DBContext modelbuilder.
/// </summary>
public static class ModelBuilderExtension
{
	/// <summary>
	/// Applies all entities configurations from given assemblies.
	/// </summary>
	/// <param name="modelBuilder">Model builder.</param>
	/// <param name="assemblies">Assemblies to apply configs from.</param>
	public static void ApplyAllConfigurationsFromAssemblies(this ModelBuilder modelBuilder, params Assembly[] assemblies)
	{
		foreach (var assembly in assemblies)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(assembly);
		}
	}
}
using MagCoders.Orders.Modules.Core.Domain;
using MagCoders.Orders.Shared.Abstractions.Extensions;
using MagCoders.Orders.Shared.Domain;

using Microsoft.EntityFrameworkCore;

namespace MagCoders.Orders.Modules.Core.Infrastructure.Data;

/// <summary>
/// Database context.
/// </summary>
public class CoreDbContext : DbContext
{
	/// <summary>
	/// Initializes a new instance of the <see cref="CoreDbContext"/> class.
	/// </summary>
	/// <param name="options">DbContext options.</param>
	public CoreDbContext(DbContextOptions<CoreDbContext> options)
		: base(options)
	{
	}

	/// <summary>
	/// Domain Event Store DbSet.
	/// </summary>
	public DbSet<DomainEventStore> DomainEventStore { get; set; }

	/// <summary>
	/// Order aggregate DbSet.
	/// </summary>
	public DbSet<OrderAggregate> Orders { get; set; }

	/// <summary>
	/// Customer aggregate DbSet.
	/// </summary>
	public DbSet<CustomerAggregate> Customers { get; set; }

	/// <inheritdoc/>
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyAllConfigurationsFromAssemblies(typeof(CoreDbContext).Assembly);
		base.OnModelCreating(modelBuilder);
	}
}
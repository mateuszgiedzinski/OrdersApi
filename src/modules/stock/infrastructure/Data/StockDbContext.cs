using MagCoders.Orders.Modules.Stock.Domain;
using MagCoders.Orders.Shared.Abstractions.Extensions;
using MagCoders.Orders.Shared.Domain;

using Microsoft.EntityFrameworkCore;

namespace MagCoders.Orders.Modules.Stock.Infrastructure.Data;

/// <summary>
/// Database context.
/// </summary>
public class StockDbContext : DbContext
{
	/// <summary>
	/// Initializes a new instance of the <see cref="StockDbContext"/> class.
	/// </summary>
	/// <param name="options">DbContext options.</param>
	public StockDbContext(DbContextOptions<StockDbContext> options)
		: base(options)
	{
	}

	/// <summary>
	/// Domain Event Store DbSet.
	/// </summary>
	public DbSet<DomainEventStore> DomainEventStore { get; set; }

	/// <summary>
	/// OrderAggregate DbSet.
	/// </summary>
	public DbSet<ProductAggregate> Products { get; set; }

	/// <inheritdoc/>
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyAllConfigurationsFromAssemblies(typeof(StockDbContext).Assembly);
		base.OnModelCreating(modelBuilder);
	}
}
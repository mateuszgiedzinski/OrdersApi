using MagCoders.Orders.Modules.Stock.Contracts.ValueObjects;
using MagCoders.Orders.Modules.Stock.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MagCoders.Orders.Modules.Stock.Infrastructure.Data.DataConfiguration;

/// <summary>
/// Order Aggregate Configuration.
/// </summary>
internal class ProductAggregateEntityConfiguration : IEntityTypeConfiguration<ProductAggregate>
{
	/// <summary>
	/// Configure method.
	/// </summary>
	/// <param name="builder">builder.</param>
	public void Configure(EntityTypeBuilder<ProductAggregate> builder)
	{
		builder.HasKey(x => x.Id);
		builder.ToTable("Product", "Stock");
		builder.Property(x => x.Id)
		.HasColumnName("Id")
		.HasConversion(ProductConverters.ProductIdConverter());
		builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(256);
		builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn");
	}
}
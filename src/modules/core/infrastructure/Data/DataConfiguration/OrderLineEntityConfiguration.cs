using MagCoders.Orders.Modules.Core.Contracts.ValueObjects;
using MagCoders.Orders.Modules.Core.Domain;
using MagCoders.Orders.Modules.Stock.Contracts.ValueObjects;
using MagCoders.Orders.Shared.Infrastructure.Domain;
using MagCoders.Orders.Shared.Infrastructure.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MagCoders.Orders.Modules.Core.Infrastructure.Data.DataConfiguration;

/// <summary>
/// Order Aggregate Configuration.
/// </summary>
internal class OrderLineEntityConfiguration : IEntityTypeConfiguration<OrderLine>
{
	/// <summary>
	/// Configure method.
	/// </summary>
	/// <param name="builder">builder.</param>
	public void Configure(EntityTypeBuilder<OrderLine> builder)
	{
		builder.HasKey(x => x.Id);
		builder.ToTable("OrderLine", "Core");
		builder.Property(x => x.Id)
		.HasColumnName("Id")
		.HasConversion(OrderConverters.OrderLineIdConverter());
		builder.Property(x => x.OrderId)
		.HasColumnName("OrderId")
		.HasConversion(OrderConverters.OrderIdConverter());

		builder.Property(x => x.Quantity)
		.HasConversion(SharedConverters.QuantityConverter());

		builder.ComplexProperty(
			x => x.OriginalUnitPrice,
			moneyEntityBuilder =>
			{
				moneyEntityBuilder.Property(x => x.Value)
				.HasColumnName("OriginalUnitPrice_Value")
				.IsRequired();
				moneyEntityBuilder.Property(x => x.Currency)
				.HasConversion(new EnumToStringConverter<Currency>())
				.HasColumnName("OriginalUnitPrice_Currency")
				.IsRequired();
			});

		builder.ComplexProperty(
			x => x.UnitPrice,
			moneyEntityBuilder =>
			{
				moneyEntityBuilder.Property(x => x.Value)
				.HasColumnName("UnitPrice_Value")
				.IsRequired();
				moneyEntityBuilder.Property(x => x.Currency)
				.HasConversion(new EnumToStringConverter<Currency>())
				.HasColumnName("UnitPrice_Currency")
				.IsRequired();
			});

		builder.ComplexProperty(
			x => x.Price,
			moneyEntityBuilder =>
			{
				moneyEntityBuilder.Property(x => x.Value)
				.HasColumnName("Price_Value")
				.IsRequired();
				moneyEntityBuilder.Property(x => x.Currency)
				.HasConversion(new EnumToStringConverter<Currency>())
				.HasColumnName("Price_Currency")
				.IsRequired();
			});

		builder.Property(x => x.Product)
		.HasConversion(ProductConverters.ProductIdConverter());

		builder.Property(x => x.Discount)
		.HasConversion(OrderConverters.DiscountConverter())
		.HasPrecision(5, 4)
		.HasColumnType("decimal(5,4)");
	}
}
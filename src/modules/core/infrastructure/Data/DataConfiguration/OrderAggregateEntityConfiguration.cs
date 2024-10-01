using MagCoders.Orders.Modules.Core.Contracts.ValueObjects;
using MagCoders.Orders.Modules.Core.Domain;
using MagCoders.Orders.Shared.Infrastructure.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MagCoders.Orders.Modules.Core.Infrastructure.Data.DataConfiguration;

/// <summary>
/// Order Aggregate Configuration.
/// </summary>
internal class OrderAggregateEntityConfiguration : IEntityTypeConfiguration<OrderAggregate>
{
	/// <summary>
	/// Configure method.
	/// </summary>
	/// <param name="builder">builder.</param>
	public void Configure(EntityTypeBuilder<OrderAggregate> builder)
	{
		builder.HasKey(x => x.Id);
		builder.ToTable("Order", "Core");
		builder.Property(x => x.Id)
		.HasColumnName("Id")
		.HasConversion(OrderConverters.OrderIdConverter());
		builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn");
		builder.Property(x => x.State)
			.HasColumnName("State")
			.HasConversion(OrderConverters.OrderStateConverter());
		builder.Property(x => x.CustomerId)
			.HasColumnName("CustomerId")
			.HasConversion(CustomerConverters.CustomerIdConverter());
		builder.Property(x => x.Note)
			.HasColumnName("Note")
			.HasMaxLength(500);

		builder.Property(x => x.CreatedOn)
			.HasColumnName("CreatedOn")
			.IsRequired();

		builder.ComplexProperty(x => x.Overall, moneyEntityBuilder =>
		{
			moneyEntityBuilder.Property(x => x.Value).HasColumnName("Overall_Value")
				.IsRequired();
			moneyEntityBuilder.Property(x => x.Currency)
			.HasConversion(new EnumToStringConverter<Currency>())
			.HasColumnName("Overall_Currency")
				.IsRequired();
		});

		builder.HasMany(x => x.OrderLines)
			.WithOne()
			.HasForeignKey(x => x.OrderId);
	}
}
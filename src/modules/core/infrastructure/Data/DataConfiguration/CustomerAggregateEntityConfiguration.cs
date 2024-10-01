using MagCoders.Orders.Modules.Core.Contracts.ValueObjects;
using MagCoders.Orders.Modules.Core.Domain;
using MagCoders.Orders.Shared.Infrastructure.Domain.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MagCoders.Orders.Modules.Core.Infrastructure.Data.DataConfiguration;

/// <summary>
/// Order Aggregate Configuration.
/// </summary>
internal class CustomerAggregateEntityConfiguration : IEntityTypeConfiguration<CustomerAggregate>
{
	/// <summary>
	/// Configure method.
	/// </summary>
	/// <param name="builder">builder.</param>
	public void Configure(EntityTypeBuilder<CustomerAggregate> builder)
	{
		builder.HasKey(x => x.Id);
		builder.ToTable("Customer", "Core");
		builder.Property(x => x.Id)
		.HasColumnName("Id")
		.HasConversion(CustomerConverters.CustomerIdConverter());
		builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn").IsRequired();
		builder.ComplexProperty(
			x => x.Name,
			nameBuilder =>
			{
				nameBuilder.Property(x => x.FirstName).HasColumnName("FirstName").IsRequired();
				nameBuilder.Property(x => x.SecondName).HasColumnName("SecondName").IsRequired(false);
				nameBuilder.Property(x => x.LastName).HasColumnName("LastName").IsRequired();
			});
		builder.Property(x => x.Level)
		.HasColumnName("Level")
		.HasConversion(CustomerConverters.CustomerLevelConverter())
		.IsRequired();
		builder.Property(x => x.CreditCard)
		.HasColumnName("CreditCard")
		.HasConversion(SharedConverters.CreditCardConverter())
		.IsRequired();

		builder.Property(x => x.EmailAddress)
		.HasColumnName("EmailAddress")
		.HasConversion(SharedConverters.EmailConverter())
		.IsRequired();

		builder.Property(x => x.BirthDate)
		.HasColumnName("BirthDate")
		.IsRequired();
	}
}
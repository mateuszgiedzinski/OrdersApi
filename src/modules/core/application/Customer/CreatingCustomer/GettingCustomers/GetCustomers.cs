using MagCoders.Orders.Modules.Core.Contracts.Dto;
using MagCoders.Orders.Modules.Core.Infrastructure.Data;
using MagCoders.Orders.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace MagCoders.Orders.Modules.Core.Application.Customer.CreatingCustomer.GettingCustomers;

/// <summary>
/// Get customers query.
/// </summary>
public record GetCustomers() : IQuery<CustomerInfo[]>;

/// <summary>
/// Get customers query handler implementation.
/// </summary>
public class GetCustomersQueryrHandler(CoreDbContext dbContext)
	: IQueryHandler<GetCustomers, CustomerInfo[]>
{
	/// <inheritdoc/>
	public async Task<CustomerInfo[]> Handle(GetCustomers query, CancellationToken cancellationToken)
	{
		var result = await dbContext.Customers
						.Select(
							x => new CustomerInfo(
								x.Id,
								x.Name,
								x.CreditCard,
								x.EmailAddress,
								x.BirthDate,
								x.Level))
						.AsNoTracking()
						.ToArrayAsync();
		return result;
	}
}
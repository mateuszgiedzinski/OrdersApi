using MagCoders.Orders.Modules.Stock.Application.Product.Mappers;
using MagCoders.Orders.Modules.Stock.Infrastructure.Data;
using MagCoders.Orders.Shared.Abstractions;
using MagCoders.Orders.Shared.Abstractions.Queries;

using Microsoft.EntityFrameworkCore;

namespace MagCoders.Orders.Modules.Stock.Application.Product.GettingProducts;

/// <summary>
/// Get orders query.
/// </summary>
public record GetProducts() : IQuery<PagedList<ProductInfo>>;

/// <summary>
/// Get orders handler.
/// </summary>
public class GetProductsQueryHandler : IQueryHandler<GetProducts, PagedList<ProductInfo>>
{
	private readonly StockDbContext stockDbContext;

	/// <summary>
	/// Initializes a new instance of the <see cref="GetProductsQueryHandler"/> class.
	/// </summary>
	/// <param name="stockDbContext">Product dbContext.</param>
	public GetProductsQueryHandler(StockDbContext stockDbContext)
	{
		this.stockDbContext = stockDbContext;
	}

	/// <summary>
	/// GetProducts query handler.
	/// </summary>
	/// <param name="query">Query.</param>
	/// <param name="cancellationToken">Cancellation token.</param>
	/// <returns>Paged list of examples.</returns>
	public async Task<PagedList<ProductInfo>> Handle(GetProducts query, CancellationToken cancellationToken)
	{
		var examples = await this.stockDbContext.Products.OrderBy(x => x.Id).ToListAsync();
		var mappedData = examples.Select(ProductAggregateProductInfoMapper.Map).ToList();
		var result = new PagedList<ProductInfo> { Items = mappedData };
		return result;
	}
}
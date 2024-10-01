namespace MagCoders.Orders.Modules.Stock.Application.Product.GettingProducts;

/// <summary>
/// Product information.
/// </summary>
/// <param name="Id">Order ID.</param>
/// <param name="Name">Name of order.</param>
/// <param name="CreatedOn">Created Date.</param>
public record ProductInfo(Guid Id, string Name, DateTime CreatedOn);
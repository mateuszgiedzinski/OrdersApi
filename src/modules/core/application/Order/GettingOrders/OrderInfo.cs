namespace MagCoders.Orders.Modules.Core.Application.Order.GettingOrders;

/// <summary>
/// Order information.
/// </summary>
/// <param name="Id">Order ID.</param>
/// <param name="Name">Name of order.</param>
/// <param name="CreatedOn">Created Date.</param>
public record OrderInfo(Guid Id, string Name, DateTime CreatedOn);
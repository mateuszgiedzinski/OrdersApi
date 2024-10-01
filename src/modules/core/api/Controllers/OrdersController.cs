using FluentValidation;
using MagCoders.Orders.Modules.Core.Application.Customer.CreatingCustomer.CreatingCustomer;
using MagCoders.Orders.Modules.Core.Application.Order.GettingOrders;
using MagCoders.Orders.Shared.Abstractions;
using MagCoders.Orders.Shared.Abstractions.Commands;
using MagCoders.Orders.Shared.Abstractions.Errors;

using MagCoders.Orders.Shared.Abstractions.Queries;
using MagCoders.Orders.Shared.Infrastructure.Exceptions;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagCoders.Orders.Modules.Core.Api.Controllers;

/// <summary>
/// Order controller.
/// </summary>
[ApiController]
[Route("orders")]
public class OrdersController : ControllerBase
{
	private readonly ICommandBus commandBus;

	private readonly IValidator<CreateCustomer> createOrderValidator;

	private readonly IValidator<GetOrders> getOrdersValidator;

	private readonly IQueryBus queryBus;

	/// <summary>
	/// Initializes a new instance of the <see cref="OrdersController"/> class.
	/// </summary>
	/// <param name="commandBus">Command bus.</param>
	/// <param name="queryBus">Query bus.</param>
	/// <param name="createOrderValidator">Create order validator.</param>
	/// <param name="getOrdersValidator">Get order validator.</param>
	public OrdersController(
		ICommandBus commandBus,
		IQueryBus queryBus,
		IValidator<CreateCustomer> createOrderValidator,
		IValidator<GetOrders> getOrdersValidator)
	{
		this.createOrderValidator = createOrderValidator;
		this.getOrdersValidator = getOrdersValidator;
		this.commandBus = commandBus;
		this.queryBus = queryBus;
	}

	/// <summary>
	/// Creates order.
	/// </summary>
	/// <param name="request">Request.</param>
	/// <returns>Created Result.</returns>
	/// <remarks>
	/// Sample request: POST { "Id" : "3fa85f64-5717-4562-b3fc-2c963f66afa6", "Name": "Order" } .
	/// </remarks>
	/// <response code="201">Returns the newly created item.</response>
	/// <response code="400">If the body is not valid.</response>
	/// <response code="401">If the user is unauthorized.</response>
	[ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
	[ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
	[HttpPost]
	public async Task<IActionResult> CreateOrder([FromBody] CreateCustomer request)
	{
		var validationResult = await this.createOrderValidator.ValidateAsync(request);
		if (validationResult.IsValid)
		{
			await this.commandBus.Send(request);
			return this.Created($"example/{request.Id}", request.Id);
		}

		throw new AppException("One or more error occurred when trying to create example.", validationResult.Errors);
	}

	/// <summary>
	/// Get orders.
	/// </summary>
	/// <param name="request">Query parameters.</param>
	/// <returns>Paged list of examples.</returns>
	/// <response code="200">Returns the list of examples corresponding to the query.</response>
	/// <response code="400">If the query is not valid.</response>
	/// <response code="401">If the user is unauthorized.</response>
	[HttpGet]
	[ProducesResponseType(typeof(PagedList<OrderInfo>), StatusCodes.Status200OK)]
	[ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
	public async Task<IActionResult> GetOrders([FromQuery] GetOrders request)
	{
		var validationResult = await this.getOrdersValidator.ValidateAsync(request);
		if (validationResult.IsValid)
		{
			var pagedList = await this.queryBus.Query<GetOrders, PagedList<OrderInfo>>(request);

			return this.Ok(pagedList);
		}

		throw new AppException("One or more error occurred when trying to get orders.", validationResult.Errors);
	}
}
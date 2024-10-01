using FluentValidation;
using MagCoders.Orders.Modules.Stock.Application.Product.CreatingProduct;
using MagCoders.Orders.Modules.Stock.Application.Product.GettingProducts;
using MagCoders.Orders.Shared.Abstractions;
using MagCoders.Orders.Shared.Abstractions.Commands;
using MagCoders.Orders.Shared.Abstractions.Errors;

using MagCoders.Orders.Shared.Abstractions.Queries;
using MagCoders.Orders.Shared.Infrastructure.Exceptions;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagCoders.Orders.Modules.Stock.Api.Controllers;

/// <summary>
/// Product controller.
/// </summary>
[ApiController]
[Route("Products")]
public class ProductsController : ControllerBase
{
	private readonly ICommandBus commandBus;

	private readonly IValidator<CreateProduct> createProductValidator;

	private readonly IValidator<GetProducts> getProductsValidator;

	private readonly IQueryBus queryBus;

	/// <summary>
	/// Initializes a new instance of the <see cref="ProductsController"/> class.
	/// </summary>
	/// <param name="commandBus">Command bus.</param>
	/// <param name="queryBus">Query bus.</param>
	/// <param name="createProductValidator">Create Product validator.</param>
	/// <param name="getProductsValidator">Get Product validator.</param>
	public ProductsController(
		ICommandBus commandBus,
		IQueryBus queryBus,
		IValidator<CreateProduct> createProductValidator,
		IValidator<GetProducts> getProductsValidator)
	{
		this.createProductValidator = createProductValidator;
		this.getProductsValidator = getProductsValidator;
		this.commandBus = commandBus;
		this.queryBus = queryBus;
	}

	/// <summary>
	/// Creates Product.
	/// </summary>
	/// <param name="request">Request.</param>
	/// <returns>Created Result.</returns>
	/// <remarks>
	/// Sample request: POST { "Id" : "3fa85f64-5717-4562-b3fc-2c963f66afa6", "Name": "Product" } .
	/// </remarks>
	/// <response code="201">Returns the newly created item.</response>
	/// <response code="400">If the body is not valid.</response>
	/// <response code="401">If the user is unauthorized.</response>
	[ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
	[ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
	[HttpPost]
	public async Task<IActionResult> CreateProduct([FromBody] CreateProduct request)
	{
		var validationResult = await this.createProductValidator.ValidateAsync(request);
		if (validationResult.IsValid)
		{
			await this.commandBus.Send(request);
			return this.Created($"example/{request.Id}", request.Id);
		}

		throw new AppException("One or more error occurred when trying to create example.", validationResult.Errors);
	}

	/// <summary>
	/// Get Products.
	/// </summary>
	/// <param name="request">Query parameters.</param>
	/// <returns>Paged list of examples.</returns>
	/// <response code="200">Returns the list of examples corresponding to the query.</response>
	/// <response code="400">If the query is not valid.</response>
	/// <response code="401">If the user is unauthorized.</response>
	[HttpGet]
	[ProducesResponseType(typeof(PagedList<ProductInfo>), StatusCodes.Status200OK)]
	[ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
	public async Task<IActionResult> GetProducts([FromQuery] GetProducts request)
	{
		var validationResult = await this.getProductsValidator.ValidateAsync(request);
		if (validationResult.IsValid)
		{
			var pagedList = await this.queryBus.Query<GetProducts, PagedList<ProductInfo>>(request);

			return this.Ok(pagedList);
		}

		throw new AppException("One or more error occurred when trying to get Products.", validationResult.Errors);
	}
}
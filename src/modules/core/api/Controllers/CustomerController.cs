using FluentValidation;
using MagCoders.Orders.Modules.Core.Application.Customer.CreatingCustomer.CreatingCustomer;
using MagCoders.Orders.Modules.Core.Application.Customer.CreatingCustomer.GettingCustomers;
using MagCoders.Orders.Modules.Core.Contracts.Dto;
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
/// <remarks>
/// Initializes a new instance of the <see cref="CustomerController"/> class.
/// </remarks>
[ApiController]
[Route("customers")]
public class CustomerController : ControllerBase
{
	private readonly ICommandBus commandBus;

	private readonly IValidator<CreateCustomer> createCustomerValidator;

	private readonly IQueryBus queryBus;

	/// <summary>
	/// Initializes a new instance of the <see cref="CustomerController"/> class.
	/// </summary>
	/// <param name="commandBus">Command bus.</param>
	/// <param name="queryBus">Instance of query bus.</param>
	/// <param name="createCustomerValidator">Create customer validator.</param>
	public CustomerController(
		ICommandBus commandBus,
		IQueryBus queryBus,
		IValidator<CreateCustomer> createCustomerValidator)
	{
		this.queryBus = queryBus;
		this.createCustomerValidator = createCustomerValidator;
		this.commandBus = commandBus;
	}

	/// <summary>
	/// Get customers list.
	/// </summary>
	/// <returns>Created Result.</returns>
	/// <remarks>
	/// Sample request: POST { "Id": "3fa85f64-5717-4562-b3fc-2c963f66afa6", "FirstName": "John", "SecondName": "A.",
	/// "LastName": "Doe", "CreditCardNumber": "4111111111111111", "EmailAddress": "john.doe@example.com", "BirthDate":
	/// "1990-01-01" } .
	/// </remarks>
	/// <response code="201">Returns the newly created item.</response>
	/// <response code="400">If the body is not valid.</response>
	/// <response code="401">If the user is unauthorized.</response>
	[ProducesResponseType(typeof(CustomerInfo[]), StatusCodes.Status200OK)]
	[ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
	[HttpGet]
	public async Task<IActionResult> GetCustomer()
	{
		var request = new GetCustomers();
		var response = await this.queryBus.Query<GetCustomers, CustomerInfo[]>(request);
		return this.Ok(response);
	}

	/// <summary>
	/// Creates customer.
	/// </summary>
	/// <param name="request">Request.</param>
	/// <returns>Created Result.</returns>
	/// <remarks>
	/// Sample request: POST { "Id": "3fa85f64-5717-4562-b3fc-2c963f66afa6", "FirstName": "John", "SecondName": "A.",
	/// "LastName": "Doe", "CreditCardNumber": "4111111111111111", "EmailAddress": "john.doe@example.com", "BirthDate":
	/// "1990-01-01" } .
	/// </remarks>
	/// <response code="201">Returns the newly created item.</response>
	/// <response code="400">If the body is not valid.</response>
	/// <response code="401">If the user is unauthorized.</response>
	[ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
	[ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
	[HttpPost]
	public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomer request)
	{
		var validationResult = await this.createCustomerValidator.ValidateAsync(request);
		if (validationResult.IsValid)
		{
			await this.commandBus.Send(request);
			return this.Created($"customers/{request.Id}", request.Id);
		}

		throw new AppException("One or more error occurred when trying to create customer.", validationResult.Errors);
	}
}
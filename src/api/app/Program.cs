using MagCoders.Orders.Api.Errors;
using MagCoders.Orders.Modules.Core.Api;
using MagCoders.Orders.Modules.Stock.Api;
using MagCoders.Orders.Shared.Abstractions.Behaviors;
using MagCoders.Orders.Shared.Abstractions.Commands;
using MagCoders.Orders.Shared.Abstractions.Domain;
using MagCoders.Orders.Shared.Abstractions.Extensions;
using MagCoders.Orders.Shared.Abstractions.Queries;
using MagCoders.Orders.Shared.Infrastructure;
using MagCoders.Orders.Shared.Infrastructure.Commands.CommandBus;
using MagCoders.Orders.Shared.Infrastructure.EventDispachers;
using MagCoders.Orders.Shared.Infrastructure.EventHandlers;
using MagCoders.Orders.Shared.Infrastructure.Queries.QueryBus;

using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddMediatR(cfg =>
{
	cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSharedModule();
builder.Services.AddCoreModule(builder.Configuration);
builder.Services.AddStockModule(builder.Configuration);
builder.Services.AddFromAssemblies(typeof(IDomainEventHandler<>), AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddFromAssemblies(typeof(IEventDispatcher<>), AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddFromAssemblies(typeof(ICommandHandler<>), AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddFromAssemblies(typeof(IQueryHandler<,>), AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ICommandBus, CommandBus>();
builder.Services.AddScoped<IQueryBus, QueryBus>();
builder.Services.AddFromAssemblies(typeof(IRepository<,>), AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient(
	typeof(IPipelineBehavior<,>),
	typeof(ValidationQueryBehavior<,>));

var app = builder.Build();

app.MapDefaultEndpoints();

app.UseCoreModule();
app.UseStockModule();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.MapControllers();

app.Run();
#pragma warning disable IDE0005 // Using directive is unnecessary.
using System.Reflection;
using FluentValidation;
using MagCoders.Orders.Modules.Core.Contracts.Commands.Customers;
using MagCoders.Orders.Ui.Client.Pages;
using MagCoders.Orders.Ui.Components;
#pragma warning restore IDE0005 // Using directive is unnecessary.
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();

builder.Services.AddHttpClient("WebApi", client => client.BaseAddress = new("https+http://api"));

// Add MudBlazor services
builder.Services.AddMudServices();

builder.Services.AddSingleton<IValidator<CreateCustomer>, CreateCustomerValidator>();

// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents()
	.AddInteractiveWebAssemblyComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseWebAssemblyDebugging();
}
else
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);

	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode()
	.AddInteractiveWebAssemblyRenderMode()
	.AddAdditionalAssemblies(typeof(MagCoders.Orders.Ui.Client._Imports).Assembly);

app.Run();
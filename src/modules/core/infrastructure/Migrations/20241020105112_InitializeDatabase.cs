using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagCoders.Orders.Modules.Core.Infrastructure.Migrations;

/// <inheritdoc/>
public partial class InitializeDatabase : Migration
{
	/// <inheritdoc/>
	protected override void Down(MigrationBuilder migrationBuilder)
	{
		migrationBuilder.DropTable(
			name: "Customer",
			schema: "Core");

		migrationBuilder.DropTable(
			name: "DomainEventStore",
			schema: "Core");

		migrationBuilder.DropTable(
			name: "OrderLine",
			schema: "Core");

		migrationBuilder.DropTable(
			name: "Order",
			schema: "Core");
	}

	/// <inheritdoc/>
	protected override void Up(MigrationBuilder migrationBuilder)
	{
		migrationBuilder.EnsureSchema(
			name: "Core");

		migrationBuilder.CreateTable(
			name: "Customer",
			schema: "Core",
			columns: table => new
			{
				Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
				BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
				CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
				CreditCard = table.Column<string>(type: "nvarchar(max)", nullable: false),
				EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
				Level = table.Column<int>(type: "int", nullable: false),
				FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
				LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
				SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
			},
			constraints: table => table.PrimaryKey("PK_Customer", x => x.Id));

		migrationBuilder.CreateTable(
			name: "DomainEventStore",
			schema: "Core",
			columns: table => new
			{
				Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
				Data = table.Column<string>(type: "nvarchar(max)", nullable: true),
				Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
				CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
			},
			constraints: table => table.PrimaryKey("PK_DomainEventStore", x => x.Id));

		migrationBuilder.CreateTable(
			name: "Order",
			schema: "Core",
			columns: table => new
			{
				Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
				CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
				CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
				Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
				State = table.Column<int>(type: "int", nullable: false),
				Overall_Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
				Overall_Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
			},
			constraints: table => table.PrimaryKey("PK_Order", x => x.Id));

		migrationBuilder.CreateTable(
			name: "OrderLine",
			schema: "Core",
			columns: table => new
			{
				Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
				Discount = table.Column<decimal>(type: "decimal(5,4)", precision: 5, scale: 4, nullable: false),
				OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
				Product = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
				Quantity = table.Column<int>(type: "int", nullable: false),
				OriginalUnitPrice_Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
				OriginalUnitPrice_Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
				Price_Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
				Price_Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
				UnitPrice_Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
				UnitPrice_Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
			},
			constraints: table =>
			{
				table.PrimaryKey("PK_OrderLine", x => x.Id);
				table.ForeignKey(
					name: "FK_OrderLine_Order_OrderId",
					column: x => x.OrderId,
					principalSchema: "Core",
					principalTable: "Order",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);
			});

		migrationBuilder.CreateIndex(
			name: "IX_OrderLine_OrderId",
			schema: "Core",
			table: "OrderLine",
			column: "OrderId");
	}
}
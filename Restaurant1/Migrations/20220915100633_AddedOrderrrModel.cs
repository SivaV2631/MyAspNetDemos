using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurant1.Migrations
{
    public partial class AddedOrderrrModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderrrOrderId",
                table: "Items",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Orderrrs",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderName = table.Column<string>(maxLength: 50, nullable: false),
                    OrderStatus = table.Column<bool>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    OrderItems = table.Column<string>(nullable: false),
                    OrderAmount = table.Column<decimal>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orderrrs", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orderrrs_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_OrderrrOrderId",
                table: "Items",
                column: "OrderrrOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orderrrs_CustomerId",
                table: "Orderrrs",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Orderrrs_OrderrrOrderId",
                table: "Items",
                column: "OrderrrOrderId",
                principalTable: "Orderrrs",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Orderrrs_ItemName",
                table: "Payments",
                column: "ItemName",
                principalTable: "Orderrrs",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Orderrrs_OrderrrOrderId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Orderrrs_ItemName",
                table: "Payments");

            migrationBuilder.DropTable(
                name: "Orderrrs");

            migrationBuilder.DropIndex(
                name: "IX_Items_OrderrrOrderId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "OrderrrOrderId",
                table: "Items");
        }
    }
}

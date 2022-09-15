using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurant1.Migrations
{
    public partial class AddedOrderrModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Payments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemName",
                table: "Payments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderrOrderId",
                table: "Items",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Orderrs",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderName = table.Column<string>(maxLength: 50, nullable: false),
                    OrderStatus = table.Column<bool>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orderrs", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orderrs_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CustomerId",
                table: "Payments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ItemName",
                table: "Payments",
                column: "ItemName");

            migrationBuilder.CreateIndex(
                name: "IX_Items_OrderrOrderId",
                table: "Items",
                column: "OrderrOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orderrs_CustomerId",
                table: "Orderrs",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Orderrs_OrderrOrderId",
                table: "Items",
                column: "OrderrOrderId",
                principalTable: "Orderrs",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Orders_CustomerId",
                table: "Payments",
                column: "CustomerId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Orderrs_ItemName",
                table: "Payments",
                column: "ItemName",
                principalTable: "Orderrs",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Orderrs_OrderrOrderId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Orders_CustomerId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Orderrs_ItemName",
                table: "Payments");

            migrationBuilder.DropTable(
                name: "Orderrs");

            migrationBuilder.DropIndex(
                name: "IX_Payments_CustomerId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_ItemName",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Items_OrderrOrderId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "OrderrOrderId",
                table: "Items");
        }
    }
}

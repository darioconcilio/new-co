using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewCoEF.Migrations
{
    public partial class Orders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Items_ItemRefId",
                table: "OrderLines");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerRefId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerRefId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_OrderLines_ItemRefId",
                table: "OrderLines");

            migrationBuilder.DropColumn(
                name: "CustomerRefId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ItemRefId",
                table: "OrderLines");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Orders",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ItemId",
                table: "OrderLines",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_ItemId",
                table: "OrderLines",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Items_ItemId",
                table: "OrderLines",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Items_ItemId",
                table: "OrderLines");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_OrderLines_ItemId",
                table: "OrderLines");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "OrderLines");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerRefId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ItemRefId",
                table: "OrderLines",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerRefId",
                table: "Orders",
                column: "CustomerRefId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_ItemRefId",
                table: "OrderLines",
                column: "ItemRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Items_ItemRefId",
                table: "OrderLines",
                column: "ItemRefId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerRefId",
                table: "Orders",
                column: "CustomerRefId",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

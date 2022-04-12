using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewCoEF.Migrations
{
    public partial class newdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Countries_CountryRefID",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Counties_CountyRefID",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerRefID",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderLines",
                table: "OrderLines");

            migrationBuilder.DropIndex(
                name: "Item Description Index",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "Customer_Name_Index",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "CustomerRefID",
                table: "Orders",
                newName: "CustomerRefId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomerRefID",
                table: "Orders",
                newName: "IX_Orders_CustomerRefId");

            migrationBuilder.RenameColumn(
                name: "Unit Price",
                table: "OrderLines",
                newName: "UnitPrice");

            migrationBuilder.RenameColumn(
                name: "Line No",
                table: "OrderLines",
                newName: "LineNo");

            migrationBuilder.RenameColumn(
                name: "Line Amount",
                table: "OrderLines",
                newName: "LineAmount");

            migrationBuilder.RenameColumn(
                name: "Unit Price",
                table: "Items",
                newName: "UnitPrice");

            migrationBuilder.RenameColumn(
                name: "CountyRefID",
                table: "Customers",
                newName: "CountyRefId");

            migrationBuilder.RenameColumn(
                name: "CountryRefID",
                table: "Customers",
                newName: "CountryRefId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_CountyRefID",
                table: "Customers",
                newName: "IX_Customers_CountyRefId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_CountryRefID",
                table: "Customers",
                newName: "IX_Customers_CountryRefId");

            migrationBuilder.AlterColumn<string>(
                name: "No",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldUnicode: false,
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerRefId",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Quantity",
                table: "OrderLines",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");

            migrationBuilder.AlterColumn<double>(
                name: "UnitPrice",
                table: "OrderLines",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<double>(
                name: "LineAmount",
                table: "OrderLines",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<string>(
                name: "No",
                table: "Items",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldUnicode: false,
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Inventory",
                table: "Items",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Items",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "Items",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Counties",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderLines",
                table: "OrderLines",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_OrderId",
                table: "OrderLines",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Countries_CountryRefId",
                table: "Customers",
                column: "CountryRefId",
                principalTable: "Countries",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Counties_CountyRefId",
                table: "Customers",
                column: "CountyRefId",
                principalTable: "Counties",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerRefId",
                table: "Orders",
                column: "CustomerRefId",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Countries_CountryRefId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Counties_CountyRefId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerRefId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderLines",
                table: "OrderLines");

            migrationBuilder.DropIndex(
                name: "IX_OrderLines_OrderId",
                table: "OrderLines");

            migrationBuilder.RenameColumn(
                name: "CustomerRefId",
                table: "Orders",
                newName: "CustomerRefID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomerRefId",
                table: "Orders",
                newName: "IX_Orders_CustomerRefID");

            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "OrderLines",
                newName: "Unit Price");

            migrationBuilder.RenameColumn(
                name: "LineNo",
                table: "OrderLines",
                newName: "Line No");

            migrationBuilder.RenameColumn(
                name: "LineAmount",
                table: "OrderLines",
                newName: "Line Amount");

            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "Items",
                newName: "Unit Price");

            migrationBuilder.RenameColumn(
                name: "CountyRefId",
                table: "Customers",
                newName: "CountyRefID");

            migrationBuilder.RenameColumn(
                name: "CountryRefId",
                table: "Customers",
                newName: "CountryRefID");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_CountyRefId",
                table: "Customers",
                newName: "IX_Customers_CountyRefID");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_CountryRefId",
                table: "Customers",
                newName: "IX_Customers_CountryRefID");

            migrationBuilder.AlterColumn<string>(
                name: "No",
                table: "Orders",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Orders",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerRefID",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "OrderLines",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "Unit Price",
                table: "OrderLines",
                type: "money",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "Line Amount",
                table: "OrderLines",
                type: "money",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<string>(
                name: "No",
                table: "Items",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Inventory",
                table: "Items",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Items",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Unit Price",
                table: "Items",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Counties",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderLines",
                table: "OrderLines",
                columns: new[] { "OrderId", "Id" });

            migrationBuilder.CreateIndex(
                name: "Item Description Index",
                table: "Items",
                column: "Description");

            migrationBuilder.CreateIndex(
                name: "Customer_Name_Index",
                table: "Customers",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Countries_CountryRefID",
                table: "Customers",
                column: "CountryRefID",
                principalTable: "Countries",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Counties_CountyRefID",
                table: "Customers",
                column: "CountyRefID",
                principalTable: "Counties",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerRefID",
                table: "Orders",
                column: "CustomerRefID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

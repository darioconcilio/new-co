using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewCoEF.Migrations
{
    public partial class InitialDefinition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Counties",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counties", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 22, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    UnitPrice = table.Column<decimal>(name: "Unit Price", type: "money", nullable: false),
                    Inventory = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    No = table.Column<string>(type: "varchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    VATRegistrationCode = table.Column<string>(nullable: true),
                    CountyRefID = table.Column<Guid>(nullable: true),
                    CountryRefID = table.Column<Guid>(nullable: true),
                    ItemId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Customers_Countries_CountryRefID",
                        column: x => x.CountryRefID,
                        principalTable: "Countries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_Counties_CountyRefID",
                        column: x => x.CountyRefID,
                        principalTable: "Counties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    No = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    CustomerRefID = table.Column<Guid>(nullable: true),
                    ItemId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerRefID",
                        column: x => x.CustomerRefID,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderLines",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    LineNo = table.Column<int>(name: "Line No", type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitPrice = table.Column<decimal>(name: "Unit Price", type: "money", nullable: false),
                    LineAmount = table.Column<decimal>(name: "Line Amount", type: "money", nullable: false),
                    ItemRefId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLines", x => new { x.OrderId, x.Id });
                    table.ForeignKey(
                        name: "FK_OrderLines_Items_ItemRefId",
                        column: x => x.ItemRefId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderLines_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CountryRefID",
                table: "Customers",
                column: "CountryRefID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CountyRefID",
                table: "Customers",
                column: "CountyRefID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ItemId",
                table: "Customers",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "Customer_Name_Index",
                table: "Customers",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "Item Description Index",
                table: "Items",
                column: "Description");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_ItemRefId",
                table: "OrderLines",
                column: "ItemRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerRefID",
                table: "Orders",
                column: "CustomerRefID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ItemId",
                table: "Orders",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderLines");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Counties");

            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}

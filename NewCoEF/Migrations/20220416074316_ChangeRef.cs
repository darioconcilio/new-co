using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewCoEF.Migrations
{
    public partial class ChangeRef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Countries_CountryRefId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Counties_CountyRefId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CountryRefId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CountyRefId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CountryRefId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CountyRefId",
                table: "Customers");

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountyId",
                table: "Customers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CountryId",
                table: "Customers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CountyId",
                table: "Customers",
                column: "CountyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Countries_CountryId",
                table: "Customers",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Counties_CountyId",
                table: "Customers",
                column: "CountyId",
                principalTable: "Counties",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Countries_CountryId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Counties_CountyId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CountryId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CountyId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CountyId",
                table: "Customers");

            migrationBuilder.AddColumn<Guid>(
                name: "CountryRefId",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountyRefId",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CountryRefId",
                table: "Customers",
                column: "CountryRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CountyRefId",
                table: "Customers",
                column: "CountyRefId");

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
        }
    }
}

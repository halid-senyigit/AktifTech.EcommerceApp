using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApp.Persistence.Migrations
{
    public partial class RelationFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_CustomerOrders_CustomerOrderId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CustomerOrderId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CustomerOrderId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "CustomerOrderProductRels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CustomerOrderId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOrderProductRels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerOrderProductRels_CustomerOrders_CustomerOrderId",
                        column: x => x.CustomerOrderId,
                        principalTable: "CustomerOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerOrderProductRels_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrderProductRels_CustomerOrderId",
                table: "CustomerOrderProductRels",
                column: "CustomerOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrderProductRels_ProductId",
                table: "CustomerOrderProductRels",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerOrderProductRels");

            migrationBuilder.AddColumn<int>(
                name: "CustomerOrderId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CustomerOrderId",
                table: "Products",
                column: "CustomerOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_CustomerOrders_CustomerOrderId",
                table: "Products",
                column: "CustomerOrderId",
                principalTable: "CustomerOrders",
                principalColumn: "Id");
        }
    }
}

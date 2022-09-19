using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApp.Persistence.Migrations
{
    public partial class QuantityAndAddressColumnsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "CustomerOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "CustomerOrderProductRels",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "CustomerOrders");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "CustomerOrderProductRels");
        }
    }
}

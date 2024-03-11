using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrocerySystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AlterGoods : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Goods",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Goods");
        }
    }
}

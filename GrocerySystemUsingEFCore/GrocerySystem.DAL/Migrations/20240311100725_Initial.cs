using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrocerySystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Goods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Goods__3214EC075B8C3B6C", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shoppers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Shoppers__3214EC07534A16C2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groceries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    GoodsId = table.Column<int>(type: "int", nullable: false),
                    ShoppersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Grocerie__3214EC07B92F0B3A", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groceries_Goods",
                        column: x => x.GoodsId,
                        principalTable: "Goods",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Groceries_Shoppers",
                        column: x => x.ShoppersId,
                        principalTable: "Shoppers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groceries_GoodsId",
                table: "Groceries",
                column: "GoodsId");

            migrationBuilder.CreateIndex(
                name: "IX_Groceries_ShoppersId",
                table: "Groceries",
                column: "ShoppersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Groceries");

            migrationBuilder.DropTable(
                name: "Goods");

            migrationBuilder.DropTable(
                name: "Shoppers");
        }
    }
}

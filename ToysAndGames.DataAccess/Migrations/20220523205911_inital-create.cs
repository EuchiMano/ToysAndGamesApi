using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToysAndGames.DataAccess.Migrations
{
    public partial class initalcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AgeRestriction = table.Column<int>(type: "int", nullable: true),
                    Company = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.CheckConstraint("CK_Products_AgeRestriction", "[AgeRestriction] >= 0 AND [AgeRestriction] <= 100");
                    table.CheckConstraint("CK_Products_Price", "[Price] >= 1 AND [Price] <= 1000");
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AgeRestriction", "Company", "Description", "Image", "Name", "Price" },
                values: new object[] { 1, 12, "Mattel", "Lorem impsum...", null, "Barbie Developer", 25.99m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AgeRestriction", "Company", "Description", "Image", "Name", "Price" },
                values: new object[] { 2, 4, "Marvel", null, null, "xyc", 75.50m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AgeRestriction", "Company", "Description", "Image", "Name", "Price" },
                values: new object[] { 3, 18, "Nintendo", null, null, "abc", 99.99m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}

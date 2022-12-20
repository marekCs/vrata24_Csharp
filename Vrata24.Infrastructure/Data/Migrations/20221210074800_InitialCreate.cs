using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vrata24.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table =>
                    new
                    {
                        Id = table
                            .Column<int>(type: "INTEGER", nullable: false)
                            .Annotation("Sqlite:Autoincrement", true),
                        ProductName = table.Column<string>(type: "TEXT", nullable: true),
                        ProductDescription = table.Column<string>(type: "TEXT", nullable: true),
                        ProductHeight = table.Column<int>(type: "INTEGER", nullable: false),
                        ProductLength = table.Column<int>(type: "INTEGER", nullable: false),
                        ProductWidth = table.Column<int>(type: "INTEGER", nullable: false),
                        ProductWeight = table.Column<int>(type: "INTEGER", nullable: false),
                        ProductPrice = table.Column<double>(type: "REAL", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Products");
        }
    }
}

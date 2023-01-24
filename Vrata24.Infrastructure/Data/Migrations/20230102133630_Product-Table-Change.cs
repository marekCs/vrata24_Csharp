using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vrata24.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProductTableChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductLength",
                table: "Products",
                newName: "ProductDepth");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductDepth",
                table: "Products",
                newName: "ProductLength");
        }
    }
}

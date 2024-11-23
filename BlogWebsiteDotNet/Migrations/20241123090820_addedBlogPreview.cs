using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogWebsiteDotNet.Migrations
{
    /// <inheritdoc />
    public partial class addedBlogPreview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BlogPreview",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlogPreview",
                table: "Blogs");
        }
    }
}

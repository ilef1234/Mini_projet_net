using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mini_projet_net.Migrations
{
    public partial class AddPhotoPathToProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "articles");
        }
    }
}

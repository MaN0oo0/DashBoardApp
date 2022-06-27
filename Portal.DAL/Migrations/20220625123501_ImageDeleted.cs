using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalDAL.Migrations
{
    public partial class ImageDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ImageIsDeleted",
                table: "Employee",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageIsDeleted",
                table: "Employee");
        }
    }
}

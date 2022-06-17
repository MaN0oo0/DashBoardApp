using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalDAL.Migrations
{
    public partial class DistricId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DistricId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DistricId",
                table: "Employee",
                column: "DistricId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Distric_DistricId",
                table: "Employee",
                column: "DistricId",
                principalTable: "Distric",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Distric_DistricId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_DistricId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DistricId",
                table: "Employee");
        }
    }
}

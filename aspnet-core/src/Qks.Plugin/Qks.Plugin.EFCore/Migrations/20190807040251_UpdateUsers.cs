using Microsoft.EntityFrameworkCore.Migrations;

namespace Qks.Plugin.EFCore.Migrations
{
    public partial class UpdateUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Sys_Users",
                table: "Sys_Users");

            migrationBuilder.RenameTable(
                name: "Sys_Users",
                newName: "QksUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QksUsers",
                table: "QksUsers",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_QksUsers",
                table: "QksUsers");

            migrationBuilder.RenameTable(
                name: "QksUsers",
                newName: "Sys_Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sys_Users",
                table: "Sys_Users",
                column: "Id");
        }
    }
}

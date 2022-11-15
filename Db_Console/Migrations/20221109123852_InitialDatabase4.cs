using Microsoft.EntityFrameworkCore.Migrations;

namespace Db_Console.Migrations
{
    public partial class InitialDatabase4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DbConsoleApp",
                table: "DbConsoleApp");

            migrationBuilder.RenameTable(
                name: "DbConsoleApp",
                newName: "Persons");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "DbConsoleApp");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DbConsoleApp",
                table: "DbConsoleApp",
                column: "Id");
        }
    }
}

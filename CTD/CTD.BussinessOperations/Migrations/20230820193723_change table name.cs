using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CTD.BussinessOperations.Migrations
{
    /// <inheritdoc />
    public partial class changetablename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserEmails",
                table: "UserEmails");

            migrationBuilder.RenameTable(
                name: "UserEmails",
                newName: "UserEmail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserEmail",
                table: "UserEmail",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserEmail",
                table: "UserEmail");

            migrationBuilder.RenameTable(
                name: "UserEmail",
                newName: "UserEmails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserEmails",
                table: "UserEmails",
                column: "Id");
        }
    }
}

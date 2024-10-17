using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Module.User.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedPasswordColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "UserAccounts",
                newName: "PasswordHash");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "UserAccounts",
                newName: "Password");
        }
    }
}

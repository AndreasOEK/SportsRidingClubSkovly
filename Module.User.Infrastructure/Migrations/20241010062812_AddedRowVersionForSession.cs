using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Module.User.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedRowVersionForSession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AvailableSlots",
                table: "Sessions",
                newName: "MaxNumberOfParticipants");

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Sessions",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Sessions");

            migrationBuilder.RenameColumn(
                name: "MaxNumberOfParticipants",
                table: "Sessions",
                newName: "AvailableSlots");
        }
    }
}

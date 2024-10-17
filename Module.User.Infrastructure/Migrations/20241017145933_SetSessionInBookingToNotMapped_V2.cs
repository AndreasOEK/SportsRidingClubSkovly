using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Module.User.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SetSessionInBookingToNotMapped_V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Sessions_SessionId1",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_SessionId1",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "SessionId1",
                table: "Bookings");

            migrationBuilder.AlterColumn<Guid>(
                name: "SessionId",
                table: "Bookings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "SessionId",
                table: "Bookings",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "SessionId1",
                table: "Bookings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_SessionId1",
                table: "Bookings",
                column: "SessionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Sessions_SessionId1",
                table: "Bookings",
                column: "SessionId1",
                principalTable: "Sessions",
                principalColumn: "Id");
        }
    }
}

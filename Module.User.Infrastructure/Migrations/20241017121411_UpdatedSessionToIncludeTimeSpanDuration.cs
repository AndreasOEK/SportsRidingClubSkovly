using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Module.User.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedSessionToIncludeTimeSpanDuration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Sessions");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "Sessions",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AlterColumn<Guid>(
                name: "SessionId",
                table: "Bookings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SessionId1",
                table: "Bookings",
                type: "uniqueidentifier",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Sessions_SessionId1",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_SessionId1",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "SessionId1",
                table: "Bookings");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Sessions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<Guid>(
                name: "SessionId",
                table: "Bookings",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }
    }
}

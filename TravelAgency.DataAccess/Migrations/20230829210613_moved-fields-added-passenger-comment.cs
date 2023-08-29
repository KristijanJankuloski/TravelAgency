using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class movedfieldsaddedpassengercomment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomType",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "ServiceType",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "TransportationType",
                table: "Plans");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Passengers",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoomType",
                table: "Contracts",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceType",
                table: "Contracts",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransportationType",
                table: "Contracts",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "RoomType",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "ServiceType",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "TransportationType",
                table: "Contracts");

            migrationBuilder.AddColumn<string>(
                name: "RoomType",
                table: "Plans",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceType",
                table: "Plans",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransportationType",
                table: "Plans",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);
        }
    }
}

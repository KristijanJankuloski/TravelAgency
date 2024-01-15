using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addinginvoicesandemails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceIterator",
                table: "Organizations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "InvoiceNote",
                table: "Organizations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaxPercentage",
                table: "Organizations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CanceledOn",
                table: "Contracts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiscountPercentage",
                table: "Contracts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaxPercentage",
                table: "Contracts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Contracts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ContractEmailEvents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 15, 1, 53, 1, 713, DateTimeKind.Local).AddTicks(7263),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "ContractEmailEvents",
                type: "text",
                maxLength: 511,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(511)",
                oldMaxLength: 511,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "ContractEmailEvents",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContractId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: true),
                    CratedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaidOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AmountToPay = table.Column<double>(type: "float", nullable: false),
                    AmountRemaining = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceEmailEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SentOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 1, 15, 1, 53, 1, 713, DateTimeKind.Local).AddTicks(8893)),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Body = table.Column<string>(type: "text", maxLength: 511, nullable: true),
                    EventType = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceEmailEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceEmailEvents_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceEmailEvents_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_UserId",
                table: "Contracts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractEmailEvents_CreatedById",
                table: "ContractEmailEvents",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceEmailEvents_CreatedById",
                table: "InvoiceEmailEvents",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceEmailEvents_InvoiceId",
                table: "InvoiceEmailEvents",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ContractId",
                table: "Invoices",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_Number",
                table: "Invoices",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_UserId",
                table: "Invoices",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractEmailEvents_AspNetUsers_CreatedById",
                table: "ContractEmailEvents",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_AspNetUsers_UserId",
                table: "Contracts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractEmailEvents_AspNetUsers_CreatedById",
                table: "ContractEmailEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_AspNetUsers_UserId",
                table: "Contracts");

            migrationBuilder.DropTable(
                name: "InvoiceEmailEvents");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_UserId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_ContractEmailEvents_CreatedById",
                table: "ContractEmailEvents");

            migrationBuilder.DropColumn(
                name: "InvoiceIterator",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "InvoiceNote",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "TaxPercentage",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "CanceledOn",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "DiscountPercentage",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "TaxPercentage",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ContractEmailEvents");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "ContractEmailEvents",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 15, 1, 53, 1, 713, DateTimeKind.Local).AddTicks(7263));

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "ContractEmailEvents",
                type: "nvarchar(511)",
                maxLength: 511,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldMaxLength: 511,
                oldNullable: true);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RSCO.LoanManagement.Migrations
{
    /// <inheritdoc />
    public partial class editContractLoan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "LoanContracts");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "LoanContracts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "LoanContracts");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "LoanContractPersons");

            migrationBuilder.AddColumn<string>(
                name: "Summery",
                table: "LoanContracts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "LoanContractPersons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "LoanContractPersons",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "LoanContractPersons",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "LoanContractPersons",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Summery",
                table: "LoanContracts");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "LoanContractPersons");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "LoanContractPersons");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "LoanContractPersons");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "LoanContractPersons");

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "LoanContracts",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "LoanContracts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "LoanContracts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "LoanContractPersons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

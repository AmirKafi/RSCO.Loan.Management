using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RSCO.LoanManagement.Migrations
{
    /// <inheritdoc />
    public partial class Added_Role_To_LoanContractPerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanContractPersons_People_PersonId",
                table: "LoanContractPersons");

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId1",
                table: "LoanContractPersons",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "LoanContractPersons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LoanContractPersons_PersonId1",
                table: "LoanContractPersons",
                column: "PersonId1");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanContractPersons_People_PersonId",
                table: "LoanContractPersons",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanContractPersons_People_PersonId1",
                table: "LoanContractPersons",
                column: "PersonId1",
                principalTable: "People",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanContractPersons_People_PersonId",
                table: "LoanContractPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanContractPersons_People_PersonId1",
                table: "LoanContractPersons");

            migrationBuilder.DropIndex(
                name: "IX_LoanContractPersons_PersonId1",
                table: "LoanContractPersons");

            migrationBuilder.DropColumn(
                name: "PersonId1",
                table: "LoanContractPersons");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "LoanContractPersons");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanContractPersons_People_PersonId",
                table: "LoanContractPersons",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

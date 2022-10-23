using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroupFlowTickets.Data.Migrations
{
    /// <inheritdoc />
    public partial class GroupSequence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Groups_PrecedingGroupId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_PrecedingGroupId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "PrecedingGroupId",
                table: "Groups");

            migrationBuilder.AddColumn<int>(
                name: "Sequence",
                table: "Groups",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sequence",
                table: "Groups");

            migrationBuilder.AddColumn<Guid>(
                name: "PrecedingGroupId",
                table: "Groups",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_PrecedingGroupId",
                table: "Groups",
                column: "PrecedingGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Groups_PrecedingGroupId",
                table: "Groups",
                column: "PrecedingGroupId",
                principalTable: "Groups",
                principalColumn: "GroupId");
        }
    }
}

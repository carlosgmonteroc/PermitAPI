using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Permit.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddingPermit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PermitType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedAt",
                table: "PermitType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Permit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermitTypeId = table.Column<int>(type: "int", nullable: false),
                    PermitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permit_PermitType_PermitTypeId",
                        column: x => x.PermitTypeId,
                        principalTable: "PermitType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permit_PermitTypeId",
                table: "Permit",
                column: "PermitTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permit");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PermitType");

            migrationBuilder.DropColumn(
                name: "LastUpdatedAt",
                table: "PermitType");
        }
    }
}

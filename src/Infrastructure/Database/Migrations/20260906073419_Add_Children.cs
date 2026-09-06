using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Database.Migrations;

/// <inheritdoc />
public partial class Add_Children : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "children",
            schema: "public",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                user_id = table.Column<Guid>(type: "uuid", nullable: false),
                name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                is_checked_in = table.Column<bool>(type: "boolean", nullable: false),
                created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                checked_in_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_children", x => x.id);
            });

        migrationBuilder.CreateIndex(
            name: "ix_children_user_id",
            schema: "public",
            table: "children",
            column: "user_id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "children",
            schema: "public");
    }
}

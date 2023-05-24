using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspnetwebapi.Migrations
{
    /// <inheritdoc />
    public partial class ShoppingList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingList",
                table: "ShoppingList");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "ShoppingList");

            migrationBuilder.RenameTable(
                name: "ShoppingList",
                newName: "ShoppingLists");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingLists",
                table: "ShoppingLists",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingLists",
                table: "ShoppingLists");

            migrationBuilder.RenameTable(
                name: "ShoppingLists",
                newName: "ShoppingList");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "ShoppingList",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingList",
                table: "ShoppingList",
                column: "Id");
        }
    }
}

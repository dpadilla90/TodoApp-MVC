using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApp_MVC.Migrations
{
    // Represents the initial migration to create the "ToDos" table in the database.
    public partial class InitialCreate : Migration
    {
        // Method for applying the changes when the migration is executed.
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Create the "ToDos" table in the database with the specified columns.
            migrationBuilder.CreateTable(
                name: "ToDos",
                columns: table => new
                {
                    // Primary key column "Id" with auto-incrementing integer type.
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),

                    // Column "Title" with text type, representing the title or name of the ToDo item.
                    Title = table.Column<string>(type: "TEXT", nullable: false),

                    // Column "Description" with text type, representing the description or details of the ToDo item.
                    Description = table.Column<string>(type: "TEXT", nullable: false),

                    // Column "CompletionDate" with datetime type, representing the completion date of the ToDo item (nullable).
                    CompletionDate = table.Column<DateTime>(type: "TEXT", nullable: true),

                    // Column "IsCompleted" with boolean type, representing whether the ToDo item is completed or not.
                    IsCompleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    // Set the primary key constraint for the "ToDos" table using the "Id" column.
                    table.PrimaryKey("PK_ToDos", x => x.Id);
                });
        }

        // Method for reverting the changes when the migration is rolled back.
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop the "ToDos" table from the database.
            migrationBuilder.DropTable(
                name: "ToDos");
        }
    }
}

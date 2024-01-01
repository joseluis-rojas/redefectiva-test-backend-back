using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clean.Architecture.Infrastructure.Data.Migrations;

/// <inheritdoc />
public partial class PersonsTable : Migration
{
  /// <inheritdoc />
  protected override void Up(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.CreateTable(
        name: "Persons",
        columns: table => new
        {
          Id = table.Column<int>(type: "INTEGER", nullable: false)
                .Annotation("Sqlite:Autoincrement", true),
          Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
          LastName = table.Column<string>(type: "TEXT",  nullable: false),
          Address = table.Column<string>(type: "TEXT",  nullable: false),
          Gender = table.Column<string>(type: "TEXT", nullable: false),
          PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
          Status = table.Column<int>(type: "INTEGER", nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Persons", x => x.Id);
        });

    // Comentarios explicativos
    // ...

  }

  /// <inheritdoc />
  protected override void Down(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.DropTable(
        name: "Persons");
  }
}


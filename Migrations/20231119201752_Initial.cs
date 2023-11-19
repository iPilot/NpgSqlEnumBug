using Microsoft.EntityFrameworkCore.Migrations;
using NpgSqlEnumBug;

#nullable disable

namespace NpgSqlEnumBug.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "enum_schema");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:enum_schema.test_enum", "first,second,third")
                .Annotation("Npgsql:Enum:enum_schema.test_enum2", "n1,n2,n3");

            migrationBuilder.CreateTable(
                name: "TestEntities",
                schema: "enum_schema",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "numeric(20,0)", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Enum = table.Column<TestEnum>(type: "test_enum", nullable: false),
                    Enum2 = table.Column<TestEnum2>(type: "test_enum2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestEntities", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestEntities",
                schema: "enum_schema");
        }
    }
}

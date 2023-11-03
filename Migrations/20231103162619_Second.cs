using Microsoft.EntityFrameworkCore.Migrations;
using NpgSqlEnumBug;

#nullable disable

namespace NpgSqlEnumBug.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:test_enum", "first,second,third")
                .Annotation("Npgsql:Enum:test_enum2", "n1,n2,n3")
                .OldAnnotation("Npgsql:Enum:test_enum", "first,second,third");

            migrationBuilder.AddColumn<TestEnum2>(
                name: "Enum2",
                table: "TestEntities",
                type: "test_enum2",
                nullable: false,
                defaultValue: TestEnum2.N1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Enum2",
                table: "TestEntities");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:test_enum", "first,second,third")
                .OldAnnotation("Npgsql:Enum:test_enum", "first,second,third")
                .OldAnnotation("Npgsql:Enum:test_enum2", "n1,n2,n3");
        }
    }
}

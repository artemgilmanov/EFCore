using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedSubCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          migrationBuilder.Sql("INSERT INTO Fluent_SubCategories VALUES ('Cat 1')");
          migrationBuilder.Sql("INSERT INTO Fluent_SubCategories VALUES ('Cat 2')");
          migrationBuilder.Sql("INSERT INTO Fluent_SubCategories VALUES ('Cat 3')");

    }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

using GitHubLike.Modules.Common.Services;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GitHubLike.Migrations
{
    public partial class DbSeederMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            DbSeeder dbSeeder = new();
            dbSeeder.SeedData();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

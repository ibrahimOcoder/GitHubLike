using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GitHubLike.Migrations
{
    /// <inheritdoc />
    public partial class AddeduserIdinProjets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CreatedByUserId",
                table: "ProjectModule_Project",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "ProjectModule_Project");
        }
    }
}

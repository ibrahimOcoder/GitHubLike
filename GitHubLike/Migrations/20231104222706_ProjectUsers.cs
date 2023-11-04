using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GitHubLike.Migrations
{
    /// <inheritdoc />
    public partial class ProjectUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AcceptedInvite",
                table: "ProjectModule_ProjectUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "ProjectModule_Project",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcceptedInvite",
                table: "ProjectModule_ProjectUsers");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "ProjectModule_Project");
        }
    }
}

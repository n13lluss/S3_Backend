using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Travelblog.Dal.Migrations
{
    /// <inheritdoc />
    public partial class userIdString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdString",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Blog/Like",
                table: "Blog/Like");

            migrationBuilder.DropColumn(
                name: "IdString",
                table: "User");
        }
    }
}

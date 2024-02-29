using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Travelblog.Dal.Migrations
{
    /// <inheritdoc />
    public partial class YourNewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Budget",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Min = table.Column<int>(type: "int", nullable: false),
                    Max = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budget", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Continent = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Duration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Min = table.Column<int>(type: "int", nullable: false),
                    Max = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duration", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transport", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Suspended = table.Column<bool>(type: "bit", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Preference",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Theme = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preference", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Preference_User",
                        column: x => x.User_Id,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Post_Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Prive = table.Column<bool>(type: "bit", nullable: false),
                    Suspended = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reaction_User",
                        column: x => x.User_Id,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Object_Type = table.Column<int>(type: "int", nullable: false),
                    Object_Id = table.Column<int>(type: "int", nullable: false),
                    Reporter_Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Resolver_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Report_User",
                        column: x => x.Reporter_Id,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Report_User1",
                        column: x => x.Resolver_Id,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Trip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Creator_Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Start_Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Posted_On = table.Column<DateTime>(type: "datetime", nullable: false),
                    Prive = table.Column<bool>(type: "bit", nullable: false),
                    Suspended = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trip_User",
                        column: x => x.Creator_Id,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reaction/Like",
                columns: table => new
                {
                    Reaction_Id = table.Column<int>(type: "int", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Reaction/Like_Reaction",
                        column: x => x.Reaction_Id,
                        principalTable: "Reaction",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reaction/Like_User",
                        column: x => x.User_Id,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Creator_Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Start_Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    Prive = table.Column<bool>(type: "bit", nullable: false),
                    Suspended = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Trip_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blog_Trip",
                        column: x => x.Trip_Id,
                        principalTable: "Trip",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Blog_User",
                        column: x => x.Creator_Id,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Posted_On = table.Column<DateTime>(type: "datetime", nullable: false),
                    Prive = table.Column<bool>(type: "bit", nullable: false),
                    Suspended = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Trip_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Trip",
                        column: x => x.Trip_Id,
                        principalTable: "Trip",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Trip/Budget",
                columns: table => new
                {
                    Trip_Id = table.Column<int>(type: "int", nullable: false),
                    Budget_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Trip/Budget_Budget",
                        column: x => x.Budget_Id,
                        principalTable: "Budget",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Trip/Budget_Trip",
                        column: x => x.Trip_Id,
                        principalTable: "Trip",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Trip/Country",
                columns: table => new
                {
                    Trip_Id = table.Column<int>(type: "int", nullable: false),
                    Country_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Trip/Country_Country",
                        column: x => x.Country_Id,
                        principalTable: "Country",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Trip/Country_Trip",
                        column: x => x.Trip_Id,
                        principalTable: "Trip",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Trip/Duration",
                columns: table => new
                {
                    Trip_Id = table.Column<int>(type: "int", nullable: false),
                    Duration_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Trip/Duration_Duration",
                        column: x => x.Duration_Id,
                        principalTable: "Duration",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Trip/Duration_Trip",
                        column: x => x.Trip_Id,
                        principalTable: "Trip",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Trip/Tag",
                columns: table => new
                {
                    Trip_Id = table.Column<int>(type: "int", nullable: false),
                    Tag_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Trip/Tag_Tag",
                        column: x => x.Tag_Id,
                        principalTable: "Tag",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Trip/Tag_Trip",
                        column: x => x.Trip_Id,
                        principalTable: "Trip",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Trip/Transport",
                columns: table => new
                {
                    Trip_Id = table.Column<int>(type: "int", nullable: false),
                    Transport_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Trip/Transport_Transport",
                        column: x => x.Transport_Id,
                        principalTable: "Transport",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Trip/Transport_Trip",
                        column: x => x.Trip_Id,
                        principalTable: "Trip",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Blog/Country",
                columns: table => new
                {
                    Blog_Id = table.Column<int>(type: "int", nullable: false),
                    Country_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Blog/Country_Blog",
                        column: x => x.Blog_Id,
                        principalTable: "Blog",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Blog/Country_Country",
                        column: x => x.Country_Id,
                        principalTable: "Country",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Blog/Follower",
                columns: table => new
                {
                    Follower_Id = table.Column<int>(type: "int", nullable: false),
                    Blog_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Blog/Follower_Blog",
                        column: x => x.Blog_Id,
                        principalTable: "Blog",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Blog/Follower_User",
                        column: x => x.Follower_Id,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Blog/Like",
                columns: table => new
                {
                    Blog_Id = table.Column<int>(type: "int", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Blog/Like_Blog",
                        column: x => x.Blog_Id,
                        principalTable: "Blog",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Blog/Like_User",
                        column: x => x.User_Id,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Blog/Tag",
                columns: table => new
                {
                    Blog_Id = table.Column<int>(type: "int", nullable: false),
                    Tag_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Blog/Tag_Blog",
                        column: x => x.Blog_Id,
                        principalTable: "Blog",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Blog/Tag_Tag",
                        column: x => x.Tag_Id,
                        principalTable: "Tag",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Blog/Post",
                columns: table => new
                {
                    Blog_Id = table.Column<int>(type: "int", nullable: false),
                    Post_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Blog/Post_Blog",
                        column: x => x.Blog_Id,
                        principalTable: "Blog",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Blog/Post_Post",
                        column: x => x.Post_Id,
                        principalTable: "Post",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Post/Country",
                columns: table => new
                {
                    Post_Id = table.Column<int>(type: "int", nullable: false),
                    Country_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Post/Country_Country",
                        column: x => x.Country_Id,
                        principalTable: "Country",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Post/Country_Post",
                        column: x => x.Post_Id,
                        principalTable: "Post",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Post/Like",
                columns: table => new
                {
                    Post_Id = table.Column<int>(type: "int", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Post/Like_Post",
                        column: x => x.Post_Id,
                        principalTable: "Post",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Post/Like_User",
                        column: x => x.User_Id,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Post/Reaction",
                columns: table => new
                {
                    Post_Id = table.Column<int>(type: "int", nullable: false),
                    Reaction_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Post/Reaction_Post",
                        column: x => x.Post_Id,
                        principalTable: "Post",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Post/Reaction_Reaction",
                        column: x => x.Reaction_Id,
                        principalTable: "Reaction",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Post/Tag",
                columns: table => new
                {
                    Post_Id = table.Column<int>(type: "int", nullable: false),
                    Tag_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Post/Tag_Post",
                        column: x => x.Post_Id,
                        principalTable: "Post",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Post/Tag_Tag",
                        column: x => x.Tag_Id,
                        principalTable: "Tag",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blog_Creator_Id",
                table: "Blog",
                column: "Creator_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_Trip_Id",
                table: "Blog",
                column: "Trip_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Blog/Country_Blog_Id",
                table: "Blog/Country",
                column: "Blog_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Blog/Country_Country_Id",
                table: "Blog/Country",
                column: "Country_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Blog/Follower_Blog_Id",
                table: "Blog/Follower",
                column: "Blog_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Blog/Follower_Follower_Id",
                table: "Blog/Follower",
                column: "Follower_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Blog/Like_Blog_Id",
                table: "Blog/Like",
                column: "Blog_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Blog/Like_User_Id",
                table: "Blog/Like",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Blog/Post_Blog_Id",
                table: "Blog/Post",
                column: "Blog_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Blog/Post_Post_Id",
                table: "Blog/Post",
                column: "Post_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Blog/Tag_Blog_Id",
                table: "Blog/Tag",
                column: "Blog_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Blog/Tag_Tag_Id",
                table: "Blog/Tag",
                column: "Tag_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Post_Trip_Id",
                table: "Post",
                column: "Trip_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Post/Country_Country_Id",
                table: "Post/Country",
                column: "Country_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Post/Country_Post_Id",
                table: "Post/Country",
                column: "Post_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Post/Like_Post_Id",
                table: "Post/Like",
                column: "Post_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Post/Like_User_Id",
                table: "Post/Like",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Post/Reaction_Post_Id",
                table: "Post/Reaction",
                column: "Post_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Post/Reaction_Reaction_Id",
                table: "Post/Reaction",
                column: "Reaction_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Post/Tag_Post_Id",
                table: "Post/Tag",
                column: "Post_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Post/Tag_Tag_Id",
                table: "Post/Tag",
                column: "Tag_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Preference_User_Id",
                table: "Preference",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reaction_User_Id",
                table: "Reaction",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reaction/Like_Reaction_Id",
                table: "Reaction/Like",
                column: "Reaction_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reaction/Like_User_Id",
                table: "Reaction/Like",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Report_Reporter_Id",
                table: "Report",
                column: "Reporter_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Report_Resolver_Id",
                table: "Report",
                column: "Resolver_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_Creator_Id",
                table: "Trip",
                column: "Creator_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Trip/Budget_Budget_Id",
                table: "Trip/Budget",
                column: "Budget_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Trip/Budget_Trip_Id",
                table: "Trip/Budget",
                column: "Trip_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Trip/Country_Country_Id",
                table: "Trip/Country",
                column: "Country_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Trip/Country_Trip_Id",
                table: "Trip/Country",
                column: "Trip_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Trip/Duration_Duration_Id",
                table: "Trip/Duration",
                column: "Duration_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Trip/Duration_Trip_Id",
                table: "Trip/Duration",
                column: "Trip_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Trip/Tag_Tag_Id",
                table: "Trip/Tag",
                column: "Tag_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Trip/Tag_Trip_Id",
                table: "Trip/Tag",
                column: "Trip_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Trip/Transport_Transport_Id",
                table: "Trip/Transport",
                column: "Transport_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Trip/Transport_Trip_Id",
                table: "Trip/Transport",
                column: "Trip_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blog/Country");

            migrationBuilder.DropTable(
                name: "Blog/Follower");

            migrationBuilder.DropTable(
                name: "Blog/Like");

            migrationBuilder.DropTable(
                name: "Blog/Post");

            migrationBuilder.DropTable(
                name: "Blog/Tag");

            migrationBuilder.DropTable(
                name: "Post/Country");

            migrationBuilder.DropTable(
                name: "Post/Like");

            migrationBuilder.DropTable(
                name: "Post/Reaction");

            migrationBuilder.DropTable(
                name: "Post/Tag");

            migrationBuilder.DropTable(
                name: "Preference");

            migrationBuilder.DropTable(
                name: "Reaction/Like");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "Trip/Budget");

            migrationBuilder.DropTable(
                name: "Trip/Country");

            migrationBuilder.DropTable(
                name: "Trip/Duration");

            migrationBuilder.DropTable(
                name: "Trip/Tag");

            migrationBuilder.DropTable(
                name: "Trip/Transport");

            migrationBuilder.DropTable(
                name: "Blog");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Reaction");

            migrationBuilder.DropTable(
                name: "Budget");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Duration");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Transport");

            migrationBuilder.DropTable(
                name: "Trip");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}

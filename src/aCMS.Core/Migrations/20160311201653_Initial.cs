using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace aCMS.Core.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bio = table.Column<string>(nullable: false),
                    BitbucketUsername = table.Column<string>(nullable: true),
                    CodepenUsername = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailPublicDisplay = table.Column<bool>(nullable: false),
                    FacebookUsername = table.Column<string>(nullable: true),
                    GithubUsername = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    StackoverflowUsername = table.Column<string>(nullable: true),
                    TwitterHandle = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuthorDisplay = table.Column<bool>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    DateTimeCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateTimeDisplay = table.Column<bool>(nullable: false),
                    DateTimeUpdated = table.Column<DateTimeOffset>(nullable: false),
                    SubTitle = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blog_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Page",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuthorDisplay = table.Column<bool>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    DateTimeCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateTimeDisplay = table.Column<bool>(nullable: false),
                    DateTimeUpdated = table.Column<DateTimeOffset>(nullable: false),
                    SubTitle = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Page_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuthorDisplay = table.Column<bool>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false),
                    BlogId = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    DateTimeCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateTimeDisplay = table.Column<bool>(nullable: false),
                    DateTimeUpdated = table.Column<DateTimeOffset>(nullable: false),
                    SubTitle = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Post_Blog_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Page");
            migrationBuilder.DropTable("Post");
            migrationBuilder.DropTable("Blog");
            migrationBuilder.DropTable("Author");
        }
    }
}

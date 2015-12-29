using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace aCMS.Migrations
{
    public partial class SubTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubTitle",
                table: "Post",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "SubTitle",
                table: "Page",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "SubTitle",
                table: "Blog",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "SubTitle", table: "Post");
            migrationBuilder.DropColumn(name: "SubTitle", table: "Page");
            migrationBuilder.DropColumn(name: "SubTitle", table: "Blog");
        }
    }
}

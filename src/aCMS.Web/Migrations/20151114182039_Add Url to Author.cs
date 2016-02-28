using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace aCMS.Web.Migrations
{
    public partial class AddUrltoAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Author",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Url", table: "Author");
        }
    }
}

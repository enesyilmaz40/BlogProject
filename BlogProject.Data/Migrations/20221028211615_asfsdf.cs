﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogProject.Data.Migrations
{
    public partial class asfsdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "passwordHash2",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "passwordHash2",
                table: "AspNetUsers");
        }
    }
}

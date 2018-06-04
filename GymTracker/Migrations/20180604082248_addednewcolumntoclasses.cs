using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GymTracker.Migrations
{
    public partial class addednewcolumntoclasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassesId",
                table: "Members",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Members_ClassesId",
                table: "Members",
                column: "ClassesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Classes_ClassesId",
                table: "Members",
                column: "ClassesId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Classes_ClassesId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_ClassesId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "ClassesId",
                table: "Members");
        }
    }
}

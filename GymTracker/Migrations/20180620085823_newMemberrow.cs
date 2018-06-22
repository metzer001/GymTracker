using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GymTracker.Migrations
{
    public partial class newMemberrow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "ClassesBooked",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassID = table.Column<int>(nullable: false),
                    MemberID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassesBooked", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassesBooked");

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
    }
}

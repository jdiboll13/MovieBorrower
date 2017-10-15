using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MovieBorrower.Migrations
{
    public partial class MoreUpdatesToBorrowRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowRecords_AspNetUsers_ApplicationUserIdId",
                table: "BorrowRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowRecords_Movie_MovieId",
                table: "BorrowRecords");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_BorrowRecords_ApplicationUserIdId",
                table: "BorrowRecords");

            migrationBuilder.DropIndex(
                name: "IX_BorrowRecords_MovieId",
                table: "BorrowRecords");

            migrationBuilder.DropColumn(
                name: "ApplicationUserIdId",
                table: "BorrowRecords");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BorrowRecords");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "BorrowRecords",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BorrowRecords_ApplicationUserId",
                table: "BorrowRecords",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowRecords_AspNetUsers_ApplicationUserId",
                table: "BorrowRecords",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowRecords_AspNetUsers_ApplicationUserId",
                table: "BorrowRecords");

            migrationBuilder.DropIndex(
                name: "IX_BorrowRecords_ApplicationUserId",
                table: "BorrowRecords");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "BorrowRecords");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserIdId",
                table: "BorrowRecords",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "BorrowRecords",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Homepage = table.Column<string>(nullable: true),
                    ImdbId = table.Column<string>(nullable: true),
                    Overview = table.Column<string>(nullable: true),
                    PosterPath = table.Column<string>(nullable: true),
                    ReleaseDate = table.Column<string>(nullable: true),
                    Runtime = table.Column<int>(nullable: false),
                    Tagline = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MovieId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Genre_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BorrowRecords_ApplicationUserIdId",
                table: "BorrowRecords",
                column: "ApplicationUserIdId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowRecords_MovieId",
                table: "BorrowRecords",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Genre_MovieId",
                table: "Genre",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowRecords_AspNetUsers_ApplicationUserIdId",
                table: "BorrowRecords",
                column: "ApplicationUserIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowRecords_Movie_MovieId",
                table: "BorrowRecords",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

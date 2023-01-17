using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NSomeWorks.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstagramUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Duration = table.Column<double>(type: "float", nullable: false),
                    ReleasedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Songs_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ArtistSong",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    SongId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistSong", x => new { x.ArtistId, x.SongId });
                    table.ForeignKey(
                        name: "FK_ArtistSong_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ArtistSong_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "DateOfBirth", "Email", "InstagramUrl", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, new DateTime(1973, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabin.comercial@gmail.com", "www.instagram.com/ifty/", "Gabin", "054678546" },
                    { 2, new DateTime(1980, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Londobeat.comercial@gmail.com", "www.instagram.com/t", "Londobeat", "47645624" },
                    { 3, new DateTime(1993, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panik.comercial@gmail.com", "www.instagram.com/ftshty/", "Panik", "6544231234" },
                    { 4, new DateTime(1988, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radioheat.comercial@gmail.com", "www.instagram.com/git", "Radioheat", "2321165778" },
                    { 5, new DateTime(1974, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arabesque.comercial@gmail.com", "www.instagram.com/gfty/", "Arabesque", "445221265" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Jazz" },
                    { 2, "Funk" },
                    { 3, "Reaggae" },
                    { 4, "Latin" },
                    { 5, "Metal" }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Duration", "GenreId", "ReleasedDate", "Title" },
                values: new object[,]
                {
                    { 1, 3.5, 1, new DateTime(2003, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabin" },
                    { 2, 7.2999999999999998, 2, new DateTime(1999, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blinding Lights" },
                    { 3, 4.2000000000000002, 3, new DateTime(2003, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Balenciaga" },
                    { 4, 1.8, 4, new DateTime(2004, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Roses" },
                    { 5, 3.7000000000000002, 5, new DateTime(2007, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Beliver" }
                });

            migrationBuilder.InsertData(
                table: "ArtistSong",
                columns: new[] { "ArtistId", "SongId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 1, 2 },
                    { 3, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 3, 3 },
                    { 3, 4 },
                    { 4, 4 },
                    { 5, 4 },
                    { 2, 5 },
                    { 4, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistSong_SongId",
                table: "ArtistSong",
                column: "SongId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_GenreId",
                table: "Songs",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistSong");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NSomeWorks.Migrations
{
    public partial class AddClientAndData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientID",
                table: "Projects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    NameCompany = table.Column<string>(maxLength: 150, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "ClientId", "Email", "FirstName", "LastName", "NameCompany", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "comercial@nafta.ua", "Мыкола", "Парасюк", "Нафтогаз", "04067493487" },
                    { 2, "comercial@atb.ua", "Степан", "Наливайко", "АТБ-Маркет", "0785493787" },
                    { 3, "comercial@sich.ua", "Юрий", "Шурло", "Мотор Сич", "78067496587" },
                    { 4, "comercial@kernel.ua", "Виктория", "Акулибаба", "Кернел-трейд", "0655649547" },
                    { 5, "comercial@tesla.ua", "Виктор", "Хрюкин", "Тесла", "056593487" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "Budget", "ClientID", "Name", "StartedDate" },
                values: new object[,]
                {
                    { 1, 15000m, 1, "WhatsApp", new DateTime(2008, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 85000m, 2, "Эковер", new DateTime(2007, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 952040m, 3, "Чук и Гик", new DateTime(2012, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 700000m, 4, "Sunofabeach", new DateTime(2016, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 600000m, 5, "Tesla", new DateTime(2000, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ClientID",
                table: "Projects",
                column: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Client_ClientID",
                table: "Projects",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Client_ClientID",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ClientID",
                table: "Projects");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "Projects");
        }
    }
}

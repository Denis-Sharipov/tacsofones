using Microsoft.EntityFrameworkCore.Migrations;

namespace TacsofonesObjects.WebService.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TacsofonObjs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Adres = table.Column<string>(nullable: true),
                    Oplata = table.Column<string>(nullable: true),
                    Platnost = table.Column<string>(nullable: true),
                    Card = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TacsofonObjs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TacsofonObjs",
                columns: new[] { "Id", "Adres", "Card", "Name", "Oplata", "Platnost" },
                values: new object[] { 1L, "Вавилова улица, дом 5А", "не действует", "Таксофон №1449", "карта", "бесплатно" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TacsofonObjs");
        }
    }
}

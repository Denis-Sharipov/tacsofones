using Microsoft.EntityFrameworkCore.Migrations;

namespace TacsofonObj.WebService.Migrations
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
                    Adres = table.Column<string>(nullable: true),
                    Card = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Oplata = table.Column<string>(nullable: true),
                    Platnost = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TacsofonObjs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TacsofonObjs",
                columns: new[] { "Id", "Adres", "Card", "Name",  "Oplata", "Platnost"},
                values: new object[] { 1L, "Вавилова улица, дом 5А", "действует", "Таксофон № 1449", "карта", "бесплатно" });

            migrationBuilder.InsertData(
                table: "TacsofonObjs",
                columns: new[] { "Id", "Adres", "Card", "Name", "Oplata", "Platnost" },
                values: new object[] { 2L, "Вавилова улица, дом 51, Школа №199", "Таксофон № 1499", "карта", "Архангельский собор", "бесплатно" });

            migrationBuilder.InsertData(
                table: "TacsofonObjs",
                columns: new[] { "Id", "Adres", "Card", "Name", "Oplata", "Platnost" },
                values: new object[] { 3L, "Вавилова улица, дом 6", "не действует", "Таксофон № 76", "карта", "бесплатно" });

            migrationBuilder.InsertData(
                table: "TacsofonObjs",
                columns: new[] { "Id", "Adres", "Card", "Name", "Oplata", "Platnost" },
                values: new object[] { 4L, "Валдайский проезд, дом 14, Школа №158", "не действует", "карта", "Патриаршие палаты с церковью Двенадцати апостолов", "бесплатно" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TacsofonObjs");
        }
    }
}

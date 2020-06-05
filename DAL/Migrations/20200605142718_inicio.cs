using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipos",
                columns: table => new
                {
                    EquipoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Serial = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    SistemaOperativo = table.Column<string>(nullable: false),
                    Memoria = table.Column<int>(nullable: false),
                    Disco = table.Column<int>(nullable: false),
                    Procesador = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipos", x => x.EquipoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipos");
        }
    }
}

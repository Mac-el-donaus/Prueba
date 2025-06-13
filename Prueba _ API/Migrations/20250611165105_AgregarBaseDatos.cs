using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prueba___API.Migrations
{
    public partial class AgregarBaseDatos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prueba",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Detalle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tarifa = table.Column<double>(type: "float", nullable: false),
                    Ocupantes = table.Column<int>(type: "int", nullable: false),
                    MetrosCuadrados = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amenidad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prueba", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prueba");
        }
    }
}

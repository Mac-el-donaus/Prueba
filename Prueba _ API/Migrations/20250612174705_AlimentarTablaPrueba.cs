using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Prueba___API.Migrations
{
    /// <inheritdoc />
    public partial class AlimentarTablaPrueba : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Prueba",
                newName: "ImagenUrl");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Prueba",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualizacion",
                table: "Prueba",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Prueba",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Prueba",
                columns: new[] { "Id", "Amenidad", "Detalle", "FechaActualizacion", "FechaCreacion", "ImagenUrl", "MetrosCuadrados", "Nombre", "Ocupantes", "Tarifa" },
                values: new object[,]
                {
                    { 1, "", "Detalle de la Villa...", new DateTime(2025, 6, 12, 11, 47, 5, 372, DateTimeKind.Local).AddTicks(8157), new DateTime(2025, 6, 12, 11, 47, 5, 372, DateTimeKind.Local).AddTicks(8145), "", 50, "Villa Real", 5, 200.0 },
                    { 2, "", "Detalle de la Villa...", new DateTime(2025, 6, 12, 11, 47, 5, 372, DateTimeKind.Local).AddTicks(8163), new DateTime(2025, 6, 12, 11, 47, 5, 372, DateTimeKind.Local).AddTicks(8163), "", 40, "Premium Vista a la piscina", 4, 150.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Prueba",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prueba",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "FechaActualizacion",
                table: "Prueba");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Prueba");

            migrationBuilder.RenameColumn(
                name: "ImagenUrl",
                table: "Prueba",
                newName: "ImageUrl");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Prueba",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaHotelAPI.Migrations
{
    /// <inheritdoc />
    public partial class Migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_habitacions_hotel_HotelId",
                table: "habitacions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_habitacions",
                table: "habitacions");

            migrationBuilder.RenameTable(
                name: "habitacions",
                newName: "habitacion");

            migrationBuilder.RenameIndex(
                name: "IX_habitacions_HotelId",
                table: "habitacion",
                newName: "IX_habitacion_HotelId");

            migrationBuilder.AddColumn<int>(
                name: "Capacidad",
                table: "habitacion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_habitacion",
                table: "habitacion",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "reservacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdHotel = table.Column<int>(type: "int", nullable: false),
                    IdHabitacion = table.Column<int>(type: "int", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    CantPersonas = table.Column<int>(type: "int", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraIngreso = table.Column<TimeSpan>(type: "time", nullable: false),
                    HoraSalida = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoDocumente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreContactEmer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonoContactEmer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_habitacion_hotel_HotelId",
                table: "habitacion",
                column: "HotelId",
                principalTable: "hotel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_habitacion_hotel_HotelId",
                table: "habitacion");

            migrationBuilder.DropTable(
                name: "reservacion");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_habitacion",
                table: "habitacion");

            migrationBuilder.DropColumn(
                name: "Capacidad",
                table: "habitacion");

            migrationBuilder.RenameTable(
                name: "habitacion",
                newName: "habitacions");

            migrationBuilder.RenameIndex(
                name: "IX_habitacion_HotelId",
                table: "habitacions",
                newName: "IX_habitacions_HotelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_habitacions",
                table: "habitacions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_habitacions_hotel_HotelId",
                table: "habitacions",
                column: "HotelId",
                principalTable: "hotel",
                principalColumn: "Id");
        }
    }
}

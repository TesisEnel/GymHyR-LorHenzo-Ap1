using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymHyR.Migrations
{
    /// <inheritdoc />
    public partial class HorarioE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HorarioEntrenadorId",
                table: "CitasEntrenamiento",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "HorarioEntrenadorId",
                table: "CitasEntrenamiento",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}

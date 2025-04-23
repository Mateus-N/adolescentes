using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoAdolescentes.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class tipoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "senha",
                table: "usuarios",
                newName: "senha_hash");

            migrationBuilder.AddColumn<int>(
                name: "tipo",
                table: "usuarios",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tipo",
                table: "usuarios");

            migrationBuilder.RenameColumn(
                name: "senha_hash",
                table: "usuarios",
                newName: "senha");
        }
    }
}

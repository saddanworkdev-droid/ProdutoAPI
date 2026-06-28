using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProdutoAPI.Migrations
{
    /// <inheritdoc />
    public partial class AtualizarUsuarioComSenhaHashRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Senha",
                table: "Usuarios",
                newName: "SenhaHash");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Usuarios",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "SenhaHash",
                table: "Usuarios",
                newName: "Senha");
        }
    }
}

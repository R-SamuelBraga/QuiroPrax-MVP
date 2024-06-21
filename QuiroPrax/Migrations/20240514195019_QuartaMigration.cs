using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuiroPrax.Migrations
{
    /// <inheritdoc />
    public partial class QuartaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MotivoVisita",
                table: "FormulariosAdmissao");

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Quiropratas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Quiropratas");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Clientes");

            migrationBuilder.AddColumn<string>(
                name: "MotivoVisita",
                table: "FormulariosAdmissao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

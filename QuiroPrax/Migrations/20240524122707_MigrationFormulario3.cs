using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuiroPrax.Migrations
{
    /// <inheritdoc />
    public partial class MigrationFormulario3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormulariosAdmissao_Clientes_ClienteId",
                table: "FormulariosAdmissao");

            migrationBuilder.DropIndex(
                name: "IX_FormulariosAdmissao_ClienteId",
                table: "FormulariosAdmissao");

            migrationBuilder.DropColumn(
                name: "AtendeDomicilio",
                table: "Quiropratas");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "FormulariosAdmissao");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "FormulariosAdmissao");

            migrationBuilder.AddColumn<int>(
                name: "FormularioAdmissaoId",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_FormularioAdmissaoId",
                table: "Clientes",
                column: "FormularioAdmissaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_FormulariosAdmissao_FormularioAdmissaoId",
                table: "Clientes",
                column: "FormularioAdmissaoId",
                principalTable: "FormulariosAdmissao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_FormulariosAdmissao_FormularioAdmissaoId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_FormularioAdmissaoId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "FormularioAdmissaoId",
                table: "Clientes");

            migrationBuilder.AddColumn<bool>(
                name: "AtendeDomicilio",
                table: "Quiropratas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "FormulariosAdmissao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "FormulariosAdmissao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FormulariosAdmissao_ClienteId",
                table: "FormulariosAdmissao",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormulariosAdmissao_Clientes_ClienteId",
                table: "FormulariosAdmissao",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

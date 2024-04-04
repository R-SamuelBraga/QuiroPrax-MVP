using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuiroPrax.Migrations
{
    /// <inheritdoc />
    public partial class TerceiraMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FormulariosAdmissao_ClienteId",
                table: "FormulariosAdmissao");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FormulariosAdmissao_ClienteId",
                table: "FormulariosAdmissao");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "FormulariosAdmissao");

            migrationBuilder.CreateIndex(
                name: "IX_FormulariosAdmissao_ClienteId",
                table: "FormulariosAdmissao",
                column: "ClienteId",
                unique: true);
        }
    }
}

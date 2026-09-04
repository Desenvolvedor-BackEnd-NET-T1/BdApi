using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbApi.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoPropriedadeAtivoCli : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AtivoCli",
                table: "Tb_clientes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AtivoCli",
                table: "Tb_clientes");
        }
    }
}

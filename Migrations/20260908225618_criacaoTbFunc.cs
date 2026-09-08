using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbApi.Migrations
{
    /// <inheritdoc />
    public partial class criacaoTbFunc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AtivoCli",
                table: "Tb_clientes",
                newName: "ativoCli");

            migrationBuilder.CreateTable(
                name: "tb_funcionarios",
                columns: table => new
                {
                    idFunc = table.Column<string>(type: "varchar(50)", nullable: false),
                    nomeFunc = table.Column<string>(type: "varchar(100)", nullable: true),
                    emailFunc = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_funcionarios", x => x.idFunc);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_funcionarios");

            migrationBuilder.RenameColumn(
                name: "ativoCli",
                table: "Tb_clientes",
                newName: "AtivoCli");
        }
    }
}

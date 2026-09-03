using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbApi.Migrations
{
    /// <inheritdoc />
    public partial class updateTypesFluentValidation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.RenameTable(
                name: "Clientes",
                newName: "Tb_clientes");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Tb_clientes",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Endereco",
                table: "Tb_clientes",
                newName: "endCli");

            migrationBuilder.AlterColumn<string>(
                name: "codCli",
                table: "Tb_clientes",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "endCli",
                table: "Tb_clientes",
                type: "varchar(200)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tb_clientes",
                table: "Tb_clientes",
                column: "codCli");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tb_clientes",
                table: "Tb_clientes");

            migrationBuilder.RenameTable(
                name: "Tb_clientes",
                newName: "Clientes");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Clientes",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "endCli",
                table: "Clientes",
                newName: "Endereco");

            migrationBuilder.AlterColumn<string>(
                name: "codCli",
                table: "Clientes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "Endereco",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "codCli");
        }
    }
}

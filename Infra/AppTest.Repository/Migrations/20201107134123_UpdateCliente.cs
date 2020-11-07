using Microsoft.EntityFrameworkCore.Migrations;

namespace AppTest.Repository.Migrations
{
    public partial class UpdateCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CNPJ",
                schema: "dbo",
                table: "Cliente",
                maxLength: 18,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 16,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CNPJ",
                schema: "dbo",
                table: "Cliente",
                maxLength: 16,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 18,
                oldNullable: true);
        }
    }
}

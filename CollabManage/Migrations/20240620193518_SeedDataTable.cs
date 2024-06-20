using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollabManage.Migrations
{
    public partial class SeedDataTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "Endereco", "Name", "Telefone" },
                values: new object[] { 2001, "Br-116 - Fazenda Rio Grande", "CollabManage", "(41) 99123-4567" });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "Cargo", "Departamento", "Name" },
                values: new object[,]
                {
                    { 1001, "Desenvolvedor", "Tecnologia", "José" },
                    { 1002, "Analista", "RH", "Carlos" },
                    { 1003, "Vendedor", "Comercial", "João" },
                    { 1004, "Suporte", "Tecnologia", "André" },
                    { 1005, "Desenvolvedora", "Tecnologia", "Maria" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Company",
                keyColumn: "Id",
                keyValue: 2001);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1003);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1004);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1005);
        }
    }
}

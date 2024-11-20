using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDTechTest.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Alamat",
                table: "Kendaraan",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Kendaraan",
                keyColumn: "NomorRegistrasi",
                keyValue: "B1234ABC",
                column: "BahanBakar",
                value: "Hitam");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Alamat",
                table: "Kendaraan",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Kendaraan",
                keyColumn: "NomorRegistrasi",
                keyValue: "B1234ABC",
                column: "BahanBakar",
                value: "Bensin");
        }
    }
}

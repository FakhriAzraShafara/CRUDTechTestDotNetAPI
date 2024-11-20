using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDTechTest.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUniqueConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "WarnaKendaraan",
                table: "Kendaraan",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NamaPemilik",
                table: "Kendaraan",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "MerkKendaraan",
                table: "Kendaraan",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BahanBakar",
                table: "Kendaraan",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NomorRegistrasi",
                table: "Kendaraan",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.UpdateData(
                table: "Kendaraan",
                keyColumn: "NomorRegistrasi",
                keyValue: "B1234ABC",
                column: "BahanBakar",
                value: "Bensin");

            migrationBuilder.CreateIndex(
                name: "IX_Kendaraan_NomorRegistrasi",
                table: "Kendaraan",
                column: "NomorRegistrasi",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Kendaraan_NomorRegistrasi",
                table: "Kendaraan");

            migrationBuilder.AlterColumn<string>(
                name: "WarnaKendaraan",
                table: "Kendaraan",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NamaPemilik",
                table: "Kendaraan",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "MerkKendaraan",
                table: "Kendaraan",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BahanBakar",
                table: "Kendaraan",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NomorRegistrasi",
                table: "Kendaraan",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20);

            migrationBuilder.UpdateData(
                table: "Kendaraan",
                keyColumn: "NomorRegistrasi",
                keyValue: "B1234ABC",
                column: "BahanBakar",
                value: "Hitam");
        }
    }
}

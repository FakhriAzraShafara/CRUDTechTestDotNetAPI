using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDTechTest.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Kendaraan",
                columns: table => new
                {
                    NomorRegistrasi = table.Column<string>(type: "varchar(255)", nullable: false),
                    NamaPemilik = table.Column<string>(type: "longtext", nullable: false),
                    Alamat = table.Column<string>(type: "longtext", nullable: true),
                    MerkKendaraan = table.Column<string>(type: "longtext", nullable: true),
                    TahunPembuatan = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    KapasitasSilinder = table.Column<int>(type: "int", nullable: false),
                    WarnaKendaraan = table.Column<string>(type: "longtext", nullable: true),
                    BahanBakar = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kendaraan", x => x.NomorRegistrasi);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Kendaraan",
                columns: new[] { "NomorRegistrasi", "Alamat", "BahanBakar", "KapasitasSilinder", "MerkKendaraan", "NamaPemilik", "TahunPembuatan", "WarnaKendaraan" },
                values: new object[] { "B1234ABC", "Jl. Sudirman No. 123, Pemalang", "Bensin", 2000, "Toyota", "Ahmad Kurniawan", 2020, "Putih" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kendaraan");
        }
    }
}

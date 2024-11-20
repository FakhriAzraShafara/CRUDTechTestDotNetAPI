using Microsoft.EntityFrameworkCore;

namespace CRUDTechTest.Entities
{
    public class TechTestTapebringContext : DbContext
    {
        public TechTestTapebringContext(DbContextOptions<TechTestTapebringContext> options)
            : base(options)
        {
        }

        public required DbSet<Kendaraan> Kendaraan { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kendaraan>(entity =>
            {
                // Primary Key
                entity.HasKey(k => k.NomorRegistrasi);

                // Membuat NomorRegistrasi sebagai unique constraint
                entity.HasIndex(k => k.NomorRegistrasi)
                      .IsUnique();

                // Required fields
                entity.Property(k => k.NomorRegistrasi)
                      .IsRequired()
                      .HasMaxLength(20); // Menambahkan batasan panjang untuk nomor registrasi

                entity.Property(k => k.NamaPemilik)
                      .IsRequired()
                      .HasMaxLength(100); // Menambahkan batasan panjang untuk nama

                entity.Property(k => k.Alamat)
                      .HasColumnType("text");

                // Validasi untuk WarnaKendaraan
                entity.Property(k => k.WarnaKendaraan)
                      .HasMaxLength(20);

                // Validasi untuk MerkKendaraan
                entity.Property(k => k.MerkKendaraan)
                      .HasMaxLength(50);

                // Validasi untuk BahanBakar
                entity.Property(k => k.BahanBakar)
                      .HasMaxLength(20);
            });

            // Seeding data
            modelBuilder.Entity<Kendaraan>().HasData(
                new Kendaraan
                {
                    NomorRegistrasi = "B1234ABC",
                    NamaPemilik = "Ahmad Kurniawan",
                    Alamat = "Jl. Sudirman No. 123, Pemalang",
                    MerkKendaraan = "Toyota",
                    TahunPembuatan = 2020,
                    KapasitasSilinder = 2000,
                    WarnaKendaraan = "Putih",
                    BahanBakar = "Bensin"
                }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { }
    }
}
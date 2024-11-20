using CRUDTechTest.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUDTechTest.Services
{
    public class KendaraanService : IKendaraanService
    {
        private readonly TechTestTapebringContext _context;

        public KendaraanService(TechTestTapebringContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Kendaraan>> GetAllKendaraan()
        {
            return await _context.Kendaraan.ToListAsync();
        }

        public async Task<Kendaraan> GetKendaraan(string nomorRegistrasi)
        {
            if (string.IsNullOrEmpty(nomorRegistrasi))
            {
                throw new ArgumentNullException(nameof(nomorRegistrasi));
            }

            var kendaraan = await _context.Kendaraan.FindAsync(nomorRegistrasi);
            return kendaraan ?? throw new KeyNotFoundException($"Kendaraan dengan nomor registrasi {nomorRegistrasi} tidak ditemukan");
        }

        public async Task<Kendaraan> CreateKendaraan(Kendaraan kendaraan)
        {
            if (kendaraan == null)
            {
                throw new ArgumentNullException(nameof(kendaraan));
            }

            _context.Kendaraan.Add(kendaraan);
            await _context.SaveChangesAsync();
            return kendaraan;
        }

        public async Task<Kendaraan> UpdateKendaraan(Kendaraan kendaraan)
        {
            if (kendaraan == null)
            {
                throw new ArgumentNullException(nameof(kendaraan));
            }

            _context.Entry(kendaraan).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return kendaraan;
        }

        public async Task DeleteKendaraan(string nomorRegistrasi)
        {
            if (string.IsNullOrEmpty(nomorRegistrasi))
            {
                throw new ArgumentNullException(nameof(nomorRegistrasi));
            }

            var kendaraan = await _context.Kendaraan.FindAsync(nomorRegistrasi);
            if (kendaraan != null)
            {
                _context.Kendaraan.Remove(kendaraan);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Kendaraan>> SearchKendaraan(string? nomorRegistrasi, string? namaPemilik)
        {
            IQueryable<Kendaraan> query = _context.Kendaraan;

            if (!string.IsNullOrWhiteSpace(nomorRegistrasi))
            {
                query = query.Where(k => k.NomorRegistrasi != null &&
                    k.NomorRegistrasi.ToLower().Contains(nomorRegistrasi.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(namaPemilik))
            {
                query = query.Where(k => k.NamaPemilik != null &&
                    k.NamaPemilik.ToLower().Contains(namaPemilik.ToLower()));
            }

            return await query.ToListAsync();
        }
    }
}
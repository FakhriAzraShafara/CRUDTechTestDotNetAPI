using CRUDTechTest.Entities;

namespace CRUDTechTest.Services
{
    public interface IKendaraanService
    {
        Task<List<Kendaraan>> GetAllKendaraan();
        Task<Kendaraan> GetKendaraan(string nomorRegistrasi);
        Task<Kendaraan> CreateKendaraan(Kendaraan kendaraan);
        Task<Kendaraan> UpdateKendaraan(Kendaraan kendaraan);
        Task DeleteKendaraan(string nomorRegistrasi);
        Task<List<Kendaraan>> SearchKendaraan(string? nomorRegistrasi, string? namaPemilik);
    }
}

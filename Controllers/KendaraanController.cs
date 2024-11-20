using CRUDTechTest.Entities;
using CRUDTechTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDTechTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KendaraanController : ControllerBase
    {
        private readonly IKendaraanService _kendaraanService;

        public KendaraanController(IKendaraanService kendaraanService)
        {
            _kendaraanService = kendaraanService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Kendaraan>>> GetKendaraan()
        {
            return await _kendaraanService.GetAllKendaraan();
        }

        [HttpGet("{nomorRegistrasi}")]
        public async Task<ActionResult<Kendaraan>> GetKendaraan(string nomorRegistrasi)
        {
            var kendaraan = await _kendaraanService.GetKendaraan(nomorRegistrasi);
            if (kendaraan == null)
                return NotFound("Kendaraan dengan nomor registrasi tersebut tidak ditemukan.");
            return kendaraan;
        }

        [HttpPost]
        public async Task<ActionResult<Kendaraan>> CreateKendaraan(Kendaraan kendaraan)
        {
            try
            {
                var result = await _kendaraanService.CreateKendaraan(kendaraan);
                return CreatedAtAction(nameof(GetKendaraan),
                    new { nomorRegistrasi = result.NomorRegistrasi }, result);
            }
            catch (DbUpdateException ex) when (IsDuplicateKeyException(ex))
            {
                return Conflict(new { message = $"Nomor Registrasi '{kendaraan.NomorRegistrasi}' sudah terdaftar." });
            }
            catch (Exception ex)
            {
                // Log the exception details here if needed
                return BadRequest(new
                {
                    message = "Terjadi kesalahan saat membuat data kendaraan.",
                    error = ex.Message
                });
            }
        }

        [HttpPut("{nomorRegistrasi}")]
        public async Task<ActionResult<Kendaraan>> UpdateKendaraan(string nomorRegistrasi, Kendaraan kendaraan)
        {
            if (nomorRegistrasi != kendaraan.NomorRegistrasi)
                return BadRequest(new { message = "Nomor registrasi tidak sesuai dengan data yang akan diupdate." });

            try
            {
                return await _kendaraanService.UpdateKendaraan(kendaraan);
            }
            catch (DbUpdateException ex) when (IsDuplicateKeyException(ex))
            {
                return Conflict(new { message = $"Nomor Registrasi '{kendaraan.NomorRegistrasi}' sudah terdaftar." });
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = $"Kendaraan dengan nomor registrasi '{nomorRegistrasi}' tidak ditemukan." });
            }
            catch (Exception ex)
            {
                // Log the exception details here if needed
                return BadRequest(new
                {
                    message = "Terjadi kesalahan saat mengupdate data kendaraan.",
                    error = ex.Message
                });
            }
        }

        [HttpDelete("{nomorRegistrasi}")]
        public async Task<IActionResult> DeleteKendaraan(string nomorRegistrasi)
        {
            try
            {
                await _kendaraanService.DeleteKendaraan(nomorRegistrasi);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = $"Kendaraan dengan nomor registrasi '{nomorRegistrasi}' tidak ditemukan." });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = "Terjadi kesalahan saat menghapus data kendaraan.",
                    error = ex.Message
                });
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<ApiResponse<IEnumerable<Kendaraan>>>> SearchKendaraan(
            [FromQuery] string? nomorRegistrasi,
            [FromQuery] string? namaPemilik)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nomorRegistrasi) &&
                    string.IsNullOrWhiteSpace(namaPemilik))
                {
                    return BadRequest(ApiResponse<IEnumerable<Kendaraan>>.CreateError(
                        "Minimal satu parameter pencarian harus diisi (Nomor Registrasi atau Nama Pemilik)"));
                }

                var results = await _kendaraanService.SearchKendaraan(nomorRegistrasi, namaPemilik);

                if (!results.Any())
                {
                    return Ok(ApiResponse<IEnumerable<Kendaraan>>.CreateSuccess(
                        results,
                        "Tidak ada data yang ditemukan"));
                }

                return Ok(ApiResponse<IEnumerable<Kendaraan>>.CreateSuccess(
                    results,
                    $"Ditemukan {results.Count} data kendaraan"));
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = "Terjadi kesalahan saat melakukan pencarian data kendaraan.",
                    error = ex.Message
                });
            }
        }

        private bool IsDuplicateKeyException(DbUpdateException ex)
{
    return (ex.InnerException?.Message.Contains("duplicate key") == true) 
        || (ex.InnerException?.Message.Contains("UNIQUE constraint") == true);
}
    }
}
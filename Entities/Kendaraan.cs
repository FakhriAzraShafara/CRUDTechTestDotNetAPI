using System.ComponentModel.DataAnnotations;

namespace CRUDTechTest.Entities
{
    public class Kendaraan
    {
        [Key]
        [Required(ErrorMessage = "Nomor Registrasi wajib diisi")]
        public string? NomorRegistrasi { get; set; }

        [Required(ErrorMessage = "Nama Pemilik wajib diisi")]
        public string? NamaPemilik { get; set; }

        [DataType(DataType.MultilineText)]
        public string? Alamat { get; set; }

        public string? MerkKendaraan { get; set; }

        [Range(1000, 9999, ErrorMessage = "Tahun pembuatan harus 4 digit")]
        public int TahunPembuatan { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Kapasitas silinder harus berupa angka positif")]
        public int KapasitasSilinder { get; set; }

        [RegularExpression("^(Merah|Hitam|Biru|Abu-Abu)$",
            ErrorMessage = "Warna Kendaraan harus salah satu dari: Merah, Hitam, Biru, Abu-Abu")]
        public string? WarnaKendaraan { get; set; }

        public string? BahanBakar { get; set; }
    }
}

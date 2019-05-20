using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LPS.Models
{
    public class tblT_Reservasi
    {

        [Key]
        public int Reservasi_PK { get; set; }

        [Required(ErrorMessage = "Harap Isi !")]
        [DisplayName("Ruangan")]
        public int Ruangan_FK { get; set; }

        [Required(ErrorMessage = "Harap Isi !")]
        [DisplayName("Subjek")]
        public string SubjectReservasi { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [Required(ErrorMessage = "Harap Isi !")]
        [DisplayName("Tanggal")]
        public DateTime? TanggalReservasi { get; set; }

        [DisplayFormat(DataFormatString = @"{0:hh\-mm}")]
        [Required(ErrorMessage = "Harap Isi !")]
        [DisplayName("Mulai")]
        public TimeSpan? JamMulai { get; set; }

        [DisplayFormat(DataFormatString = @"{0:hh\-mm}")]
        [Required(ErrorMessage = "Harap Isi !")]
        [DisplayName("Selesai")]
        public TimeSpan? JamSelesai { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LPS.Models
{
    public class tblM_Ruangan
    {
        [Key]
        public int Ruangan_PK { get; set; }
        public string NamaRuangan { get; set; }
        public int Lantai { get; set; }
        public int DayaTampung { get; set; }
        public int Status_FK { get; set; }
    }
}

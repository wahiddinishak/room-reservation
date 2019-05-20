using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LPS.Models
{
    public class tblM_Status
    {

        [Key]
        public int Status_PK { get; set; }
        public string NamaStatus { get; set; }
    }
}

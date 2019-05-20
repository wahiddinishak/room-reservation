using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LPS.Models
{
    public class LPSContext : DbContext
    {
        public LPSContext(DbContextOptions<LPSContext> options) : base(options)
        {

        }

        // data master
        public virtual DbSet<tblM_Status> TblM_Statuse { get; set; }
        public virtual DbSet<tblM_Ruangan> TblM_Ruangan { get; set; }

        // data transact
        public virtual DbSet<tblT_Reservasi> TblT_Reservasi { get; set; }
    }
}

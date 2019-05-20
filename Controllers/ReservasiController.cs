using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LPS.Models;
using ReflectionIT.Mvc.Paging;

namespace LPS.Controllers
{
    public class ReservasiController : Controller
    {
        private readonly LPSContext _context;

        public ReservasiController(LPSContext context)
        {
            _context = context;
        }

        // GET: Reservasi
        public async Task<IActionResult> Index(string searchString, int page = 1)
        {

            ViewData["CurrentFilter"] = searchString;

            var reservasi = from a in _context.TblT_Reservasi
                            join b in _context.TblM_Ruangan on a.Ruangan_FK equals b.Ruangan_PK
                            select new tblT_Reservasi
                            {
                                Reservasi_PK = a.Reservasi_PK,
                                Ruangan_FK = Int32.Parse(b.NamaRuangan),
                                SubjectReservasi = a.SubjectReservasi,
                                TanggalReservasi = a.TanggalReservasi,
                                JamMulai = a.JamMulai,
                                JamSelesai = a.JamSelesai
                            };

            if (!String.IsNullOrEmpty(searchString))
            {
                reservasi = reservasi.Where(s => Convert.ToString(s.SubjectReservasi).Contains(searchString)
                                       || Convert.ToString(s.Ruangan_FK).Contains(searchString)
                                       || Convert.ToString(s.TanggalReservasi).Contains(searchString));
            }

            var query = reservasi.AsNoTracking().OrderBy(a => a.TanggalReservasi);
            var model = await PagingList.CreateAsync(query, 10, page);

            return View(model);
        }


        // GET: Reservasi/AddOrEdit
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                ViewBag.ruang = _context.TblM_Ruangan.Where(a => a.Status_FK == 2).ToList();
                return View(new tblT_Reservasi());
            }
            else
            {
                ViewBag.ruang = _context.TblM_Ruangan.Where(a => a.Ruangan_PK == id).ToList();
                return View(_context.TblT_Reservasi.Find(id));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Reservasi_PK,Ruangan_FK,SubjectReservasi,TanggalReservasi,JamMulai,JamSelesai")] tblT_Reservasi tblT_Reservasi)
        {
            if (ModelState.IsValid)
            {
                if (tblT_Reservasi.Reservasi_PK == 0)
                {
                    _context.Add(tblT_Reservasi);

                    var entity = _context.TblM_Ruangan.FirstOrDefault(a => a.Ruangan_PK == tblT_Reservasi.Ruangan_FK);
                    entity.Status_FK = 1;
                    _context.TblM_Ruangan.Update(entity);
                }
                else
                {
                    _context.Update(tblT_Reservasi);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblT_Reservasi);
        }

        // GET: Reservasi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var resrv = await _context.TblT_Reservasi.FindAsync(id);
            _context.TblT_Reservasi.Remove(resrv);

            var entity = _context.TblM_Ruangan.FirstOrDefault(a => a.Ruangan_PK == id);
            entity.Status_FK = 2;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Opskriftplanen.Data;
using Opskriftplanen.Models;
using Opskriftplanen.Utility;

namespace Opskriftplanen.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.Admin)]
    [Area("Admin")]
    public class MeasurmentUnitController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MeasurmentUnitController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _db.MeasurmentUnit.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MeasurmentUnit measurmentUnit)
        {
            if (ModelState.IsValid)
            {
                _db.MeasurmentUnit.Add(measurmentUnit);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(measurmentUnit);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var measurmentUnit = await _db.MeasurmentUnit.FindAsync(id);
            if (measurmentUnit == null)
            {
                return NotFound();
            }
            return View(measurmentUnit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MeasurmentUnit measurmentUnit)
        {
            if (ModelState.IsValid)
            {
                _db.Update(measurmentUnit);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(measurmentUnit);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var measurmentUnit = await _db.MeasurmentUnit.FindAsync(id);
            if (measurmentUnit == null)
            {
                return NotFound();
            }
            return View(measurmentUnit);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var measurmentUnit = await _db.MeasurmentUnit.FindAsync(id);

            if (measurmentUnit == null)
            {
                return View();
            }
            _db.MeasurmentUnit.Remove(measurmentUnit);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var measurmentUnit = await _db.MeasurmentUnit.FindAsync(id);
            if (measurmentUnit == null)
            {
                return NotFound();
            }
            return View(measurmentUnit);
        }
    }
}
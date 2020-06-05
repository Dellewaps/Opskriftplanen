using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Opskriftplanen.Data;
using Opskriftplanen.Models;
using Opskriftplanen.Models.ViewModels;

namespace Opskriftplanen.Areas.Users.Controllers
{
    [Area("Users")]
    [Authorize]
    public class UserWeekPlanController : Controller
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public WeekIndexViewModel WeekVM { get; set; }
        public UserWeekPlanController(ApplicationDbContext db)
        {
            _db = db;
            WeekVM = new WeekIndexViewModel()
            {
                EnumWeekPlan = _db.WeekPlan.ToList(),
                WeekDetails = new WeekDetails(),
                PlanHeader = new PlanHeader(),
                Recipes = new Recipes(),
                WeekPlan = new WeekPlan(),
            };
        }
        public async Task<IActionResult> Index()
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            ApplicationUsers applicationUser = await _db.ApplicationUsers.Where(c => c.Id == claim.Value).FirstOrDefaultAsync();

            var weekplan = await _db.WeekPlan.Where(c => c.ApplicationUserId == applicationUser.Id).ToListAsync();

            WeekVM.EnumWeekPlan = weekplan;

            return View(WeekVM);
        }

        public async Task<IActionResult> Edit (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);            
            WeekVM.WeekPlan = await _db.WeekPlan.SingleOrDefaultAsync(m => m.Id == id && m.ApplicationUserId == claim.Value);
            

            if ( WeekVM.WeekPlan == null)
            {
                return NotFound();
            }

            return View(WeekVM);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View(WeekVM);
            }

            var weekFromDb = await _db.WeekPlan.FindAsync(WeekVM.WeekPlan.Id);

            await _db.SaveChangesAsync();

            weekFromDb.Week = WeekVM.WeekPlan.Week;

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Print(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View(WeekVM);
            }

            var weekFromDb = await _db.WeekPlan.FindAsync(WeekVM.WeekPlan.Id);

            

            return View();
        }


        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Opskriftplanen.Data;
using Opskriftplanen.Models;
using Opskriftplanen.Models.ViewModels;
using Opskriftplanen.Extensions;
using Opskriftplanen.Utility;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

namespace Opskriftplanen.Areas.Users.Controllers
{
    [Area("Users")]
    public class PlanController : Controller
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public PlanDetailsList DetailsList { get; set; }

        public PlanController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            DetailsList = new PlanDetailsList()
            {
                PlanHeader = new PlanHeader(),
                
            };

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var list = _db.RecipeList.Where(c => c.ApplicationUserId == claim.Value);
            if(list != null)
            {
                DetailsList.RecipeList = list.ToList();
                
            }

            foreach(var item in DetailsList.RecipeList)
            {
                item.Recipes = await _db.Recipe.FirstOrDefaultAsync(m => m.Id == item.ResipesId);
                item.Recipes.Description = SD.ConvertToRawHtml(item.Recipes.Description);
                if(item.Recipes.Description.Length > 100)
                {
                    item.Recipes.Description = item.Recipes.Description.Substring(0, 99) + "...";
                }
            }

            return View(DetailsList);
        }

        public async Task<IActionResult> Weekplan()
        {


            DetailsList = new PlanDetailsList()
            {
                PlanHeader = new PlanHeader(),
                WeekPlan = new WeekPlan(),
                Recipe = _db.Recipe
            };

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            ApplicationUsers applicationUser = await _db.ApplicationUsers.Where(c => c.Id == claim.Value).FirstOrDefaultAsync();
            
            var list = _db.RecipeList.Where(c => c.ApplicationUserId == claim.Value);
            if (list != null)
            {
                DetailsList.RecipeList = list.ToList();
                
            }
            DetailsList.Recipe = _db.RecipeList.Where(c => c.ApplicationUserId == claim.Value).Select(s => s.Recipes);
            foreach (var item in DetailsList.RecipeList)
            {
                item.Recipes = await _db.Recipe.FirstOrDefaultAsync(m => m.Id == item.ResipesId);
                
                
            }

            DetailsList.PlanHeader.Name = applicationUser.Name;
            

            return View(DetailsList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Weekplan")]
        public async Task<IActionResult> WeekplanPost()
        {
            
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            DetailsList.RecipeList = await _db.RecipeList.Where(u => u.ApplicationUserId == claim.Value).ToListAsync();

            DetailsList.PlanHeader.UserId = claim.Value;

            List<WeekDetails> weekDetailsList = new List<WeekDetails>();
            _db.PlanHeader.Add(DetailsList.PlanHeader);
            await _db.SaveChangesAsync();

            WeekPlan week = new WeekPlan()
            {
                ApplicationUserId = claim.Value,
                Week = DetailsList.WeekPlan.Week,
                Monday = Convert.ToInt32(HttpContext.Request.Form["monday"]),
                Tuesday = Convert.ToInt32(HttpContext.Request.Form["tuesday"]),
                Wednesday = Convert.ToInt32(HttpContext.Request.Form["wednesday"]),
                Thursday = Convert.ToInt32(HttpContext.Request.Form["thursday"]),
                Friday = Convert.ToInt32(HttpContext.Request.Form["friday"]),
                Saturday = Convert.ToInt32(HttpContext.Request.Form["saturday"]),
                Sunday = Convert.ToInt32(HttpContext.Request.Form["sunday"])
                
            };
            _db.WeekPlan.Add(week);
            await _db.SaveChangesAsync();
            foreach (var item in DetailsList.RecipeList)
            {
                item.Recipes = await _db.Recipe.FirstOrDefaultAsync(m => m.Id == item.ResipesId);
                WeekDetails weekDetails = new WeekDetails()
                {
                    RecipesId = item.ResipesId,
                    PlanId = DetailsList.PlanHeader.Id,
                    Name = item.Recipes.Name,
                    WeekPlanId = week.Id,
                };
                _db.WeekDetails.Add(weekDetails);
            }
            _db.RecipeList.RemoveRange(DetailsList.RecipeList);
            HttpContext.Session.SetInt32(SD.ssRecipeListCount, 0);
            await _db.SaveChangesAsync();
            
            return RedirectToAction("Print", "UserWeekPlan", new { id = DetailsList.PlanHeader.Id });
        }


        public async Task<IActionResult> Remove (int listId)
        {
            var list = await _db.RecipeList.FirstOrDefaultAsync(c => c.Id == listId);

            _db.RecipeList.Remove(list);
            await _db.SaveChangesAsync();

            var cnt = _db.RecipeList.Where(u => u.ApplicationUserId == list.ApplicationUserId).ToList().Count();
            HttpContext.Session.SetInt32(SD.ssRecipeListCount, cnt);

            return RedirectToAction(nameof(Index));
        }
    }
}
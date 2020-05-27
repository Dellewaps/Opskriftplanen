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

            
            //DetailsList.Recipes = _db.RecipeList.Where(r => r.ResipesId == r.Recipes.Id).Include(i => i.Recipes);
            //DetailsList.Recipes = list.Include(i => i.Recipes).Where(r => r.ResipesId == r.Recipes.Id).Select(r => new Recipes {Id = r.ResipesId, Name = r.Recipes.Name }).AsEnumerable<Recipes>();
            DetailsList.PlanHeader.Name = applicationUser.Name;
            

            return View(DetailsList);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Opskriftplanen.Data;
using Opskriftplanen.Models;
using Opskriftplanen.Models.ViewModels;
using Opskriftplanen.Utility;

namespace Opskriftplanen.Controllers
{
    [Area("Users")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            IndexViewModel IndexVM = new IndexViewModel()
            {
                Recipes = await _db.Recipe.Include(m => m.Category).ToListAsync(),
                Category = await _db.Category.ToListAsync()
            };

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if(claim != null)
            {
                var cnt = _db.RecipeList.Where(u => u.ApplicationUserId == claim.Value).ToList().Count();
                HttpContext.Session.SetInt32(SD.ssRecipeListCount, cnt);
            }
            return View(IndexVM);
        }

        public async Task<IActionResult> Details(int? id)
        {
            var recipeFromDb = await _db.Recipe.Include(m => m.Category).Where(m => m.Id == id).SingleOrDefaultAsync();
            var ingredients =  _db.IngredientCollection.Where(m => m.RecipesId == id).Include(m => m.Ingredient).Include(m => m.MeasurmentUnit);
            RecipeList listObj = new RecipeList()
            {
                ingredientCollection = new IngredientCollection(),
                Ingredient = _db.Ingredient,
                MeasurmentUnit = _db.MeasurmentUnit,
                category = _db.Category,
                Recipes = recipeFromDb,
                ResipesId = recipeFromDb.Id,
                ingredientCollections = ingredients,
                
            };

            return View(listObj);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details (RecipeList ListObject)
        {
            ListObject.Id = 0;
            if (ModelState.IsValid)
            {
                var claimsIdentity = (ClaimsIdentity)this.User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                ListObject.ApplicationUserId = claim.Value;

                RecipeList recipeFromDb =  _db.RecipeList.Where(c => c.ApplicationUserId == ListObject.ApplicationUserId && c.ResipesId == ListObject.ResipesId).FirstOrDefault();

                if(recipeFromDb == null)
                {
                    await _db.RecipeList.AddAsync(ListObject);
                    
                }

                await _db.SaveChangesAsync();

                var count = _db.RecipeList.Where(c => c.ApplicationUserId == ListObject.ApplicationUserId).ToList().Count();
                HttpContext.Session.SetInt32(SD.ssRecipeListCount, count);

                return RedirectToAction("Index");
            }
            else
            {
                var recipeFromDb = await _db.Recipe.Include(r => r.Category).Where(r => r.Id == ListObject.ResipesId).FirstOrDefaultAsync();

                RecipeList listObj = new RecipeList()
                {
                    Recipes = recipeFromDb,
                    ResipesId = recipeFromDb.Id
                };

                return View(listObj);
            }
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

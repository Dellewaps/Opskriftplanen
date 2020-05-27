using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Opskriftplanen.Data;
using Opskriftplanen.Models;
using Opskriftplanen.Models.ViewModels;
using Opskriftplanen.Utility;

namespace Opskriftplanen.Areas.Users.Controllers
{
    [Area("Users")]
    [Authorize]
    public class UserRecipeController : Controller
    {
        private readonly ApplicationDbContext _db;

        private readonly IWebHostEnvironment _webHostEnvironment;

        [BindProperty]
        public RecipeViewModel RecipeVM { get; set; }

        public UserRecipeController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
            RecipeVM = new RecipeViewModel()
            {
                ingredientCollection = new IngredientCollection(),
                Ingredient = _db.Ingredient,
                MeasurmentUnit = _db.MeasurmentUnit,
                category = _db.Category,
                Recipes = new Recipes(),
                ApplicationUsers = new ApplicationUsers()
            };
        }
        public async Task<IActionResult> Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            ApplicationUsers applicationUser = await _db.ApplicationUsers.Where(c => c.Id == claim.Value).FirstOrDefaultAsync();

            var recipes = await _db.Recipe.Include(c => c.Category).Where(c => c.ApplicationUserId == applicationUser.Id).ToListAsync();

            return View(recipes);
        }

        public IActionResult Create()
        {

            return View(RecipeVM);
        }

        [HttpPost, ActionName("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePOST()
        {
            if (!ModelState.IsValid)
            {
                return View(RecipeVM);
            }


            _db.Recipe.Add(RecipeVM.Recipes);
            await _db.SaveChangesAsync();


            var RecipeFromDb = await _db.Recipe.FindAsync(RecipeVM.Recipes.Id);

            for (int i = 0; i < this.Request.Form["ingredient"].Count(); i++)
            {
                IngredientCollection c = new IngredientCollection();
                c.RecipesId = RecipeFromDb.Id;
                c.IngredientId = Convert.ToInt32(this.Request.Form["ingredient"][i]);
                c.Measur = Convert.ToInt32(this.Request.Form["measure"][i]);
                c.MeasurmentUnitId = Convert.ToInt32(this.Request.Form["measurmenUnit"][i]);
                _db.IngredientCollection.Add(c);
            }

            await _db.SaveChangesAsync();

            //For at gemme billede
            string webRootPath = _webHostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;


            if (files.Count > 0)
            {
                //Hvis billede var uplaodet
                var uploads = Path.Combine(webRootPath, "images");
                var extension = Path.GetExtension(files[0].FileName);

                using (var filesStream = new FileStream(Path.Combine(uploads, RecipeVM.Recipes.Id + extension), FileMode.Create))
                {
                    files[0].CopyTo(filesStream);
                }
                RecipeFromDb.Image = @"\images\" + RecipeVM.Recipes.Id + extension;

            }
            else
            {
                //HVis der ikke er noget billede uploadet, bruger den det default billede
                var uploads = Path.Combine(webRootPath, @"images\" + SD.DefaultRecipeImage);
                System.IO.File.Copy(uploads, webRootPath + @"\images\" + RecipeVM.Recipes.Id + ".png");
                RecipeFromDb.Image = @"\images\" + RecipeVM.Recipes.Id + ".png";
            }
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            RecipeVM.Recipes.ApplicationUserId = claim.Value;



            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            RecipeVM.Recipes = await _db.Recipe.Include(m => m.Category).SingleOrDefaultAsync(m => m.Id == id && m.ApplicationUserId == claim.Value);
            RecipeVM.ingredientCollections = _db.IngredientCollection.Where(m => m.RecipesId == id && m.Recipes.ApplicationUserId == claim.Value).Include(m => m.Ingredient).Include(m => m.MeasurmentUnit);


            if (RecipeVM.Recipes == null)
            {
                return NotFound();
            }
            return View(RecipeVM);
        }

        [HttpPost, ActionName("edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPOST(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View(RecipeVM);
            }

            var RecipeFromDb = await _db.Recipe.FindAsync(RecipeVM.Recipes.Id);
            var ingredientCollection = _db.IngredientCollection.Where(m => m.RecipesId == id);

            for (int i = 0; i < this.Request.Form["ingredient"].Count(); i++)
            {
                IngredientCollection c = new IngredientCollection();
                c.RecipesId = RecipeFromDb.Id;
                c.IngredientId = Convert.ToInt32(this.Request.Form["ingredient"][i]);
                c.Measur = Convert.ToInt32(this.Request.Form["measure"][i]);
                c.MeasurmentUnitId = Convert.ToInt32(this.Request.Form["measurmenUnit"][i]);
                _db.IngredientCollection.Add(c);
            }

            await _db.SaveChangesAsync();

            //Gemmer billede

            string webRootPath = _webHostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;


            if (files.Count > 0)
            {
                //Nyt billede er blevet uploadet 
                var uploads = Path.Combine(webRootPath, "images");
                var extension_new = Path.GetExtension(files[0].FileName);

                //slet det billede der var
                var imagePath = Path.Combine(webRootPath, RecipeFromDb.Image.TrimStart('\\'));

                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }


                //upload det nye billede
                using (var filesStream = new FileStream(Path.Combine(uploads, RecipeVM.Recipes.Id + extension_new), FileMode.Create))
                {
                    files[0].CopyTo(filesStream);
                }
                RecipeFromDb.Image = @"\images\" + RecipeVM.Recipes.Id + extension_new;

            }

            RecipeFromDb.Name = RecipeVM.Recipes.Name;
            RecipeFromDb.Description = RecipeVM.Recipes.Description;
            RecipeFromDb.PersonCount = RecipeVM.Recipes.PersonCount;
            RecipeFromDb.CategoryId = RecipeVM.Recipes.CategoryId;

            foreach (var item in ingredientCollection)
            {
                item.IngredientId = RecipeVM.ingredientCollection.IngredientId;
                item.Measur = RecipeVM.ingredientCollection.Measur;
                item.MeasurmentUnitId = RecipeVM.ingredientCollection.MeasurmentUnitId;
            }

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                NotFound();
            }
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            RecipeVM.Recipes = await _db.Recipe.Include(g => g.Category).SingleOrDefaultAsync(m => m.Id == id && m.ApplicationUserId == claim.Value);
            RecipeVM.ingredientCollections = _db.IngredientCollection.Where(m => m.RecipesId == id).Include(m => m.Ingredient).Include(m => m.MeasurmentUnit);

            if (RecipeVM.Recipes == null)
            {
                NotFound();
            }

            return View(RecipeVM);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                NotFound();
            }

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            RecipeVM.Recipes = await _db.Recipe.Include(g => g.Category).SingleOrDefaultAsync(m => m.Id == id && m.ApplicationUserId == claim.Value);
            RecipeVM.ingredientCollections = _db.IngredientCollection.Where(m => m.RecipesId == id).Include(m => m.Ingredient).Include(m => m.MeasurmentUnit);

            if (RecipeVM.Recipes == null)
            {
                NotFound();
            }

            return View(RecipeVM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;

            Recipes recipes = await _db.Recipe.FindAsync(id);
            var ingredientCollection = _db.IngredientCollection.Where(m => m.RecipesId == id).ToList();


            if (recipes != null)
            {
                var imagePath = Path.Combine(webRootPath, recipes.Image.TrimStart('\\'));

                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }

                foreach (var item in ingredientCollection)
                {
                    _db.IngredientCollection.Remove(item);
                }


                _db.Recipe.Remove(recipes);
                await _db.SaveChangesAsync();

            }

            return RedirectToAction(nameof(Index));
        }
    }
}